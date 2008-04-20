#ifndef _FUNCTION_H_
#define _FUNCTION_H_

#include "gmp.h"
class Function
{
public:
	unsigned int *Calculate(unsigned int *resultLength, char *pi, int checkNumberOfDigits, mpf_t a, mpf_t b, int lengthA, int lengthB, unsigned int *numberOfFound, unsigned int *digitsChecked, unsigned int firstIndex = 1);
private:

};

#endif