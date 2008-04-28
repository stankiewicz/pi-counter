#include "Function.h"
#include <windows.h>
#include "PiGenerator.h"
#include "File.h"
#include "gmp.h"

extern mpf_t a2;

unsigned int ToInt(mpf_ptr value)
{
	if(value->_mp_size == 0)
		return 0;
	unsigned int result = value->_mp_d[0];
	return result;
}
#define BITS_PER_DIGIT   3.32192809488736234787
unsigned int *Function::Calculate(unsigned int *resultLength, char *pi, int checkNumberOfDigits, mpf_ptr a, mpf_ptr b, int lengthA, int lengthB, unsigned int *numberOfFound, unsigned int *digitsChecked, int maxTimeMs, unsigned int firstIndex)
{
	int startTime = GetTickCount();
	mpf_t temp;
	mpf_init(temp);
	mpf_set_prec(temp, lengthB * BITS_PER_DIGIT + 16);
	char c;

	mpf_sub(temp, b, a);
	mpf_add_ui(temp, temp, 1);
	*resultLength = ToInt(temp);
	unsigned int *result = new unsigned int[*resultLength];
	for(unsigned int k = 0; k < *resultLength; k++)
		result[k] = 0;

	*numberOfFound = 0;
	for(unsigned int j = 0; j < checkNumberOfDigits - lengthB + 1; j++)
	{
		for(unsigned int i = lengthA; i <= lengthB; i++)
		{
			c = pi[j + i];
			pi[j + i] = 0;
			mpf_set_str(temp, pi + j, 10);
			pi[j + i] = c;
			
			if(i == lengthA)
			{
				if(mpf_cmp(temp, a) < 0)
					continue;
			}
			if(i == lengthB)
			{
				if(mpf_cmp(temp, b) > 0)
					break;
			}	
			mpf_sub(temp, temp, a);
			unsigned int value = ToInt(temp);
			if(result[value] == 0)
			{
				result[value] = firstIndex + j;
				(*numberOfFound)++;
			}
		}
		*digitsChecked = j + 1;
		if(GetTickCount() >= startTime + maxTimeMs)
			break;
	}
	mpf_clear(temp);
	return result;
}

void CalculateFunction(wchar_t *filename, char *a, char *b, int maxTimeMs, unsigned int numberOfDigitsToCheck, CoolListener listener)
{
	Function function;
	File file;
	unsigned int length;
	//mp_exp_t exp;
	//mpf_t pi;
	//mpf_init(pi);
	//char *stringNumber = mpf_get_str(NULL, &exp, 10, 0, a2);
	

	mpf_t mpf_a, mpf_b;
	mpf_init(mpf_a);
	mpf_init(mpf_b);
	
	unsigned int aLen = strlen(a);
	unsigned int bLen = strlen(b);

	mpf_set_prec(mpf_a, aLen * BITS_PER_DIGIT + 16);
	mpf_set_prec(mpf_b, bLen * BITS_PER_DIGIT + 16);	
	mpf_set_str(mpf_a, a, 10);
	mpf_set_str(mpf_b, b, 10);
	if(mpf_cmp(mpf_a, mpf_b) > 0)
	{
		mpf_clear(mpf_a);
		mpf_clear(mpf_b);
		return;
	}

	char *pi;
	file.LoadBIGNUM(NULL, &pi, L"pi.bignum");

	unsigned int digitsChecked;
	unsigned int numberOfFound;

	if(maxTimeMs == 0)
		maxTimeMs = 1000000000;
	
	unsigned int *result = function.Calculate(&length, pi, strlen(pi), mpf_a, mpf_b, aLen, bLen, &numberOfFound, &digitsChecked, maxTimeMs);
	/*if(digitsChecked == 10000)
		printf("Number Of Digits - OK\n");
	else
		printf("Number Of Digits - Wrong\n");*/
	//printf("Found:%d\n", numberOfFound);
	delete[] pi;
	if(filename)
		file.SaveWARFUN(result, length, mpf_a, filename);
	delete[] result;
	mpf_clear(mpf_a);
	mpf_clear(mpf_b);
	
}
