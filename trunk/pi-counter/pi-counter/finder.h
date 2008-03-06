typedef void ( *LISTENER) (long, long);

extern "C" __declspec(dllexport) long findNumber1(char * number);
extern "C" __declspec(dllexport) void findNumbersFT(char * from, char * to,long  out [], LISTENER listener);
extern "C" __declspec(dllexport) void findNumbers2(char * numbers [],int count,long  out [],LISTENER listener);
