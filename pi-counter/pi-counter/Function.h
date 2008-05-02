#ifndef _FUNCTION_H_
#define _FUNCTION_H_

#include "gmp.h"
#include "PiGenerator.h"

class Function
{
public:
	unsigned int *Calculate(CoolListener listener, unsigned int *resultLength, char *pi, int checkNumberOfDigits, mpf_t a, mpf_t b, int lengthA, int lengthB, unsigned int *numberOfFound, unsigned int *digitsChecked, int maxTimeMs = 1000000000, unsigned int firstIndex = 1);
private:

};

#endif