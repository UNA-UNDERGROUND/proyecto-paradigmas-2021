cmake_minimum_required(VERSION 3.10)
project(tarea_1 VERSION 0.1.0)


set(src_include
	include/benchmark.h
	include/board_graphics.h
	include/board_logic.h
	include/board_mem.h
	include/flags_util.h
	include/macro_utils.h
)

set(src
    ${src_include}
	src/benchmark.c
	src/board_graphics.c
	src/board_logic.c
	src/board_mem.c
	src/flags_util.c
)

add_executable(source ${src} src/source.c)
target_include_directories(source PRIVATE include)
