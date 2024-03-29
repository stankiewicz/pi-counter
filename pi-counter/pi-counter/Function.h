#ifndef _FUNCTION_H_
#define _FUNCTION_H_

#include "gmp.h"
#include "PiGenerator.h"

class Function
{
public:
	unsigned int *Calculate(CoolListener listener, unsigned __int64 *resultLength, char *pi, int checkNumberOfDigits, mpf_t a, mpf_t b, int lengthA, int lengthB, unsigned __int64 *numberOfFound, unsigned int *digitsChecked, int maxTimeMs = 1000000000, unsigned int firstIndex = 1);
private:

};

#endif