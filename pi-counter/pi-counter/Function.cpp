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
	if(value->_mp_size > 1)
		return (unsigned int) -1;
	return value->_mp_d[0];
}
#define BITS_PER_DIGIT   3.32192809488736234787
unsigned int *Function::Calculate(CoolListener listener, unsigned __int64 *resultLength, char *pi, int checkNumberOfDigits, mpf_ptr a, mpf_ptr b, int lengthA, int lengthB, unsigned __int64 *numberOfFound, unsigned int *digitsChecked, int maxTimeMs, unsigned int firstIndex)
{
	int startTime = GetTickCount();
	mpf_t temp, temp2;
	mpf_init(temp);
	mpf_init(temp2);
	mpf_set_prec(temp, lengthB * BITS_PER_DIGIT + 16);
	mpf_set_prec(temp2, lengthB * BITS_PER_DIGIT + 16);
	char c;
	unsigned int currentTime, lastTime = startTime;
	mpf_sub(temp, b, a);
	mpf_add_ui(temp, temp, 1);	
	*numberOfFound = 0;
	*digitsChecked = 0;
	*resultLength = ToInt(temp);
	//to be shure not to allocate too much memory. 
	#define MAXIMUM_NUMBER_OF_RESULTS 250000000
	if(*resultLength > MAXIMUM_NUMBER_OF_RESULTS)
	{		
		/*
		*resultLength = 0;
		mpf_clear(temp);
		mpf_clear(temp2);
		return NULL;
		*/
		
		mpf_set(b, a);		
		mpf_add_ui(b, b, MAXIMUM_NUMBER_OF_RESULTS - 1);
		*resultLength = MAXIMUM_NUMBER_OF_RESULTS;

		mp_exp_t exp;
		char *tempChar = mpf_get_str(NULL, &exp, 10, 0, b);
		lengthB = strlen(tempChar);
		lengthB += exp - lengthB;
		delete[] tempChar;
	}
	unsigned int *result = new unsigned int[*resultLength];
	for(unsigned int k = 0; k < *resultLength; k++)
		result[k] = 0;

	unsigned int j;
	for(j = 0; j < checkNumberOfDigits - lengthB + 1; j++)
	{
		for(unsigned int i = lengthA; i <= lengthB; i++)
		{
			c = pi[j + i];
			pi[j + i] = 0;
			mpf_set_str(temp, pi + j, 10);
			pi[j + i] = c;

			if(mpf_cmp(temp, a) < 0)
				continue;			

			if(i == lengthB)
			{
				if(mpf_cmp(temp, b) > 0)
					break;
			}	
			mpf_sub(temp2, temp, a);
			unsigned int value = ToInt(temp2);
			if(result[value] == 0)
			{
				result[value] = firstIndex + j;
				(*numberOfFound)++;
			}
		}
		*digitsChecked = j + 1;
		
		if((currentTime = GetTickCount()) >= startTime + maxTimeMs)
			break;
		if((*numberOfFound) >= (*resultLength))
			break;
		if(currentTime >= lastTime + 500)
		{
			lastTime = currentTime;
			float fTimePassed = 100.0f * ((float)(currentTime - startTime)) / ((float)(maxTimeMs));
			float fPlacesChecked = 100.0f * ((float)j / (float)(checkNumberOfDigits - lengthB));
			if(listener((int) fTimePassed, (int)fPlacesChecked))
				break;
		}
	}
	mpf_clear(temp);
	mpf_clear(temp2);
	
	currentTime = GetTickCount();
	float fTimePassed = 100.0f * ((float)(currentTime - startTime)) / ((float)(maxTimeMs));
	float fPlacesChecked = 100.0f * ((float)j / (float)(checkNumberOfDigits - lengthB));
	listener((int) fTimePassed, (int)fPlacesChecked);

	return result;
}

void CalculateFunction(CoolListener listener, wchar_t *piFileName, wchar_t *resultFileName, char *a, char *b, int maxTimeMs, unsigned int numberOfDigitsToCheck, unsigned __int64 *numberOfFound, unsigned int *digitsChecked, unsigned __int64 *resultLength)
{
	Function function;
	File file;
	//unsigned int length;
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
	if(!file.LoadBIGNUM(NULL, &pi, piFileName))
		return;

	//unsigned int digitsChecked;
	//unsigned int numberOfFound;

	if(maxTimeMs == 0)
		maxTimeMs = 2000000000;
	unsigned int piLength = strlen(pi);
	if(numberOfDigitsToCheck == 0)
		numberOfDigitsToCheck = piLength;
	else if(numberOfDigitsToCheck > piLength)
		numberOfDigitsToCheck = piLength;
	unsigned int *result = function.Calculate(listener, resultLength, pi, numberOfDigitsToCheck, mpf_a, mpf_b, aLen, bLen, numberOfFound, digitsChecked, maxTimeMs);
	/*if(digitsChecked == 10000)
		printf("Number Of Digits - OK\n");
	else
		printf("Number Of Digits - Wrong\n");*/
	//printf("Found:%d\n", numberOfFound);
	delete[] pi;
	if(resultFileName)
		file.SaveWARFUN(result, *resultLength, mpf_a, resultFileName);
	delete[] result;
	mpf_clear(mpf_a);
	mpf_clear(mpf_b);
}