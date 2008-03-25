#include "Helpers.h"
#include <math.h>

extern int prec0;
mpf_t t0, t1, t2; /* used for sqrt and div */

void helpers_init() {
	mpf_clear (t0);
	mpf_init (t0);
	mpf_clear (t1);
	mpf_init2 (t1, half (prec0));
	mpf_clear (t2);
	mpf_init2 (t2, half (prec0));
}

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
