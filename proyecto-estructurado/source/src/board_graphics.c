#include <stdio.h>
#include <board_mem.h>
#include <board_basics.h>

//------------------------------------------------------------------------
void draw_board(void) {
  int len = get_board_dimension();
  Board* board = get_board();
  int i, j;
  printf("---------- SOLUTION ----------\n");
  for (i = 0; i < len; i++) {
    for (j = 0; j < len; j++)
      printf("%2d ", board->field[i][j]);
    printf("\n");
  }
}
