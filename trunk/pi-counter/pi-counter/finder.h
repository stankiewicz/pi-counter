#pragma once

typedef void (__stdcall *LISTENER) (long, long);

extern "C" __declspec(dllexport) long __stdcall findNumber1(char * number);
extern "C" __declspec(dllexport) void __stdcall findNumbersFT(char * from, char * to,long  out [], LISTENER listener);
extern "C" __declspec(dllexport) void __stdcall findNumbers2(char * numbers [],int count,long  out [],LISTENER listener);
