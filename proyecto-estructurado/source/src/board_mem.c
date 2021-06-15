#include <board_basics.h>
#include <board_mem.h>
#include <stdio.h>
#include <stdlib.h>

const unsigned int board_len = 8;

Board *board;

void init_board() {
	board = (Board *)malloc(sizeof(Board));
	board->dimension = board_len;
	board->field = (int **)malloc(sizeof(int *) * board_len);
	for (unsigned int i = 0; i < board_len; i++) {
		board->field[i] = (int *)malloc(sizeof(int) * board_len);
		for (unsigned int j = 0; j < board_len; j++) {
			board->field[i][j] = 0;
		}
	}
}
void free_board() {
	for (unsigned int i = 0; i < board_len; i++) {
		free(board->field[i]);
	}
	free(board->field);
	free(board);
}

int get_board_dimension() { return board_len; }
Board *get_board() {
	if (!board) {
		init_board();
	}
	return board;
}
