#pragma once
#include <time.h>

typedef struct bench_timer{
    clock_t init_t;
    clock_t stop_t;
    clock_t result_t;
}bench_timer;

void init_benchmark(bench_timer* timer);
void stop_benchmark(bench_timer* timer);

