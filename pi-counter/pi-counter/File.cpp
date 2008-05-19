#include "gmp.h"
#include "File.h"
#include "string.h"
#include <stdio.h>
#include <fstream>
#include <stdio.h>

using namespace std;

#define BITS_PER_DIGIT   3.32192809488736234787

bool File::LoadBIGNUM(mpf_ptr value, char **piString, wchar_t *filename)
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
		if(piString)
		{
			*piString = new char[1];
			**piString = 0;
		}
		else
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
	

	if(piString)
	{
		int kr = 0;
		for(i = 0; i < totalBytes; i++)
		{
			if(data[i + 1] == '.')
				kr = 1;
			data[i] = data[i + 1 + kr];
		}
		*piString = data;
	}
	else
	{
		mpf_set_prec(value, totalBytes * BITS_PER_DIGIT + 16);
		if(data[0] == '+')
			mpf_set_str(value, data + 1, 10);	
		else
			mpf_set_str(value, data, 10);	
		delete[] data;
	}
				
	delete[] dataFileName;	
	return true;
}

bool File::SaveBIGNUM(mpf_ptr value, int base, wchar_t *filename, int numberOfDigits)
{	
	mp_exp_t exp;
	char *stringNumber = mpf_get_str(NULL, &exp, base, numberOfDigits, value);	
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
		out<<' ';
		out<<exp;
		out<<' ';
		if((stringNumber[0] == '-') || (stringNumber[0] == '+'))
			out<<digits - exp - 1;
		else
			out<<digits - exp;
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

bool File::SaveWARFUN(unsigned int *result, unsigned int length, mpf_ptr a,wchar_t *filename, unsigned int piLength)
{
	unsigned int numberOfFiles = (length + NUMBER_OF_VALUES_PER_FILE - 1) / NUMBER_OF_VALUES_PER_FILE;
	ofstream out;
	try
	{
		out.open(filename);
		out<<numberOfFiles << ' ' << piLength;		
		out.close();
	}
	catch(...)
	{		
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
		
	mpf_t currentValue;
	mpf_init(currentValue);
	mpf_set_prec(currentValue, mpf_get_prec(a) + 10);
	mpf_set(currentValue, a);
	char *stringNumber;
	unsigned int currentIndex = 0;
	for(i = 0; i < numberOfFiles; i++)
	{
		swprintf(dataFileName + filenameLength, L"%.5i", i);	
		try
		{
			out.open(dataFileName);
			mp_exp_t exp;
			stringNumber = mpf_get_str(NULL, &exp, 10, 0, currentValue);			
			if(stringNumber == 0)
			{
				stringNumber = new char[2];
				stringNumber[0] = '0';
				stringNumber[1] = 0;
			}
			else if(stringNumber[0] == 0)
			{
				exp = 1;
			}

			mpf_add_ui(currentValue, currentValue, NUMBER_OF_VALUES_PER_FILE);
			out<<stringNumber;
			for(int j = 0; j < exp - strlen(stringNumber); j++)
				out<<'0';
			out<<';';
			delete[] stringNumber;
			if(length > NUMBER_OF_VALUES_PER_FILE)			
				out << NUMBER_OF_VALUES_PER_FILE << ';';							
			else			
				out << length << ';';							

			for(int j = 0; (j < NUMBER_OF_VALUES_PER_FILE - 1) && (j < length - 1); j++)
			{
				if(result[currentIndex])
					out << result[currentIndex] << ',';							
				else
					out<< ',';
				currentIndex++;
			}
			length -= NUMBER_OF_VALUES_PER_FILE;
			if(result[currentIndex])
				out << result[currentIndex];					
			currentIndex++;
			out.close();
		}
		catch(...)
		{
			delete[] dataFileName;	
			mpf_clear(currentValue);
			return false;
		}		
	}	
	delete[] dataFileName;
	mpf_clear(currentValue);
	return true;
}

bool File::LoadWARFUN(unsigned int **result, unsigned int *length, mpf_ptr a, wchar_t *filename)
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
		return true;

	int filenameLength = wcslen(filename);
	wchar_t *dataFileName = new wchar_t[filenameLength + 6];
	int i;
	for(i = 0; i < filenameLength; i++)
		dataFileName[i] = filename[i];
	
	for(i = 0; i < 5; i++)
		dataFileName[filenameLength + i] = '0';
	dataFileName[filenameLength + i] = 0;
	
	swprintf(dataFileName + filenameLength, L"%.5i", numberOfFiles - 1);	
	//*length = 5;
	
	FILE *file = _wfopen(dataFileName, L"r");
	if(file == NULL)
	{
		delete[] dataFileName;
		return false;
	}	
	fscanf(file, "%d;%d", &i, length);	
	fclose(file);	
	*length += NUMBER_OF_VALUES_PER_FILE * (numberOfFiles - 1);
	*result = new unsigned int[*length];
	int fileLength;
	char* stringNumber;
	int lengthA = 0;
	char c;
	int currentIndex = 0;
	for(i = 0; i < numberOfFiles; i++)
	{
		swprintf(dataFileName + filenameLength, L"%.5i", i);	
			
		file = _wfopen(dataFileName, L"r");
		if(file == NULL)
		{
			delete[] dataFileName;			
			return false;
		}
		if(i == 0)
		{
			lengthA = 0;
			while(1)
			{
				fread(&c, 1, 1, file);
				if(c == ';')
					break;
				lengthA++;
			}
			fseek(file, 0, SEEK_SET);
			stringNumber = new char[lengthA + 1];			
			fread(stringNumber, 1, lengthA + 1, file);
			stringNumber[lengthA] = 0;			
			mpf_set_prec(a, lengthA * BITS_PER_DIGIT + 16);
			mpf_set_str(a, stringNumber, 10);
			delete[] stringNumber;
		}
		else
		{
			while(1)
			{
				fread(&c, 1, 1, file);
				if(c == ';')
					break;				
			}
		}

		fscanf(file, "%d;", &fileLength);
		for(int j = 0; j < fileLength; j++)
		{
			fscanf(file, "%d", *result + currentIndex);
			if(j < fileLength)
				fseek(file, 1, SEEK_CUR);
			currentIndex++;
		}

		fclose(file);
	}
	delete[] dataFileName;
	return true;
}