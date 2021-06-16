
// basado en
// https://www.etsisi.upm.es/sites/default/files/asigs/arquitecturas_avanzadas/practicas/MPI/caballo.pdf

#include <board_logic.h>
#include <board_mem.h>
#include <flags_util.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void free_board();
int filaInicial = -1;
int colInicial = -1;
int dimension = 8;

// -1, fallido
// 0,  exitoso
// 1,  salir (ayuda u otros)
// 2,  no hay suficientes parametros
int parse_arguments(int argc, char *argv[]) {
	if (argc < 3) {
		return 2;
	}
	int custom_dim = 0;
	for (int i = 1; i < argc; i++) {
		if (i == 1 && strcmp(argv[i], "-d") == 0) {
			i = 2;
			if (argc < 5) {
				return 2;
			}
			dimension = atoi(argv[i]);
			if (dimension == 0) {
				printf("dimension no es un parametro valido.\n");
				return -1;
			}
			custom_dim = 1;
			set_board_dimension(dimension);

		} else if(custom_dim == 0) {
			filaInicial = atoi(argv[1]);
			colInicial = atoi(argv[2]);
			if ((filaInicial < 0) || (filaInicial >= dimension)) {
				printf("Fila debe estar en el rango 0..%d\n", dimension);
				return -1;
			}
			if ((colInicial < 0) || (colInicial >= dimension)) {
				printf("Columna debe estar en el rango 0..%d\n", dimension);
				return -1;
			}
		}
		else if (custom_dim == 1 && i == 3) {
			filaInicial = atoi(argv[i++]);
			colInicial = atoi(argv[i]);
			if ((filaInicial < 0) || (filaInicial >= dimension)) {
				printf("Fila debe estar en el rango [0, %d[\n", dimension);
				return -1;
			}
			if ((colInicial < 0) || (colInicial >= dimension)) {
				printf("Columna debe estar en el rango [0, %d[\n", dimension);
				return -1;
			}
		}
		//printf("parametro no reconocido: [%s]\n", argv[i]);
	}
	return 0;
}

int main(int argc, char *argv[]) {

	int retval = 0;
	int res = parse_arguments(argc, argv);
	switch (res) {
	case 0:
		solve_board(filaInicial, colInicial);
		free_board();
		break;
	case 1:

		break;
	case 2:
		printf("uso: ./programa [-d dimension](opcional/defecto 8) fila col "
		       "[argumentos adicionales]\n");
		break;
	case -1:
		retval = -1;
	default:
		printf("Uso: caballoSec filaInicial columnaInicial\n");
		break;
	}

	return retval;
}