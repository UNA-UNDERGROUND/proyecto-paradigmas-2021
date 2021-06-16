#include <benchmark.h>
#include <board_basics.h>
#include <board_graphics.h>
#include <board_mem.h>
#include <flags_util.h>
#include <stdio.h>

const int max_solutions = 1;

// las 8 direcciones del caballo
typedef enum Direction {
	LEFT_UP,    // ROW- col+
	UP_LEFT,    // row- COL+
	UP_RIGHT,   // row+ COL+
	RIGHT_UP,   // ROW+ col+
	RIGHT_DOWN, // ROW+ col-
	DOWN_RIGHT, // row+ COL-
	DOWN_LEFT,  // row- COL-
	LEFT_DOWN   // ROW- col-
} Direction;

static Move movements[] = {
    {-2, +1}, // LEFT_UP	ROW- col+
    {-1, +2}, // UP_LEFT	row- COL+
    {+1, +2}, // UP_RIGHT	row+ COL+
    {+2, +1}, // RIGHT_UP	ROW+ col+
    {+2, -1}, // RIGHT_DOWN	ROW+ col-
    {+1, -2}, // DOWN_RIGHT	row+ COL-
    {-1, -2}, // DOWN_LEFT	row- COL-
    {-2, -1}  // LEFT_DOWN	ROW- col-
};

static int numSoluciones, totSoluciones;

int is_board_field_free(Move *pos, Board *board) {
	int len = board->dimension;
	int row = pos->row;
	int col = pos->col;
	if (row < 0 || col < 0 || row >= len || col >= len) {
		return 0;
	}
	return board->field[row][col] == 0;
}

int nextField(Board *board, Move pos, Direction direction, Move *res) {
	Move new_pos = movements[direction];
	new_pos.row += pos.row;
	new_pos.col += pos.col;
	int free = is_board_field_free(&new_pos, board);
	if (free) {
		(*res) = new_pos;
	}
	return free;
}

void saltoCaballoR(Move pos, int salto) {
	Board *board = get_board();
	for (int direction = 0; direction < 8; direction++) {
		Move next_move;
		int res = nextField(board, pos, direction, &next_move);
		if (res) {
			int row = next_move.row;
			int col = next_move.col;
			board->field[row][col] = salto; // anotar
			int dimension = board->dimension * board->dimension;
			if (salto == dimension) { // si ya ha recorrido todo el tablero
				numSoluciones++;
				if (numSoluciones == 1)
					draw_board();
				if((totSoluciones + numSoluciones) >= max_solutions){
					return;
				}
			}
			saltoCaballoR(next_move, salto + 1);
			board->field[row][col] = 0; // se desanota el ultimo movimiento
		}
	}
}

void saltoCaballo(int x, int y) {
	Board *board = get_board();
	bench_timer bench_t;
	totSoluciones = 0;
	for (int direction = 0; direction < 8; direction++) {
		numSoluciones = 0;
		Move initial_field = {x, y};
		Move next_field = {0, 0};
		int res = nextField(board, initial_field, direction, &next_field);
		if (res) {
			int row = next_field.row;
			int col = next_field.col;
			board->field[row][col] = 2; // anotar
			printf("Ensayando en %d:%d\n", row, col);
			if (get_benchmark_level() > 1) {
				init_benchmark(&bench_t);
			}

			saltoCaballoR(next_field, 3);
			if (get_benchmark_level() > 1) {
				stop_benchmark(&bench_t);
				time_t *result_t = &(bench_t.result_t);
				printf("NumSoluciones = %d, ms: %f\n", totSoluciones,
				       (double)(*result_t));
			}
			board->field[row][col] = 0; // se desanota el ultimo movimiento
		}
		totSoluciones += numSoluciones;
		if(totSoluciones >= max_solutions){
			return; 
		}
	}
}

void solve_board(int row, int col) {
	bench_timer bench_t;
	Board *board = get_board();

	board->field[row][col] = 1;
	if (get_benchmark_level() > 0) {
		init_benchmark(&bench_t);
	}
	printf("%d:%d ------------------------------------\n", row, col);
	saltoCaballo(row, col);
	if (get_benchmark_level() > 0) {
		stop_benchmark(&bench_t);
		time_t *result_t = &(bench_t.result_t);
		printf("NumSoluciones = %d, ms: %f\n", totSoluciones,
		       (double)(*result_t));
	}
}