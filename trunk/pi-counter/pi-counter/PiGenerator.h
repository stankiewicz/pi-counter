#pragma once
#include <string>
#include "gmp.h"

using namespace std;
#define CALCFILE1 "arg1"
#define CALCFILE2 "arg2"
#define CALCFILE1OUT "res1"
#define CALCFILE2OUT "res2"
//return value indicates whether to stop calculation
typedef bool (__stdcall *CoolListener) (int timePercentComplete, int lengthPercentComplete);
typedef void (__stdcall *Listener) ();
typedef bool (__stdcall *BoolListener) ();
extern "C" __declspec(dllexport) int add();
extern "C" __declspec(dllexport) int sub();
extern "C" __declspec(dllexport) int mul();
extern "C" __declspec(dllexport) int divDouble();
extern "C" __declspec(dllexport) int equ();
extern "C" __declspec(dllexport) int divInt();
extern "C" __declspec(dllexport) int fancy(unsigned long n);
extern "C" __declspec(dllexport) int mersenne(unsigned long n);
extern "C" __declspec(dllexport) void generatePi(wchar_t *fileName, int digits, int maxTimeMs, CoolListener listener);
extern "C" __declspec(dllexport) void CalculateFunction(CoolListener listener, wchar_t *piFileName, wchar_t *resultFileName, char *a, char *b, int maxTimeMs, unsigned int numberOfDigitsToCheck, unsigned __int64 *numberOfFound, unsigned int *digitsChecked, unsigned __int64 *resultLength);
extern "C" __declspec(dllexport) void CalculateFunctionByPattern(CoolListener listener, wchar_t *piFileName, wchar_t *resultFileName, char *pattern, int maxTimeMs, unsigned int numberOfDigitsToCheck, unsigned __int64 *numberOfFound, unsigned int *digitsChecked, unsigned __int64 *resultLength);
extern "C" __declspec(dllexport) void GetResultValues(char **arguments, unsigned int *values, wchar_t *fileName, unsigned __int64 offset, unsigned int numberOfValuesToMaintain);
extern "C" __declspec(dllexport) void CleanAfterGettingResultValues(void);

bool saveState(int d, int alg, int count, int prec);
int readState(int *d, int *alg, int *count, int *prec);
bool savePi(char* filename);
bool saveMpf(mpf_t var, const char * filename);
bool readMpf(mpf_t var, const char *filename);
