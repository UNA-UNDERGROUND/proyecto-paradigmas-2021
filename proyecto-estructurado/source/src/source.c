
// basado en
// https://www.etsisi.upm.es/sites/default/files/asigs/arquitecturas_avanzadas/practicas/MPI/caballo.pdf

#include <stdio.h>
#include <stdlib.h>
#include <board_logic.h>
#include <board_mem.h>
#include <flags_util.h>

void free_board();

int main(int argc, char *argv[]) {
	int filaInicial, colInicial;
	int N = get_board_dimension();
	if (argc != 3) {
		printf("Uso: caballoSec filaInicial columnaInicial\n");
	} else {
		filaInicial = atoi(argv[1]);
		colInicial = atoi(argv[2]);
		if ((filaInicial < 0) || (filaInicial >= N)) {
			printf("Fila debe estar en el rango 0..%d\n", N);
			return 0;
		}
		if ((colInicial < 0) || (colInicial >= N)) {
			printf("Columna debe estar en el rango 0..%d\n", N);
			return 0;
		}
		solve_board(filaInicial, colInicial);
	}
	free_board();
}