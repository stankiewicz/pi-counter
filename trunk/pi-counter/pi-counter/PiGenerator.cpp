#include "PiGenerator.h"
#include "Helpers.h"
#include <iostream>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include "gmp.h"

using namespace std;

#define BITS_PER_DIGIT   3.32192809488736234787

#define show(x)      {printf(#x"="); mpf_out_str(stdout, 10, 0, x); printf("\n");}
#define abs(x)      ((x)>0?(x):(-x))

int prec0;			/* require precision */
mpf_t a, b, a2, b2, c2, sum; /* used for pi generation */

int _digits, _alg, _count, _prec;
bool stop = false;

void setPrecision() {
	prec0 = _digits * BITS_PER_DIGIT + 16;
	mpf_set_default_prec (prec0);
}

void init() {
	mpf_clear(a);
	mpf_init (a);

	mpf_clear (b);
	mpf_init (b);
	mpf_clear (a2);
	mpf_init (a2);
	mpf_clear (b2);
	mpf_init (b2);
	mpf_clear (c2);
	mpf_init (c2);
	mpf_clear (sum);
	mpf_init (sum);

	helpers_init();
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

		if (stop) {
			_count++;
			_prec = _prec * 2 + 10;
			return false;
		}
	}

	if (listener != 0) {
		(*listener)();
	}

	return true;
}

bool saveMpf(mpf_t var, const char * filename, int base) {
	FILE *fa = fopen(filename, "w");

	fwrite(&var->_mp_exp, sizeof(var->_mp_exp), 1, fa);
	fwrite(&var->_mp_prec, sizeof(var->_mp_prec), 1, fa);
	fwrite(&var->_mp_size, sizeof(var->_mp_size), 1, fa);
		
	for(unsigned int i = 0; i < var->_mp_prec; i++)
	{
		fseek(fa, 12 + sizeof(*var->_mp_d) * i, SEEK_SET);
		fwrite(var->_mp_d + i, sizeof(*var->_mp_d), 1, fa);
	}

	//gmp_fprintf(fa, "%.*Ff", _digits + 2, var);
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

bool readMpf(mpf_t var, const char *filename) {
	mpf_clear(var);
	FILE *fa = fopen(filename, "r");
	if (fa == 0) {
		return false;
	}
//	gmp_fscanf(fa, "%Ff", var);

	fread(&var->_mp_exp, sizeof(var->_mp_exp), 1, fa);
	fread(&var->_mp_prec, sizeof(var->_mp_prec), 1, fa);
	fread(&var->_mp_size, sizeof(var->_mp_size), 1, fa);
	var->_mp_d = (mp_limb_t*) __gmp_allocate_func((var->_mp_prec + 1) * sizeof(*var->_mp_d));
	unsigned int i;
	for(i = 0; i < var->_mp_prec; i++)
	{
		fseek(fa, 12 + sizeof(*var->_mp_d) * i, SEEK_SET);
		fread(var->_mp_d + i, sizeof(*var->_mp_d), 1, fa);
	}
	var->_mp_d[i] = 0;

	fclose(fa);
	return true;
}

bool readState() {
	int ret;

	FILE *input = fopen("savedState", "r");
	if (input == 0) {
		return false;
	}

	int computedDigits;
	ret = fscanf(input, "%d %d %d %d", &computedDigits, &_alg, &_count, &_prec);
	fclose(input);
	if (ret == EOF) {
		return false;
	}

	if (computedDigits > _digits) {
		_digits = computedDigits;
	}

	setPrecision();
	init();

	if (!readMpf(a, "a") ||
		!readMpf(b, "b") ||
		!readMpf(a2, "a2") ||
		!readMpf(b2, "b2") ||
		!readMpf(c2, "c2") ||
		!readMpf(sum, "sum")) {
			return false;
	}

	return true;
}

void __stdcall generatePi(int d, Listener listener) {
	generateNewPi(d, 0, listener);
}

void __stdcall generateNewPi(int d, int alg, Listener listener) {

	_digits = d;
	if (readState() && _alg == alg) {
		//mo¿na wznowiæ obliczenia
	} else {
		//trzeba zainicjalizowaæ
		_count = 0;
		_prec = -1;
		_alg = alg;

		setPrecision();
		init();

		setStartValues();
	}
	
	bool res = generate(listener);
	saveState();

	mpf_mul_2exp (a2, a2, 1);
	my_div (a2, a2, sum);

	saveMpf(a2, "pi.p", 10);
}
