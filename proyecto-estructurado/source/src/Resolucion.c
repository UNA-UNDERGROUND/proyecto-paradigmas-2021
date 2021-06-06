#include <Casilla.h>
#include <SaltoDeCaballo.h>
#include <Tablero.h>
#include <VectorSalto.h>
#include <stdbool.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

Tablero *tablero;
VectorSalto *recorridoFinal;
Tablero *recorrido;
int dimencion;
int cantTotal;
int x;
int y;

int contadorcito;

void pause() {
	/*  Procedimiento tomado de: https://stackoverrun.com/es/q/3397614  */

	int c;
	do {
		c = getchar();
	} while (c != '\n' && c != EOF);
	if (c == EOF) {
	} else {
		printf("\n\n Presione enter para continuar...");
		getchar();
	}
}

SaltoDeCaballo *saltoTipo1(SaltoDeCaballo *s) {

	s->cantSaltos++;
	s->X = s->X - 1;
	s->Y = s->Y + 2;

	return s;
}

SaltoDeCaballo *saltoTipo2(SaltoDeCaballo *s) {
	s->cantSaltos++;
	s->X = s->X - 2;
	s->Y = s->Y + 1;

	return s;
}

SaltoDeCaballo *saltoTipo3(SaltoDeCaballo *s) {
	s->cantSaltos++;
	s->X = s->X - 2;
	s->Y = s->Y - 1;

	return s;
}

SaltoDeCaballo *saltoTipo4(SaltoDeCaballo *s) {
	s->cantSaltos++;
	s->X = s->X - 1;
	s->Y = s->Y - 2;

	return s;
}

SaltoDeCaballo *saltoTipo5(SaltoDeCaballo *s) {
	s->cantSaltos++;
	s->X = s->X + 1;
	s->Y = s->Y - 2;

	return s;
}

SaltoDeCaballo *saltoTipo6(SaltoDeCaballo *s) {
	s->cantSaltos++;
	s->X = s->X + 2;
	s->Y = s->Y - 1;

	return s;
}

SaltoDeCaballo *saltoTipo7(SaltoDeCaballo *s) {
	s->cantSaltos++;
	s->X = s->X + 2;
	s->Y = s->Y + 1;

	return s;
}

SaltoDeCaballo *saltoTipo8(SaltoDeCaballo *s) {
	s->cantSaltos++;
	s->X = s->X + 1;
	s->Y = s->Y + 2;

	return s;
}

bool validarSalto(SaltoDeCaballo *s) {

	if (s->X >= dimencion || s->Y >= dimencion || s->X < 0 || s->Y < 0) {
		return false;
	} else {

		if (tablero->matriz[s->X][s->Y].visitada == true) {
			return false;
		} else {
			return true;
		}
	}
}

void constructorSalto(SaltoDeCaballo *v, int x, int y, int c) {

	v->X = x;
	v->Y = y;
	v->cantSaltos = c;
}

void constructorVecSalto(VectorSalto *v, int t) {

	v->cant = 0;
	v->tam = t;
	v->vec = malloc(sizeof(SaltoDeCaballo *) * t);
	for (int i = 0; i < v->tam; i++) {
		v->vec[i] = NULL;
	}
}

void add(VectorSalto *v, SaltoDeCaballo *s) {

	v->vec[v->cant] = s;

	v->cant++;
}

void add2(SaltoDeCaballo *s) {

	recorridoFinal->vec[recorridoFinal->cant]->X = s->X;
	recorridoFinal->vec[recorridoFinal->cant]->Y = s->Y;
	recorridoFinal->vec[recorridoFinal->cant]->cantSaltos = s->cantSaltos;

	recorridoFinal->cant++;
}

void clear(VectorSalto *v) {

	SaltoDeCaballo *aux;
	for (int i = 0; i < v->tam; i++) {
		if (v->vec[i] != NULL) {
			aux = v->vec[i];
			v->vec[i] = NULL;
			free(aux);
		}
	}
	v->cant = 0;
}

void removeAt(VectorSalto *v, int n) {

	SaltoDeCaballo *aux;
	aux = v->vec[n];

	for (int i = n; i < v->tam - 1; i++) {

		v->vec[i] = v->vec[i + 1];
	}

	v->vec[v->tam - 1] = NULL;
	free(aux);
	v->cant--;
}

bool obtenerRecorrido(SaltoDeCaballo *s) {

	int xAux = s->X;
	int yAux = s->Y;
	int cAux = s->cantSaltos;
	VectorSalto *validos = malloc(sizeof(VectorSalto));
	constructorVecSalto(validos, 8);

	SaltoDeCaballo *sa1 = malloc(sizeof(SaltoDeCaballo));
	constructorSalto(sa1, xAux, yAux, cAux);
	saltoTipo1(sa1);
	if (validarSalto(sa1)) {
		add(validos, sa1);
	}

	SaltoDeCaballo *sa2 = malloc(sizeof(SaltoDeCaballo));
	constructorSalto(sa2, xAux, yAux, cAux);
	saltoTipo2(sa2);
	if (validarSalto(sa2)) {
		add(validos, sa2);
	}
	SaltoDeCaballo *sa3 = malloc(sizeof(SaltoDeCaballo));
	constructorSalto(sa3, xAux, yAux, cAux);
	saltoTipo3(sa3);
	if (validarSalto(sa3)) {
		add(validos, sa3);
	}
	SaltoDeCaballo *sa4 = malloc(sizeof(SaltoDeCaballo));
	constructorSalto(sa4, xAux, yAux, cAux);
	saltoTipo4(sa4);
	if (validarSalto(sa4)) {
		add(validos, sa4);
	}
	SaltoDeCaballo *sa5 = malloc(sizeof(SaltoDeCaballo));
	constructorSalto(sa5, xAux, yAux, cAux);
	saltoTipo5(sa5);
	if (validarSalto(sa5)) {
		add(validos, sa5);
	}
	SaltoDeCaballo *sa6 = malloc(sizeof(SaltoDeCaballo));
	constructorSalto(sa6, xAux, yAux, cAux);
	saltoTipo6(sa6);
	if (validarSalto(sa6)) {
		add(validos, sa6);
	}
	SaltoDeCaballo *sa7 = malloc(sizeof(SaltoDeCaballo));
	constructorSalto(sa7, xAux, yAux, cAux);
	saltoTipo7(sa7);
	if (validarSalto(sa7)) {
		add(validos, sa7);
	}
	SaltoDeCaballo *sa8 = malloc(sizeof(SaltoDeCaballo));
	constructorSalto(sa8, xAux, yAux, cAux);
	saltoTipo8(sa8);
	if (validarSalto(sa8)) {
		add(validos, sa8);
	}

	while (s->cantSaltos < (cantTotal - 1) && validos->cant > 0) {

		for (int i = 0; i < validos->cant; i++) {

			SaltoDeCaballo *posibleSalto = validos->vec[i];

			if (!tablero->matriz[posibleSalto->X][posibleSalto->Y].visitada) {

				tablero->matriz[posibleSalto->X][posibleSalto->Y].visitada =
				    true;
				if (s->cantSaltos < (cantTotal - 1)) {

					// Recursividad Backtracking
					if (!obtenerRecorrido(posibleSalto)) {
						tablero->matriz[posibleSalto->X][posibleSalto->Y]
						    .visitada = false;

						removeAt(validos, i);

					} else {

						add2(validos->vec[i]);
						s->cantSaltos = cantTotal - 1;
						clear(validos);
						break;
					}
				}
			}
		}
	}

	if (s->cantSaltos == cantTotal - 1) {
		return true;
	} else {
		return false;
	}
}

void constructorTablero(int d) {
	tablero->matriz = malloc(sizeof(Casilla *) * d);
	for (int i = 0; i < d; i++) {

		tablero->matriz[i] = malloc(sizeof(Casilla) * d);
	}
	for (int i = 0; i < d; i++) {
		for (int j = 0; j < d; j++) {
			tablero->matriz[i][j].visitada = false;
		}
	}
}

void imprimirMatriz() {
	printf("\n");

	for (int i = 0; i < dimencion; i++) {
		printf("|");
		for (int j = 0; j < dimencion; j++) {

			if (recorrido->matriz[i][j].ocupada) {

				printf(" Ca ");

			} else {

				if (recorrido->matriz[i][j].visitada) {

					if (recorrido->matriz[i][j].posicion < 10) {
						printf(" 0%d ", recorrido->matriz[i][j].posicion);
					} else {
						printf(" %d ", recorrido->matriz[i][j].posicion);
					}

				} else {
					printf("    ");
				}
			}
			printf("|");
		}

		printf("\n");
	}
}

void imprimirRecorrido() {

	int xAux = 0;
	int yAux = 0;

	recorrido = malloc(sizeof(VectorSalto));
	recorrido->matriz = malloc(sizeof(Casilla *) * dimencion);
	for (int i = 0; i < dimencion; i++) {

		recorrido->matriz[i] = malloc(sizeof(Casilla) * dimencion);
	}
	for (int i = 0; i < dimencion; i++) {
		for (int j = 0; j < dimencion; j++) {
			recorrido->matriz[i][j].visitada = false;
			recorrido->matriz[i][j].ocupada = false;
			recorrido->matriz[i][j].posicion = 0;
		}
	}

	xAux = recorridoFinal->vec[cantTotal - 1]->X;
	yAux = recorridoFinal->vec[cantTotal - 1]->Y;

	recorrido->matriz[xAux][yAux].ocupada = true;
	recorrido->matriz[xAux][yAux].visitada = true;
	recorrido->matriz[xAux][yAux].posicion = 1;

	imprimirMatriz();
	pause();

	for (int i = cantTotal - 2; i >= 0; i--) {

		recorrido->matriz[xAux][yAux].ocupada = false;

		xAux = recorridoFinal->vec[i]->X;
		yAux = recorridoFinal->vec[i]->Y;
		recorrido->matriz[xAux][yAux].ocupada = true;
		recorrido->matriz[xAux][yAux].visitada = true;
		recorrido->matriz[xAux][yAux].posicion = cantTotal - i;

		imprimirMatriz();
		pause();
	}
	// imprimirMatriz();
}

void menu() {
	contadorcito = 0;
	x = 4;
	y = 4;
	dimencion = 8;
	cantTotal = dimencion * dimencion;
	tablero = malloc(sizeof(Tablero));
	constructorTablero(dimencion);
	recorridoFinal = malloc(sizeof(VectorSalto));
	constructorVecSalto(recorridoFinal, cantTotal);
	tablero->matriz[x][y].visitada = true;
	SaltoDeCaballo *primerSalto = malloc(sizeof(SaltoDeCaballo));

	primerSalto->cantSaltos = 0;
	primerSalto->X = x;
	primerSalto->Y = y;

	for (int i = 0; i < recorridoFinal->tam; i++) {
		recorridoFinal->vec[i] = malloc(sizeof(SaltoDeCaballo));
	}

	obtenerRecorrido(primerSalto);
	add2(primerSalto);
	/*for (int i = 0; i < cantTotal; i++) {
	    printf(" %d %d \n", recorridoFinal->vec[i]->X,
	           recorridoFinal->vec[i]->Y);
	}*/
	imprimirRecorrido();
}