#ifndef _FILE_H_
#define _FILE_H_

#include "gmp.h"
class File
{
public:
	bool SaveBIGNUM(mpf_ptr value, wchar_t *filename, int numberOfDigits = 0);
	bool LoadBIGNUM(mpf_ptr value, wchar_t *filename);
private:	
};

#endif