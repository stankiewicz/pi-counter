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

bool generate(Listener listener) {
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
			(*listener)();
		}
		if (stop) {
			_count++;
			_prec = _prec * 2 + 10;
			return false;
		}
	}	

	return true;
}

bool saveMpf(mpf_t var, const char * filename, int base) {
	FILE *fa = fopen(filename, "w");

	fwrite(&var->_mp_exp, sizeof(var->_mp_exp), 1, fa);
	fwrite(&var->_mp_prec, sizeof(var->_mp_prec), 1, fa);
	fwrite(&var->_mp_size, sizeof(var->_mp_size), 1, fa);
	fwrite(var->_mp_d, sizeof(*var->_mp_d), var->_mp_prec, fa);
	/*for(unsigned int i = 0; i < var->_mp_prec; i++)
	{
		fseek(fa, 12 + sizeof(*var->_mp_d) * i, SEEK_SET);
		fwrite(var->_mp_d + i, sizeof(*var->_mp_d), 1, fa);
	}*/

	//gmp_fprintf(fa, "%.*Ff", _digits, var);
	fclose(fa);

	return true;
}

bool saveMpf(mpf_t var, const char * filename) {
	return saveMpf(var, filename, 2);
}

bool saveState() {
	FILE *output = fopen("savedState", "w");
	fprintf(output, "%d %d %d %d", _digits, _alg, _count, _prec);
	fclose(output);

	saveMpf(a, "a");
	saveMpf(b, "b");
	saveMpf(a2, "a2");
	saveMpf(b2, "b2");
	saveMpf(c2, "c2");
	saveMpf(sum, "sum");

	return true;
}

//automatycznie czyœci zmienn¹ do której ma zwróciæ wynik
bool readMpf(mpf_t var, const char *filename) {
	//mpf_clear(var);
	//mpf_init(var);
	FILE *fa = fopen(filename, "r");
	if (fa == 0) {
		return false;
	}
	//gmp_fscanf(fa, "%Ff", var);

	fread(&var->_mp_exp, sizeof(var->_mp_exp), 1, fa);
	fread(&var->_mp_prec, sizeof(var->_mp_prec), 1, fa);
	int toRead = var->_mp_prec;
	if(prec0 > var->_mp_prec)
		var->_mp_prec = prec0;
	fread(&var->_mp_size, sizeof(var->_mp_size), 1, fa);
	int allocationSize = (var->_mp_prec + 1) * sizeof(*var->_mp_d);
	var->_mp_d = (mp_limb_t*) __gmp_allocate_func(allocationSize);
	char *p = (char *) (void *) var->_mp_d;
	for(int i = 0; i < allocationSize; i++)
		*(p + i) = 0;
	fread(var->_mp_d, sizeof(*var->_mp_d), toRead, fa);
	var->_mp_d[var->_mp_prec] = 0;
	//var->_mp_d = (mp_limb_t*) __gmp_allocate_func((var->_mp_prec + 1) * bytes_per_mp_limb);
	/*unsigned int i;
	for(i = 0; i < var->_mp_prec; i++)
	{
		fseek(fa, 12 + sizeof(*var->_mp_d) * i, seek_set);
		fread(var->_mp_d + i, sizeof(*var->_mp_d), 1, fa);
	}
	var->_mp_d[i] = 0;*/

	fclose(fa);
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

void __stdcall generatePi(int digits, Listener listener) {
	generateNewPi(digits, 0, listener);		
}

void __stdcall CalculateFunction(wchar_t *filename, char *a, char *b, int maxTimeMs, unsigned int numberOfDigitsToCheck, Listener listener)
{
	Function function;
	File file;
	unsigned int length;
	mp_exp_t exp;
	char *stringNumber = mpf_get_str(NULL, &exp, 10, 0, a2);
	
	mpf_t mpf_a, mpf_b;
	mpf_init(mpf_a);
	mpf_init(mpf_b);
	
	unsigned int aLen = strlen(a);
	unsigned int bLen = strlen(b);

	mpf_set_prec(mpf_a, aLen * BITS_PER_DIGIT + 16);
	mpf_set_prec(mpf_b, bLen * BITS_PER_DIGIT + 16);	
	mpf_set_str(mpf_a, a, 10);
	mpf_set_str(mpf_b, b, 10);
	unsigned int digitsChecked;
	unsigned int numberOfFound;

	if(maxTimeMs == 0)
		maxTimeMs = 1000000000;
	unsigned int *result = function.Calculate(&length, stringNumber, numberOfDigitsToCheck, mpf_a, mpf_b, aLen, bLen, &numberOfFound, &digitsChecked, maxTimeMs);
	/*if(digitsChecked == 10000)
		printf("Number Of Digits - OK\n");
	else
		printf("Number Of Digits - Wrong\n");*/
	//printf("Found:%d\n", numberOfFound);
	delete[] stringNumber;
	if(filename)
		file.SaveWARFUN(result, length, mpf_a, filename);
	delete[] result;
	mpf_clear(mpf_a);
	mpf_clear(mpf_b);
	
}

void __stdcall generateNewPi(int d, int alg, Listener listener) {
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
	saveState();

	mpf_mul_2exp (a2, a2, 1);
	my_div (a2, a2, sum);

	//saveMpf(a2, "pi.p", 10);	
	
	// Testy BIGNUMa
	File file;
	/*mpf_t newPi;	
	mpf_init(newPi);
	file.SaveBIGNUM(a2, L"pi.BIGNUM");
	file.LoadBIGNUM(newPi, L"pi.BIGNUM");
	file.SaveBIGNUM(newPi, L"pi2.BIGNUM");*/

	Function function;
	unsigned int length;
	mp_exp_t exp;
	char *stringNumber = mpf_get_str(NULL, &exp, 10, 0, a2);	

	/*
	mpf_t a, b;
	mpf_init(a);
	mpf_init(b);
	char strA[] = "3";
	char strB[] = "3141";
	mpf_set_prec(a, 10000);
	mpf_set_prec(b, 10000);
	mpf_set_str(a, strA, 10);
	mpf_set_str(b, strB, 10);
	unsigned int digitsChecked;
	unsigned int numberOfFound;
	unsigned int *result = function.Calculate(&length, stringNumber, 1000, a, b, strlen(strA), strlen(strB), &numberOfFound, &digitsChecked);
	/*if(digitsChecked == 10000)
		printf("Number Of Digits - OK\n");
	else
		printf("Number Of Digits - Wrong\n");*/
	/*
	printf("Found:%d\n", numberOfFound);
	delete[] stringNumber;
	file.SaveWARFUN(result, length, a, L"pi.warfun");
	delete[] result;
	mpf_clear(a);
	mpf_clear(b);*/
	//unsigned int *result2;
	//file.LoadWARFUN(&result2, &length, a, L"pi.warfun");
	//file.SaveWARFUN(result2, length, a, L"pi2.warfun");
	

	FILE *fa = fopen("pi.p", "w");
	gmp_fprintf(fa, "%.*Ff", _digits, a2);
	fclose(fa);

	clearAll();
}
