#include "PiGenerator.h"
#include "Helpers.h"
#include <iostream>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <windows.h>
#include "gmp.h"
#include "File.h"
#include "Function.h"

using namespace std;

#define alg 2 //0 lub 2 (1 nie dzia³a :P)

#define BITS_PER_DIGIT   3.32192809488736234787

#define show(x)      {printf(#x"="); mpf_out_str(stdout, 10, 0, x); printf("\n");}
#define abs(x)      ((x)>0?(x):(-x))

int prec0;			/* require precision */
mpf_t a, b, a2, b2, c2, sum; /* used for pi generation */

int _digits, _alg, _count, _prec, _maxTimeMs;

void setPrecision() {
	prec0 = _digits * BITS_PER_DIGIT + 16;
	mpf_set_default_prec (prec0);
}

void initAll() {
	mpf_init (a);
	mpf_init (b);
	mpf_init (a2);
	mpf_init (b2);
	mpf_init (c2);
	mpf_init (sum);

	helpers_init();
}

void clearAll() {
	mpf_clear(a);
	mpf_clear (b);
	mpf_clear (a2);
	mpf_clear (b2);
	mpf_clear (c2);
	mpf_clear (sum);

	helpers_clear();
}

void setStartValues() {
	mpf_set_ui (a, 1);
	mpf_set_ui (a2, 1);
	mpf_set_d (b2, 0.5);
	mpf_set_d (c2, 0.5);
	mpf_set_ui (sum, 1);
}

bool generate(CoolListener listener) {
	int tempCounter = 0;
	int prec0m2p10 = prec0 * 2 + 10;
	int startTime = GetTickCount();

	for (; _prec < prec0m2p10; _count++, _prec = _prec * 2 + 10) {
		if (_alg != 1) {
			/*   c2   = a2 - b2; */
			mpf_sub (c2, a2, b2);
		}
		/*   sum -= (1<<n)*c2; */
		mpf_mul_2exp (c2, c2, _count);
		mpf_sub (sum, sum, c2);

		if (_alg == 0) {
			/*  b    = sqrt(b2); */
			my_sqrt (b, b2);
			/*  a    = (a+b)/2; */
			mpf_add (a, a, b);
			mpf_div_2exp (a, a, 1);
			/*  c2   = (a-b)*(a-b); */
			mpf_sub (c2, a, b);
			mpf_mul (c2, c2, c2);
			/*  b2   = ((a2+b2)/4-c2)*2; */
			mpf_add (b2, b2, a2);
			mpf_div_2exp (b2, b2, 2);
			mpf_sub (b2, b2, c2);
			mpf_mul_2exp (b2, b2, 1);
			/*  a2   = b2+c2; */
			mpf_add (a2, b2, c2);
		} else if (_alg == 1) {
			/*  b    = sqrt(b2); */
			my_sqrt (c2, b2);
			/*  a    = (a + b)/2; */
			mpf_add (a, a, c2);
			mpf_div_2exp (a, a, 1);
			/*  b2   = (a2 + b2)/4; */
			mpf_add (b2, b2, a2);
			mpf_div_2exp (b2, b2, 2);
			/*  a2   = a*a; */
			mpf_mul (a2, a, a);
			/*  b2   = (a2 - b2)*2; */
			mpf_sub (b2, a2, b2);
			mpf_mul_2exp (b2, b2, 1);
		} else {
			/* c2   = a2*b2; */
			mpf_mul (c2, a2, b2);
			/* a2   = (a2+b2)/2; */
			mpf_add (a2, a2, b2);
			mpf_div_2exp (a2, a2, 1);
			/* b2   = sqrt(c2); */
			my_sqrt (b2, c2);
			/* a2   = (a2+b2)/2; */
			mpf_add (a2, a2, b2);
			mpf_div_2exp (a2, a2, 1);
		}

		bool stop = false;
		/*if (listener != 0) {
			stop = (*listener)((float)(_prec) / (float)(prec0 * 2 + 10));
		}*/
		if (listener != 0) {
			int length = ((long)100 * (long)_prec) / (long)prec0m2p10;
			int time = (_maxTimeMs != 0) ? (100 * (GetTickCount() - startTime)) / _maxTimeMs : 0;
			stop = (*listener)(time , length); //time, length
		}
		bool timeout = (_maxTimeMs != 0) ? (GetTickCount() >= startTime + _maxTimeMs) : false;
		if (stop || timeout) {
			cout << "Pi generation stopped or timeouted" << endl;
			_count++;
			_prec = _prec * 2 + 10;
			return false;
		}
	}	

	return true;
}

bool saveState() {
	FILE *output = fopen("savedState", "w");
	fprintf(output, "%d %d %d %d", _digits, _alg, _count, _prec);
	fclose(output);

	//mpf_t test;

	int res;
	saveMpf(a, "a");
	saveMpf(b, "b");

	saveMpf(a2, "a2");
	//readMpf(test, "a2");
	//saveMpf(test, "a2test");
	//res = mpf_cmp(a2, test);
	//if (res != 0) {
	//	cout << "a2 - dammit!" << endl;
	//}
	//mpf_clear(test);

	saveMpf(b2, "b2");
	/*readMpf(test, "b2");
	res = mpf_cmp(b2, test);
	if (res != 0) {
		cout << "b2 - dammit!" << endl;
		saveMpf(test, "b2test");
	}
	mpf_clear(test);*/

	saveMpf(c2, "c2");
	/*readMpf(test, "c2");
	res = mpf_cmp(c2, test);
	if (res != 0) {
		cout << "c2 - dammit!" << endl;
		saveMpf(test, "c2test");
	}
	mpf_clear(test);*/

	saveMpf(sum, "sum");
	/*readMpf(test, "sum");
	res = mpf_cmp(sum, test);
	if (res != 0) {
		cout << "sum - dammit!" << endl;
		saveMpf(test, "sumtest");
	}
	mpf_clear(test);*/

	return true;
}

bool saveMpf(mpf_t var, const char * filename) {
	FILE *fa = fopen(filename, "wb"); //ja pierdole...

	fwrite(&var->_mp_exp, sizeof(var->_mp_exp), 1, fa);
	fwrite(&var->_mp_prec, sizeof(var->_mp_prec), 1, fa);
	fwrite(&var->_mp_size, sizeof(var->_mp_size), 1, fa);
	int maxVal = max( var->_mp_prec + 1, abs(var->_mp_size));
	size_t mp_d_size = sizeof(*var->_mp_d);
	fwrite(var->_mp_d, mp_d_size, maxVal, fa);
	//if (fwrite(var->_mp_d, mp_d_size, maxVal, fa) < maxVal) cout << "write error";
	//cout << "Should be: " << sizeof(var->_mp_exp) + sizeof(var->_mp_prec) + sizeof(var->_mp_size) + mp_d_size * maxVal << endl;

	fclose(fa);

	return true;
}

//nale¿y podaæ niezainicjalizowan¹ zmienn¹
bool readMpf(mpf_t var, const char *filename) {
	FILE *fa = fopen(filename, "rb"); //ja pierdole...
	if (fa == 0) {
		return false;
	}
	if (fread(&var->_mp_exp, sizeof(var->_mp_exp), 1, fa) == 0) cout << "exp";
	if (fread(&var->_mp_prec, sizeof(var->_mp_prec), 1, fa) == 0) cout << "prec";
	if (fread(&var->_mp_size, sizeof(var->_mp_size), 1, fa) == 0) cout << "size";

	int maxVal = max(var->_mp_prec + 1, abs(var->_mp_size));
	int allocationSize = (maxVal) * sizeof(*var->_mp_d);
	var->_mp_d = (mp_limb_t*) __gmp_allocate_func(allocationSize);
	size_t read = fread(var->_mp_d, sizeof(*var->_mp_d), maxVal, fa);

	fclose(fa);

	//jeœli teraz operujemy na wiêkszej precyzji to zwiêkszamy
	//TODO: test
	if (mpf_get_default_prec() > mpf_get_prec(var)) {
		mpf_set_prec(var, prec0);
	}

	return true;
}

//0 - ok, 1 - nie ok, >1 - ju¿ wygenerowano, nawet wiêcej
int readState(int algorithm) {
	int ret;

	FILE *input = fopen("savedState", "r");
	if (input == 0) { //brak pliku
		return 1;
	}

	int computedDigits;
	ret = fscanf(input, "%d %d %d %d", &computedDigits, &_alg, &_count, &_prec);
	fclose(input);
	if (ret == EOF) { // b³¹d w pliku
		return 1;
	}

	if (algorithm != _alg) { //zapisane obliczenia zrobione innym algorytmem
		return 1;
	}

	if (computedDigits >= _digits) { //wygenerowano wczeœniej wiêcej 
		return computedDigits;
	}

	//zapisane obliczenia, ale dla mniejszej iloœci cyfr

	setPrecision(); // ustaw domyœln¹ precyzjê

	//wszelkie zmienne powinny byæ niezainicjalizowane
	if (!readMpf(a, "a")) {
		return 1;
	}
	if (!readMpf(b, "b")) {
		mpf_clear(a);
		return 1;
	}
	if (!readMpf(a2, "a2")) {
		mpf_clear(a);
		mpf_clear(b);
		return 1;
	}

	if (!readMpf(b2, "b2")) {
		mpf_clear(a);
		mpf_clear(b);
		mpf_clear(a2);
		return 1;
	}

	if (!readMpf(c2, "c2")) {
		mpf_clear(a);
		mpf_clear(b);
		mpf_clear(a2);
		mpf_clear(b2);
		return 1;
	}

	if (!readMpf(sum, "sum")) {
		mpf_clear(a);
		mpf_clear(b);
		mpf_clear(a2);
		mpf_clear(b2);
		mpf_clear(c2);
		return 1;
	}

	//jeœli wszystko ok to inicjalizujemy te¿ zmienne pomocnicze
	helpers_init();

	return 0;
}

void generatePi(wchar_t *fileName, int d, int maxTimeMs, CoolListener listener) {
	_digits = d; //tyle chcemy wygenerowaæ
	_maxTimeMs = maxTimeMs;

	int ret = readState(alg);
	if (ret > 1) { // pi ju¿ zosta³o wygenerowane z wiêksz¹ dok³adnoœci¹
		cout << "Pi already generated with higher precision: " << ret << endl;
		return;
	} else if (ret == 1) { //trzeba liczyæ od pocz¹tku
		_digits = d;
		_count = 0;
		_prec = -1;
		_alg = alg;

		setPrecision();
		initAll();

		setStartValues();
	}
	//ret == 0: mo¿na wznowiæ, wszystkie wartoœci pocz¹tkowe ustawione przez readState()
	
	bool res = generate(listener);
	//if res - wygenerowano wszystko
	// if !res - wygenerowano tylko czêœæ, zmienna _prec po której iterujemy prawdopodobnie definiuje ile mamy ju¿ cyfr
	if (res) {
		//saveState(); //to niestety nie zadzia³a :]
	}

	mpf_mul_2exp (a2, a2, 1);
	my_div (a2, a2, sum);

	File file;
	/*
	TODO: Tomek:
	- poprawiæ zapisywanie gdy res == false (zatrzymano obliczenia)
	- sparametryzowaæ nazwê pliku
	*/
	if(fileName) {
		file.SaveBIGNUM(a2, 10, fileName);
		wstring str(fileName);
		str.append(L".hex");
		file.SaveBIGNUM(a2, 16, (wchar_t *)str.c_str());
	}

	clearAll();
}
int readF(mpf_t mp, char *fileName) {
	FILE * f = fopen(fileName,"r");
	if(f==0){
		return -1;
	}
	mpf_init(mp); // TODO jakies precyzje i inne syfy?
	mpf_inp_str(mp,f,10);
	fclose(f);
	return 0;
}

int readI(mpz_t mp, char *fileName) {
	FILE * f = fopen(fileName,"r");
	if(f==0){
		return -1;
	}
	mpz_init(mp); // TODO jakies precyzje i inne syfy?
	mpz_inp_str(mp,f,10);
	fclose(f);
	return 0;
}

int add() {
	setPrecision(); // ustaw domyœln¹ precyzjê
	mpf_t left;
	mpf_t right;
	mpf_t wynik;
	mpf_init(wynik);
	readF(left,CALCFILE1);
	readF(right,CALCFILE2);

	mpf_add(wynik,left,right);
	mpf_clear(left);
	mpf_clear(right);

	FILE * f = fopen(CALCFILE1OUT,"w");
	if(f==0) {
		mpf_clear(wynik);
		return -1;
	}	
	gmp_fprintf(f,"%Ff",wynik);
	//mpf_out_str(f, 10, 0, wynik);
	fflush(f);
	fclose(f);

	mpf_clear(wynik);
	return 0;
}

int sub() {
	setPrecision(); // ustaw domyœln¹ precyzjê
	mpf_t left;
	mpf_t right;
	mpf_t wynik;
	mpf_init(wynik);
	readF(left,CALCFILE1);
	readF(right,CALCFILE2);

	mpf_sub(wynik,left,right);
	mpf_clear(left);
	mpf_clear(right);

	FILE * f = fopen(CALCFILE1OUT,"w");
	if(f==0) {
		mpf_clear(wynik);
		return -1;
	}	
	gmp_fprintf(f,"%Ff",wynik);
	//mpf_out_str(f,10,0,wynik);
	fflush(f);
	fclose(f);
	
	mpf_clear(wynik);
	return 0;

}
int mul() {
	setPrecision(); // ustaw domyœln¹ precyzjê
	mpf_t left;
	mpf_t right;
	mpf_t wynik;
	mpf_init(wynik);
	readF(left,CALCFILE1);
	readF(right,CALCFILE2);

	mpf_mul(wynik,left,right);

	mpf_clear(left);
	mpf_clear(right);

	FILE * f = fopen(CALCFILE1OUT,"w");
	if(f==0) {
		mpf_clear(wynik);
		return -1;
	}
	
	//mpf_out_str(f,10,0,wynik);
	gmp_fprintf(f,"%Ff",wynik);
	fflush(f);
	fclose(f);
	mpf_clear(wynik);
	return 0;
}
int divDouble(){
	setPrecision(); // ustaw domyœln¹ precyzjê
	mpf_t left;
	mpf_t right;
	mpf_t wynik;
	mpf_init(wynik);
	readF(left,CALCFILE1);
	readF(right,CALCFILE2);



	mpf_div(wynik,left,right);
	mpf_clear(left);
	mpf_clear(right);
	FILE * f = fopen(CALCFILE1OUT,"w");
	if(f==0) {
		mpf_clear(wynik);
		return -1;
	}
	
	//mpf_out_str(f,10,0,wynik);
	gmp_fprintf(f,"%Ff",wynik);
	fflush(f);
	fclose(f);

	mpf_clear(wynik);
	return 0;
}
int equ() {
	setPrecision(); // ustaw domyœln¹ precyzjê
	mpf_t left;
	mpf_t right;
	readF(left,CALCFILE1);
	readF(right,CALCFILE2);

	int wynik = mpf_cmp(left, right);
	mpf_clear(left);
	mpf_clear(right);

	FILE * f = fopen(CALCFILE1OUT,"w");
	if(f==0) {
		return -1;
	}
	fprintf(f,"%d",wynik);
	fflush(f);
	fclose(f);
	return 0;
}

int divInt() {
	setPrecision(); // ustaw domyœln¹ precyzjê
	mpz_t left;
	mpz_t right;
	mpz_t quotient; // iloraz
	mpz_t remainder; // reszta
	mpz_init(quotient);
	mpz_init(remainder);
	readI(left,CALCFILE1);
	readI(right,CALCFILE2);

	mpz_divmod(quotient,remainder,left,right);
	mpz_clear(left);
	mpz_clear(right);
	FILE * f1 = fopen(CALCFILE1OUT,"w");
	if(f1==0) {
		mpz_clear(quotient);
		mpz_clear(remainder);
		return -1;
	}
	FILE * f2 = fopen(CALCFILE2OUT,"w");
	if(f2==0) {
		mpz_clear(quotient);
		mpz_clear(remainder);
		return -1;
	}

	mpz_out_str(f1,0,quotient);
	mpz_out_str(f2,0,remainder);
	fflush(f1);
	fflush(f2);
	fclose(f1);
	fclose(f2);

	mpz_clear(quotient);
	mpz_clear(remainder);
	return 0;
}

int fancy(unsigned long n) {
	//2^2^n+1
	setPrecision(); // ustaw domyœln¹ precyzjê

	mpz_t two;
	mpz_init_set_ui(two, 2);
	
	mpz_t res;
	mpz_init(res);
	mpz_pow_ui(res, two, n);
	if (!mpz_fits_ulong_p(res)) {
		mpz_clear(two);
		mpz_clear(res);
		return -2;
	}
	n = mpz_get_ui(res);
	mpz_pow_ui(res, two, n);
	mpz_add_ui(res, res, 1);

	mpz_clear(two);

	FILE * f = fopen(CALCFILE1OUT,"w");
	if(f==0) {
		mpz_clear(res);
		return -1;
	}
	
	mpz_out_str(f, 10, res);
	fflush(f);
	fclose(f);

	mpz_clear(res);
	return 0;
}

int mersenne(unsigned long n) {
	//2^n-1
	setPrecision(); // ustaw domyœln¹ precyzjê
	mpz_t two;
	mpz_init_set_ui(two, 2);
	
	mpz_t res;
	mpz_init(res);
	mpz_pow_ui(res, two, n);
	mpz_clear(two);

	mpz_sub_ui(res, res, 1);
	
	FILE * f = fopen(CALCFILE1OUT,"w");
	if(f==0) {
		mpz_clear(res);
		return -1;
	}	
	
	mpz_out_str(f, 10, res);
	fflush(f);
	fclose(f);

	mpz_clear(res);
	return 0;
}
