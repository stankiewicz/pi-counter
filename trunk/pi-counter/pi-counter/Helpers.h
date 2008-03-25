#pragma once
#include "gmp.h"

#define half(x)     ((x)+1)/2
#define DOUBLE_PREC         53

void my_sqrt (mpf_t r, mpf_t x);
void my_div (mpf_t r, mpf_t y, mpf_t x);
void helpers_init();
