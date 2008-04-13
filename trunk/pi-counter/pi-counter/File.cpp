#include "gmp.h"
#include "File.h"
#include "string.h"
#include <iostream>
#include <fstream>
#include "stdio.h"

using namespace std;

#define NUMBER_OD_BYTES_PER_FILE 50000000
#define BITS_PER_DIGIT   3.32192809488736234787

bool File::LoadBIGNUM(mpf_ptr value, wchar_t *filename)
{	
	int numberOfFiles;
	ifstream in;
	try
	{
		in.open(filename);
		in>>numberOfFiles;
		in.close();
	}
	catch(...)
	{
		return false;
	}
	if(numberOfFiles < 1)
	{
		mpf_set_str(value, "0", 10);
		return true;
	}
	int exp = 0;
	int totalBytes = 0;
	int filenameLength = wcslen(filename);
	wchar_t *dataFileName = new wchar_t[filenameLength + 6];
	int i;
	for(i = 0; i < filenameLength; i++)
		dataFileName[i] = filename[i];
	
	for(i = 0; i < 5; i++)
		dataFileName[filenameLength + i] = '0';
	dataFileName[filenameLength + i] = 0;
		
	swprintf(dataFileName + filenameLength, L"%.5i", numberOfFiles - 1);	
	FILE *file;
	file = _wfopen(dataFileName, L"r");
	if(file == NULL)
	{
		delete[] dataFileName;
		return false;
	}
	fseek(file, 0, SEEK_END);
	totalBytes = ftell(file);
	fclose(file);
	totalBytes += (numberOfFiles - 1) * NUMBER_OD_BYTES_PER_FILE;
	int bytes = totalBytes;
	char *data = new char[totalBytes + 1];
	data[totalBytes] = 0;
	int readCount;
	for(i = 0; i < numberOfFiles; i++)
	{
		swprintf(dataFileName + filenameLength, L"%.5i", i);	
			
		file = _wfopen(dataFileName, L"r");
		if(file == NULL)
		{
			delete[] dataFileName;
			delete[] data;
			return false;
		}
		if(i < numberOfFiles - 1)	
		{				
			readCount = fread(data + i * NUMBER_OD_BYTES_PER_FILE, 1, NUMBER_OD_BYTES_PER_FILE, file);
			if(readCount != NUMBER_OD_BYTES_PER_FILE)
			{
				delete[] dataFileName;
				delete[] data;
				return false;
			}
			bytes -= NUMBER_OD_BYTES_PER_FILE;
		}
		else			
		{
			readCount = fread(data + i * NUMBER_OD_BYTES_PER_FILE, 1, bytes, file);
			if(readCount != bytes)
			{
				delete[] dataFileName;
				delete[] data;
				return false;
			}
		}
		fclose(file);
	}
	
	mpf_set_prec(value, totalBytes * BITS_PER_DIGIT + 16);
	if(data[0] == '+')
		mpf_set_str(value, data + 1, 10);	
	else
		mpf_set_str(value, data, 10);	
				
	delete[] dataFileName;
	delete[] data;
	return true;
}

bool File::SaveBIGNUM(mpf_ptr value, wchar_t *filename, int numberOfDigits)
{	
	mp_exp_t exp;
	char *stringNumber = mpf_get_str(NULL, &exp, 10, numberOfDigits, value);	
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

