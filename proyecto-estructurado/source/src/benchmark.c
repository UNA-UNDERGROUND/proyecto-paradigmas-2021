#include <benchmark.h>
#include <macro_utils.h>
#include <stdio.h>
#include <time.h>

void init_benchmark(bench_timer *timer) {
	// time(&(timer->start_t));
	timer->init_t = clock();
}

void stop_benchmark(bench_timer *timer) {
	timer->stop_t = clock();
	timer->result_t = (double)(timer->stop_t - timer->init_t);
	// time(&(timer->end_t));
	// timer->result_t = difftime(timer->end_t, timer->start_t);
}