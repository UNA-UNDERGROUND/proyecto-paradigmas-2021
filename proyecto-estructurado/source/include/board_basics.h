#pragma once
typedef struct Board {
	int dimension;
	int **field;
} Board;

typedef struct Move {
	int col;
	int row;
} Move;
