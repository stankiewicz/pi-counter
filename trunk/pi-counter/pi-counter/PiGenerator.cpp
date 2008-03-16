/*
Calculating Pi to arbitrary precision (GNU MP library required)

Gauss-Lagrange'sum (AGM) quadratically converging algorithm:
a[0] = 1
b[0] = 1/sqrt(2)
c[0] = 1
and
a[n+1] = (a[n] + b[n])/2
b[n+1] = sqrt(a[n]*b[n])
c[n]   = a[n]^2 - b[n]^2
n
Then pi = 2*a[n+1]^2 / (1- Sigma(2^k * c[k]^2))
k=0

The iteration can be re-written to use only one squaring and
one square root, as follows.
a[0]   = 1
a2[0]   = 1
b2[0]   = 0.5
sum[0]   = 1
and
c2[n]   = a2[n] - b2[n]
sum[n]   = sum[n-1] - 2^n*c2[n]
b[n]   = sqrt(b2[n])                  <-- square root
a[n+1] = (a[n] + b[n])/2
a2[n+1] = a[n+1]^2                     <-- squaring
b2[n+1] = 2*a2[n+1] - (a2[n]+b2[n])/2
finally
pi = 2*a2[n+1]/sum[n].

One alternative is
a[0]   = 1
a2[0]   = 1
b2[0]   = 0.5
c2[0]   = 0.5
sum[0]   = 1
and
sum[n]   = sum[n-1] - 2^n*c2[n]
b[n]   = sqrt(b2[n])                  <-- square root
a[n+1] = (a[n] + b[n])/2
c2[n+1] = (a[n+1]-b[n])^2              <-- squaring
b2[n+1] = (a2[n]+b2[n])/2 - 2*c2[n+1])
a2[n+1] = b2[n+1] + c2[n+1];
finally
pi = 2*a2[n+1]/sum[n].

Another form of iteration uses only one multiplicaiton and
one square root, show as follows.
a2[0]   = 1
b2[0]   = 0.5
sum[0]   = 1
and
c2[n]   = a2[n] - b2[n];
sum[n]   = sum[n-1] - 2^n*c2[n]
b2[n+1] = sqrt(a2[n]*b2[n])            <-- all here
a2[n+1] = (a2[n] + b2[n] + 2*b2[n+1])/4
finally
pi = 2*a2[n+1]/sum[n].

The square root of A is calculated by the following quadratically
converging iterations,
x[n+1] = x[n] + x[n]*(1-A*x[n]^2)/2
and the last iteration is
x[n+1] = (A*x[n]) + x[n]*(A-(A*x[n])^2)/2.
No full precision multiplication is involved.

There is a similar algorithm for division B/A:
x[n+1] = x[n] + x[n]*(1-A*x_n)
and the last iteration is
x[n+1] = (B*x[n]) + x[n]*(B-A*(B*x_n)).
Only one full precision multiplication is necessary.

Estimate computation cost:
add/sub/shift  = 0
square         = 2
multiplication = 3
square root    = 7
division       = 8
*/

#include "PiGenerator.h"
//#include <assert.h>
#include <iostream>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include "gmp.h"

using namespace std;

#define DOUBLE_PREC         53
#define BITS_PER_DIGIT   3.32192809488736234787

#define show(x)      {printf(#x"="); mpf_out_str(stdout, 10, 0, x); printf("\n");}
#define abs(x)      ((x)>0?(x):(-x))
#define half(x)     ((x)+1)/2

int prec0;			/* require precision */
/* used for pi generation */
mpf_t a, b, a2, b2, c2, sum;
/* used for sqrt and div */
mpf_t t0, t1, t2;

int _digits, _alg, _count, _prec;

void my_sqrt (mpf_t r, mpf_t x) {
	unsigned prec, bits;

	if (prec0 <= DOUBLE_PREC) {
		mpf_set_d (r, sqrt (mpf_get_d (x)));
		return;
	}

	bits = 0;
	for (prec = prec0; prec > DOUBLE_PREC;) {
		int bit = prec & 1;
		prec = (prec + bit) / 2;
		bits = bits * 2 + bit;
	}

	mpf_set_prec_raw (t1, DOUBLE_PREC);
	mpf_set_d (t1, 1 / sqrt (mpf_get_d (x)));

	while (prec < prec0) {
		prec *= 2;
		/*printf("prec=%d, prec0=%d\n", prec, prec0); */
		if (prec < prec0) {
			/* t1 = t1+t1*(1-x*t1*t1)/2; */
			mpf_set_prec_raw (t2, prec);
			mpf_mul (t2, t1, t1);
			mpf_set_prec_raw (x, prec / 2);
			mpf_mul (t2, t2, x);
			mpf_ui_sub (t2, 1, t2);
			mpf_set_prec_raw (t2, prec / 2);
			mpf_div_2exp (t2, t2, 1);
			mpf_mul (t2, t2, t1);
			mpf_set_prec_raw (t1, prec);
			mpf_add (t1, t1, t2);
		} else {
			prec = prec0;
			/* t2=x*t1, t1 = t2+t1*(x-t2*t2)/2; */
			mpf_set_prec_raw (t2, prec / 2);
			mpf_set_prec_raw (x, prec / 2);
			mpf_mul (t2, t1, x);
			mpf_mul (t0, t2, t2);
			mpf_set_prec_raw (x, prec);
			mpf_sub (t0, x, t0);
			mpf_mul (t1, t1, t0);
			mpf_div_2exp (t1, t1, 1);
			mpf_add (r, t1, t2);
			break;
		}
		prec -= (bits & 1);
		bits /= 2;
	}
}

void my_div (mpf_t r, mpf_t y, mpf_t x) {
	unsigned prec, bits;

	if (prec0 <= DOUBLE_PREC) {
		mpf_set_d (r, mpf_get_d (y) / mpf_get_d (x));
		return;
	}

	bits = 0;
	for (prec = prec0; prec > DOUBLE_PREC;) {
		int bit = prec & 1;
		prec = (prec + bit) / 2;
		bits = bits * 2 + bit;
	}

	mpf_set_prec_raw (t1, prec);
	mpf_set_d (t1, 1 / mpf_get_d (x));

	while (prec < prec0) {
		prec *= 2;
		/*printf("prec=%d, prec0=%d\n", prec, prec0); */
		if (prec < prec0)
		{
			/* t1 = t1+t1*(1-x*t1); */
			mpf_set_prec_raw (t2, prec);
			mpf_set_prec_raw (x, prec / 2);
			mpf_mul (t2, t1, x);
			mpf_ui_sub (t2, 1, t2);
			mpf_set_prec_raw (t2, prec / 2);
			mpf_mul (t2, t2, t1);
			mpf_set_prec_raw (t1, prec);
			mpf_add (t1, t1, t2);
		} else {
			prec = prec0;
			/* t2=y*t1, t1 = t2+t1*(y-x*t2); */
			mpf_set_prec_raw (t2, prec / 2);
			mpf_mul (t2, t1, y);
			mpf_mul (t0, t2, x);
			mpf_sub (t0, y, t0);
			mpf_mul (t1, t1, t0);
			mpf_add (r, t1, t2);
			break;
		}
		prec -= (bits & 1);
		bits /= 2;
	}
}

//void main (int argc, char *argv[])
//{
//	int d, count, prec, alg = 0, out = 0;
//	clock_t begin, mid1, mid2, end;
//	clock_t u, v, prof[10];
//
//	memset (prof, 0, sizeof (prof));
//
//	if (argc < 2)
//	{
//		printf ("%s  #digits [algorithm] [output]\n"
//			"\talgorithm=0, one squring and one squre root, subtraction version\n"
//			"\t          1, one squring and one squre root, addition version\n"
//			"\t          2, one multiplication and one squre root\n"
//			"\t   output=0, no output\n"
//			"\t          1, output to stdout\n", argv[0]);
//		exit (1);
//	}
//	d = atoi (argv[1]);
//	if (argc >= 3)
//		alg = atoi (argv[2]);
//	if (argc >= 4)
//		out = atoi (argv[3]);
//
//	prec0 = d * BITS_PER_DIGIT + 16;
//
//	begin = clock ();
//
//	mpf_set_default_prec (prec0);
//	mpf_init (a);
//	mpf_init (b);
//	mpf_init (a2);
//	mpf_init (b2);
//	mpf_init (c2);
//	mpf_init (sum);
//	mpf_init (t0);
//	mpf_init2 (t1, half (prec0));
//	mpf_init2 (t2, half (prec0));
//
//	mpf_set_ui (a, 1);
//	mpf_set_ui (a2, 1);
//	mpf_set_d (b2, 0.5);
//	mpf_set_d (c2, 0.5);
//	mpf_set_ui (sum, 1);
//
//	mid1 = clock ();
//
//	for (count = 0, prec = -1; prec < prec0 * 2 + 10;
//		count++, prec = prec * 2 + 10)
//	{
//		printf (".");
//		fflush (stdout);
//
//		u = clock ();
//		if (alg != 1)
//		{
//			/*   c2   = a2 - b2; */
//			mpf_sub (c2, a2, b2);
//		}
//		/*   sum -= (1<<n)*c2; */
//		mpf_mul_2exp (c2, c2, count);
//		mpf_sub (sum, sum, c2);
//		v = clock ();
//		prof[0] += v - u;
//
//		if (alg == 0)
//		{
//			/*  b    = sqrt(b2); */
//			my_sqrt (b, b2);
//			u = clock ();
//			prof[1] += u - v;
//			/*  a    = (a+b)/2; */
//			mpf_add (a, a, b);
//			mpf_div_2exp (a, a, 1);
//			/*  c2   = (a-b)*(a-b); */
//			mpf_sub (c2, a, b);
//			v = clock ();
//			prof[2] += v - u;
//			mpf_mul (c2, c2, c2);
//			u = clock ();
//			prof[3] += u - v;
//			/*  b2   = ((a2+b2)/4-c2)*2; */
//			mpf_add (b2, b2, a2);
//			mpf_div_2exp (b2, b2, 2);
//			mpf_sub (b2, b2, c2);
//			mpf_mul_2exp (b2, b2, 1);
//			/*  a2   = b2+c2; */
//			mpf_add (a2, b2, c2);
//			v = clock ();
//			prof[4] += v - u;
//		}
//		else if (alg == 1)
//		{
//			/*  b    = sqrt(b2); */
//			my_sqrt (c2, b2);
//			u = clock ();
//			prof[1] += u - v;
//			/*  a    = (a + b)/2; */
//			mpf_add (a, a, c2);
//			mpf_div_2exp (a, a, 1);
//			/*  b2   = (a2 + b2)/4; */
//			mpf_add (b2, b2, a2);
//			mpf_div_2exp (b2, b2, 2);
//			v = clock ();
//			prof[2] += v - u;
//			/*  a2   = a*a; */
//			mpf_mul (a2, a, a);
//			u = clock ();
//			prof[3] += u - v;
//			/*  b2   = (a2 - b2)*2; */
//			mpf_sub (b2, a2, b2);
//			mpf_mul_2exp (b2, b2, 1);
//			v = clock ();
//			prof[4] += v - u;
//		}
//		else
//		{
//			/* c2   = a2*b2; */
//			mpf_mul (c2, a2, b2);
//			u = clock ();
//			prof[1] += u - v;
//			/* a2   = (a2+b2)/2; */
//			mpf_add (a2, a2, b2);
//			mpf_div_2exp (a2, a2, 1);
//			v = clock ();
//			prof[2] += v - u;
//			/* b2   = sqrt(c2); */
//			my_sqrt (b2, c2);
//			u = clock ();
//			prof[3] += u - v;
//			/* a2   = (a2+b2)/2; */
//			mpf_add (a2, a2, b2);
//			mpf_div_2exp (a2, a2, 1);
//			v = clock ();
//			prof[4] += v - u;
//		}
//	}
//	mid2 = clock ();
//	mpf_mul_2exp (a2, a2, 1);
//	my_div (a2, a2, sum);
//	u = clock ();
//	prof[5] += u - v;
//
//	end = clock ();
//
//	printf ("Done\n");
//	printf ("Computation time=%f\n", (end - begin) / (double) CLOCKS_PER_SEC);
//	printf ("\tInitialization time=%f\n",
//		(mid1 - begin) / (double) CLOCKS_PER_SEC);
//	printf ("\t%d iterations' time=%f (avg=%f)\n", count,
//		(mid2 - mid1) / (double) CLOCKS_PER_SEC,
//		(mid2 - mid1) / (double) CLOCKS_PER_SEC / count);
//	for (u = 0; u < 4; u++)
//		printf ("\t\tStep %d time=%f (avg=%f)\n", u,
//		prof[u] / (double) CLOCKS_PER_SEC,
//		prof[u] / (double) CLOCKS_PER_SEC / count);
//	printf ("\tFinal division time=%f\n", prof[5] / (double) CLOCKS_PER_SEC);
//	if (out)
//	{
//		mpf_out_str (stdout, 10, d + 2, a2);
//		printf("\n##### count = %d \n",d);
//		mpf_t val;
//		mpf_init(val);
//
//		mpf_set(val,a2);
//		mpf_t potega, ten;
//		mpf_init(potega);
//		mpf_init(ten);
//		mpf_set_si(potega,1);
//		mpf_set_si(ten,10);
//		for(int i = 0;i<=d;++i){
//			mpf_mul(potega,potega,ten);
//		}
//		mpf_mul(val,val,potega);
//		mpz_t ret;
//		mpz_init(ret);
//		mpz_set_f(ret,val);
//		mpz_out_str(stdout,10,ret);
//		//gmp_printf("test %Ff\n",a2);
//		printf ("\n");
//	}
//	printf ("Total time=%f\n", (clock () - begin) / (double) CLOCKS_PER_SEC);
//}

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
	mpf_clear (t0);
	mpf_init (t0);

	mpf_clear (t1);
	mpf_init2 (t1, half (prec0));
	mpf_clear (t2);
	mpf_init2 (t2, half (prec0));
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

		tempCounter++;
		if (tempCounter == 2) {
			return false;
		}
	}

	if (listener != 0) {
		(*listener)();
	}

	return true;
}

void saveMpf(mpf_t var, const char * filename, int base) {
	FILE *fa = fopen(filename, "w");
	fwrite(&var->_mp_exp, sizeof(var->_mp_exp), 1, fa);
	fwrite(&var->_mp_prec, sizeof(var->_mp_prec), 1, fa);
	fwrite(&var->_mp_size, sizeof(var->_mp_size), 1, fa);
		
	for(unsigned int i = 0; i < var->_mp_prec; i++)
	{
		fseek(fa, 12 + sizeof(*var->_mp_d) * i, SEEK_SET);
		fwrite(var->_mp_d + i, sizeof(*var->_mp_d), 1, fa);	
	}
	//gmp_fprintf(fa, "%.*Ff", _digits + 100, var);
	fclose(fa);
}

void saveMpf(mpf_t var, const char * filename) {
	saveMpf(var, filename, 2);
}

void saveState() {
	FILE *output = fopen("savedState", "w");
	fprintf(output, "%d %d %d %d", _digits, _alg, _count, _prec);
	fclose(output);

	saveMpf(a, "a");
	saveMpf(b, "b");
	saveMpf(a2, "a2");
	saveMpf(b2, "b2");
	saveMpf(c2, "c2");
	saveMpf(sum, "sum");
}

void readMpf(mpf_t var, const char *filename) 
{
	mpf_clear(var);
	FILE *fa = fopen(filename, "r");
	//gmp_fscanf(fa, "%Ff", var);
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
}

void readState() {
	FILE *input = fopen("savedState", "r");
	fscanf(input, "%d %d %d %d", &_digits, &_alg, &_count, &_prec);
	fclose(input);

	setPrecision();
	init();

	readMpf(a, "a");
	readMpf(b, "b");
	readMpf(a2, "a2");
	readMpf(b2, "b2");
	readMpf(c2, "c2");
	readMpf(sum, "sum");	
}

bool testSingle(mpf_t src, char *file) {
	mpf_t temp;
	mpf_init(temp);

	mpf_set(temp, src);
	saveMpf(temp, file);
	mpf_clear(temp);
	mpf_init(temp);
	readMpf(temp, file);
	int res = mpf_cmp(temp, src);
	if (!res) {
		printf("\n\tNie dzia³a: %s", file);
	}
	return res;
}

bool test() {
	return testSingle(a, "atest")
		&& testSingle(b, "btest")
		&& testSingle(a2, "a2test")
		&& testSingle(b2, "b2test")
		&& testSingle(c2, "c2test")
		&& testSingle(sum, "sumtest");
}

void __stdcall generateNewPi(int d, int alg, Listener listener) 
{
	/*mpf_clear(a);
	mpf_init (a);
	mpf_set_str(a, "123456789011",10);//456789011223344556677889900111222333444555666777888999000", 10);
	unsigned long aa[4];
	for(int i = 0; i < a->_mp_size; i++)
		aa[i] = a->_mp_d[i];
*/
	_count = 0;
	_prec = -1;
	_alg = alg;
	_digits = d;

	setPrecision();
	init();

	setStartValues();
	
	char f[256];
	int i = 0;
	mpf_t sum6;
	mpf_init(sum6);

	while (!generate(listener)) {
		/*if (i == 6) {
			mpf_set(sum6, sum);
		} else if (i == 7) {
			printf("sum6==sum7: %d", mpf_cmp(sum6, sum));
			saveMpf(sum6, "sum6");
			saveMpf(sum, "sum7");
		}

		printf("prec: %d\tsize:%d\texp:%d", sum->_mp_prec, sum->_mp_size, sum->_mp_exp);
		sprintf(f, "elo %d", i);
		saveMpf(sum, f);

		if (!test()) {
			printf("failed: %d", i);
		}
*/
		saveState();
		readState();
/*		printf("\nnext\n");
		i++;*/
	}

	mpf_mul_2exp (a2, a2, 1);
	my_div (a2, a2, sum);

	FILE *fa1 = fopen("pi1.txt", "w");	
	gmp_fprintf(fa1, "%.*Ff", _digits + 100, a2);
	fclose(fa1);
	saveMpf(a2, "pi.p", 10);
	//mpf_clear(a2);
	//mpf_init(a2);
	readMpf(a2, "pi.p");
	saveMpf(a2, "pi.p2", 10);
	//mpf_clear(a2);

	FILE *fa2 = fopen("pi2.txt", "w");	
	gmp_fprintf(fa2, "%.*Ff", _digits + 100, a2);
	fclose(fa2);


}
