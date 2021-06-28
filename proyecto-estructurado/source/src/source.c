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

const char *mensaje_ayuda =
    "-- Argumentos --\n"
    "-h        : muestra este mensaje de ayuda.\n"
    "-d [dim]  : especifica una dimension personalizada del tablero(defecto "
    "8).\n"
    "-b [nivel]: especifica un nivel de benckmark a mostrar(defecto 0).\n"
    "-s [sol]  : especifica el maximo de soluciones a buscar(defecto 1).\n"
    "-  Ejemplos    -\n"
    " -> un tablero 8x8(defecto) en la posicion 0 0,\n"
    "./programa 0 0\n"
    " -> especifica un tablero 5x5 en la posicion 0 0 (fila/columna).\n"
    "./programa -d 5 0 0\n"
    " -> busca 2 soluciones con un nivel 2 de benchmark y dimension 5.\n"
    "./programa -d 5 0 0 -b 2 -s 2\n";

// -1, fallido
// 0,  exitoso
// 1,  salir (ayuda u otros)
// 2,  no hay suficientes parametros
int parse_arguments(int argc, char *argv[]) {
	if (argc == 2 && strcmp(argv[1], "-h") == 0) {
		return 1;
	}
	if (argc < 3) {
		return 2;
	}
	int custom_dim = 0;
	for (int i = 1; i < argc; i++) {
		if (strcmp(argv[i], "-h") == 0) {
			return 1;
		} else if (i == 1 && strcmp(argv[i], "-d") == 0) {
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

		} else if (custom_dim == 0) {
			filaInicial = atoi(argv[1]);
			colInicial = atoi(argv[2]);
			if ((filaInicial < 0) || (filaInicial >= dimension)) {
				printf("Fila debe estar en el rango [0, %d[\n", dimension);
				return -1;
			}
			if ((colInicial < 0) || (colInicial >= dimension)) {
				printf("Columna debe estar en el rango [0, %d[\n", dimension);
				return -1;
			}
		} else if (custom_dim == 1 && i == 3) {
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
		} else {
			// nivel de benchmark
			if (strcmp(argv[i], "-b") == 0) {
				// motivos de prueba, no es seguro en la vida real
				i++;
				if (i < argc) {
					set_benchmark_level(atoi(argv[i]));
				} else {
					return 2;
				}
			} else if (strcmp(argv[i], "-s") == 0) {
				// motivos de prueba, no es seguro en la vida real
				i++;
				if (i < argc) {
					set_max_solutions(atoi(argv[i]));
				} else {
					return 2;
				}
			} else {
				printf("parametro no reconocido: [%s]\n", argv[i]);
			}
			// el resto de comandos
		}
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
		printf("%s", mensaje_ayuda);
		break;
	case 2:
		printf("uso: ./programa [-d dimension](opcional/defecto 8) fila col "
		       "[argumentos adicionales]\n"
		       "use: ./programa -h\n"
		       "para mas ayuda,\n");
		break;
	case -1:
		retval = -1;
	default:
		printf("Uso: caballoSec filaInicial columnaInicial\n");
		break;
	}

	return retval;
}