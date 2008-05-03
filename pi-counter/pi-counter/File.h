#ifndef _FILE_H_
#define _FILE_H_

#include "gmp.h"

#define NUMBER_OF_VALUES_PER_FILE 1000000
#define NUMBER_OD_BYTES_PER_FILE 50000000

class File
{
public:
	bool SaveBIGNUM(mpf_ptr value, wchar_t *filename, int numberOfDigits = 0);
	bool LoadBIGNUM(mpf_ptr value, char **piString, wchar_t *    filename);
	bool SaveWARFUN(unsigned int *result, unsigned int length, mpf_ptr a,wchar_t *filename);
	bool LoadWARFUN(unsigned int **result, unsigned int *length, mpf_ptr a, wchar_t *filename);
private:	
	
};

#endif