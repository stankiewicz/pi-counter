// pi-counter-test.cpp : Defines the entry point for the console application.
//
#include <stdio.h>
#include <stdlib.h>

#include "gmp.h"

int test()
{
	mpf_t l1, l2,l3;
	mpf_init(l1);
	mpf_init(l2);
	mpf_init(l3);
	char * l1str = "0.00000000000000000000000000000000000000000000100";
	char * l2str = "0.0000000000000000000000000000000000000000000000300";
	mpf_set_str(l1,l1str,10);
	mpf_set_str(l2,l2str,10);
	
	mpf_out_str(stdout,10,32,l1);
	printf("\n");
	mpf_out_str(stdout,10,32,l2);
	mpf_mul(l3,l1,l2);
	printf("\n");
	mpf_out_str(stdout,10,32,l3);
	return 0;
}

