#include "Function.h"
#include <windows.h>
#include "PiGenerator.h"
#include "File.h"
#include "gmp.h"

#include <fstream>
#include <stdio.h>
#include <Objbase.h>

using namespace std;

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

void GetResultValues(char **arguments, unsigned int *values, wchar_t *fileName, unsigned __int64 offset, unsigned int numberOfValuesToMaintain);
void CleanAfterGettingResultValues(void);

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
		file.SaveWARFUN(result, *resultLength, mpf_a, resultFileName, *digitsChecked);
	delete[] result;
	mpf_clear(mpf_a);
	mpf_clear(mpf_b);


	/*char **arguments;
	unsigned int *values;
	GetResultValues(&arguments, &values, resultFileName, 999995, 10);
	CleanAfterGettingResultValues();*/
}

char* ConvertToString(mpf_ptr mpf, unsigned int addValue)
{
	mpf_t temp;
	mpf_init(temp);

	mpf_set_prec(temp, mpf_get_prec(mpf) + 5);
	mpf_add_ui(temp, mpf, addValue);
	mp_exp_t exp;
	char *string = mpf_get_str(NULL, &exp, 10, 0, temp);
	mpf_clear(temp);
	if(string[0] == 0)
		exp = 1;
	unsigned int stringLength = strlen(string);
	if(exp <= stringLength)
		return string;
	char *s = new char[1 + exp];
	int i;
	for(i = 0; i < exp + 1; i++)
		s[i] = 0;
	for(i = 0; i < stringLength; i++)
		s[i] = string[i];
	for(;i < exp; i++)
		s[i] = '0';	
	delete[] string;
	return s;
}

/*
unsigned int **g_values;
char ***g_arguments;
int g_numberOfValuesToMaintain;
*/

void GetResultValues(char **arguments, unsigned int *values, wchar_t *fileName, unsigned __int64 offset, unsigned int numberOfValuesToMaintain)
{
	/*
	g_numberOfValuesToMaintain = numberOfValuesToMaintain;
	g_values = values;
	g_arguments = arguments;
	*/

	int numberOfFiles;
	unsigned int length;
	unsigned __int64 totalLength;
	ifstream in;
	try
	{
		in.open(fileName);
		in>>numberOfFiles;
		in.close();
	}
	catch(...)
	{
		/*
		*arguments = NULL;
		*values = NULL;		
		*g_values = NULL;
		*g_arguments = NULL;
		g_numberOfValuesToMaintain = 0;
		*/
		return;
	}
	if(numberOfFiles < 1)			
	{
		/*
		*arguments = NULL;
		*values = NULL;
		*g_values = NULL;
		*g_arguments = NULL;
		g_numberOfValuesToMaintain = 0;
		return;
		*/
	}

	int filenameLength = wcslen(fileName);
	wchar_t *dataFileName = new wchar_t[filenameLength + 6];
	int i;
	for(i = 0; i < filenameLength; i++)
		dataFileName[i] = fileName[i];
	
	for(i = 0; i < 5; i++)
		dataFileName[filenameLength + i] = '0';
	dataFileName[filenameLength + i] = 0;
	
	swprintf(dataFileName + filenameLength, L"%.5i", numberOfFiles - 1);	
	//*length = 5;
	
	FILE *file = _wfopen(dataFileName, L"r");
	if(file == NULL)
	{
		delete[] dataFileName;
		/*
		*arguments = NULL;
		*values = NULL;
		*g_values = NULL;
		*g_arguments = NULL;
		g_numberOfValuesToMaintain = 0;
		*/
		return;
	}	
	fscanf(file, "%d;%u", &i, &length);	
	fclose(file);	
	totalLength = (unsigned __int64)length + (unsigned __int64)NUMBER_OF_VALUES_PER_FILE * (unsigned __int64)(numberOfFiles - 1);
	if (offset > totalLength)
	{
		delete[] dataFileName;
		/*
		*arguments = NULL;
		*values = NULL;
		*g_values = NULL;
		*g_arguments = NULL;
		g_numberOfValuesToMaintain = 0;
		*/
		return;
	}
	//*result = new unsigned int[*length];
	int fileLength;
	char* stringNumber;
	//int lengthA = 0;
	char c;
	//int currentIndex = 0;
	int alredyMaintained = 0;
	unsigned int value;
	

	//*values = new unsigned int[numberOfValuesToMaintain];
	//*arguments = new char* [numberOfValuesToMaintain];
	for(int j = 0; j < numberOfValuesToMaintain; j++)
	{
		values[j] = 0;
		CoTaskMemFree(arguments[j]);		
		//(*arguments)[j] = 0;
	}

	i = offset / NUMBER_OF_VALUES_PER_FILE;
	int startI = i;
	offset -= (unsigned __int64)i * (unsigned __int64)NUMBER_OF_VALUES_PER_FILE;

	mpf_t mpf;
	
	int lengthA;
	//values
	for(;; i++)
	{
		if(i >= numberOfFiles)
			break;
		swprintf(dataFileName + filenameLength, L"%.5i", i);	
			
		file = _wfopen(dataFileName, L"r");
		if(file == NULL)
		{
			delete[] dataFileName;			
			return;
		}
		if(i == startI)
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
			mpf_init(mpf);
			mpf_set_prec(mpf, lengthA * BITS_PER_DIGIT + 16);
			mpf_set_str(mpf, stringNumber, 10);
			delete[] stringNumber;

			//arguments
			char *arg;
			int argLen;
			for(unsigned int j = 0; j < numberOfValuesToMaintain; j++)			
			{
				arg = ConvertToString(mpf, offset + j);
				argLen = strlen(arg);
				*(arguments + j) = (char*)CoTaskMemAlloc(argLen + 1);
				for(int k = 0; k <= argLen; k++)
					(*(arguments + j))[k] = arg[k];
					
			}
			mpf_clear(mpf);
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
			if(j >= offset)
			{
				value = 0;
				fscanf(file, "%d", &value);
				if(j < fileLength)
					fseek(file, 1, SEEK_CUR);
				*(values + alredyMaintained) = value;
				alredyMaintained++;
				if(alredyMaintained >= numberOfValuesToMaintain)
					break;
			}
			else
			{
				while(1)
				{
					fread(&c, 1, 1, file);
					if(c == ',')
						break;
				}
			}
			
			
			/******
			value = 0;
			fscanf(file, "%d", &value);
			if(j < fileLength)
				fseek(file, 1, SEEK_CUR);
			if(j >= offset)
			{
				*(values + alredyMaintained) = value;
				alredyMaintained++;
				if(alredyMaintained >= numberOfValuesToMaintain)
					break;
			}
			//******/
		}
		offset = 0;
		fclose(file);
		if(alredyMaintained >= numberOfValuesToMaintain)
					break;
	}
	delete[] dataFileName;
	return;
}

void CleanAfterGettingResultValues(void)
{
	//delete[] *g_values;
	//for(int i = 0; i < g_numberOfValuesToMaintain; i++)
	//	delete[] *((*g_arguments) + i);
	//delete *g_arguments;
	//*g_arguments = NULL;
	//*g_values = NULL;
	//g_numberOfValuesToMaintain = 0;
}