#include "PiGenerator.h"
#include "Helpers.h"
#include <iostream>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
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

int _digits, _alg, _count, _prec;

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
	for (; _prec < prec0 * 2 + 10; _count++, _prec = _prec * 2 + 10) {
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
			mpf_sub (b2, b2, c2); //FIXME: czasami (b2->_mp_size == -1041) => wtf?? a potem siê my_sqrt wykrzacza... na razie zmieniam alg na 1
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
			stop = (*listener)(0, 0);
		}
		if (stop) {
			cout << "Pi generation stopped" << endl;
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

void generatePi(int d, CoolListener listener) {
	_digits = d; //tyle chcemy wygenerowaæ

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
		saveState();
	}

	mpf_mul_2exp (a2, a2, 1);
	my_div (a2, a2, sum);

	File file;
	/*
	TODO: Tomek:
	- poprawiæ zapisywanie gdy res == false (zatrzymano obliczenia)
	- sparametryzowaæ nazwê pliku
	*/
	file.SaveBIGNUM(a2, L"pi.bignum");

	clearAll();
}
