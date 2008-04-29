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
