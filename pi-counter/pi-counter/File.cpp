#include "gmp.h"
#include "File.h"
#include "string.h"
#include <iostream>
#include <fstream>

using namespace std;

bool File::LoadBIGNUM(mpf_ptr value, wchar_t *filename)
{
	
	return false;
}

bool File::SaveBIGNUM(mpf_ptr value, wchar_t *filename)
{	
	#define NUMBER_OD_BYTES_PER_FILE 50000000
	mp_exp_t exp;
	char *stringNumber = mpf_get_str(NULL, &exp, 10, 0, value);	
	char *string = stringNumber;
	size_t digits = strlen(stringNumber);
	int numberOfFiles = digits + 1;
	if(exp < digits) //mamy kropkê
		numberOfFiles++;
	numberOfFiles = 1 + ((numberOfFiles + 1) / NUMBER_OD_BYTES_PER_FILE);

	ofstream out;
	try
	{
		out.open(filename);
		out<<numberOfFiles;
		out.close();
	}
	catch(...)
	{
		delete[] stringNumber;
		return false;
	}	

	int filenameLength = wcslen(filename);
	wchar_t *dataFileName = new wchar_t[filenameLength + 6];
	int i;
	for(i = 0; i < filenameLength; i++)
		dataFileName[i] = filename[i];
	
	for(i = 0; i < 5; i++)
		dataFileName[filenameLength + i] = '0';
	dataFileName[filenameLength + i] = 0;
	
	char sign = '+';
	if(stringNumber[0] == '-')
	{
		sign = '-';
		string++;
	}
	int currentDigit = 0;
	bool wroteDot = false;
	for(i = 0; i < numberOfFiles; i++)
	{
		swprintf(dataFileName + filenameLength, L"%.5i", i);	
		try
		{
			out.open(dataFileName);
			for(int j = 0; j < NUMBER_OD_BYTES_PER_FILE; j++)
			{
				if((i == 0) && (j == 0))
				{
					out<<sign;
					continue;
				}
				if ((currentDigit == exp) && (!wroteDot))				
				{
					out<<'.';
					wroteDot = true;
				}
				else
				{
					out<<string[currentDigit];
					currentDigit++;
				}	
				if(currentDigit >= digits)
					break;
			}
			out.close();
		}
		catch(...)
		{
			delete[] dataFileName;
			delete[] stringNumber;
			return false;
		}		
	}	
	delete[] dataFileName;
	delete[] stringNumber;
	return true;
}

