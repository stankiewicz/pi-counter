#include "Function.h"
#include <windows.h>

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