#include "PiGenerator.h"

extern mpf_t a, b, a2, b2, c2, sum;

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
