#lang racket
; define un movimiento como una estructura
(define-struct move (x y))
; las 8 direcciones del caballo, son las mismas de C
(define movements
  (list
   (make-move -2 +1) ; LEFT_UP
   (make-move -1 +2) ; UP_LEFT
   (make-move +1 +2) ; UP_RIGHT
   (make-move +2 +1) ; RIGHT_UP
   (make-move +2 -1) ; RIGHT_DOWN
   (make-move +1 -2) ; DOWN_RIGHT
   (make-move -1 -2) ; DOWN_LEFT
   (make-move -2 -1) ; LEFT_DOWN
   )
  )

; verifica si el movimiento esta en un rango valido
(define (movimiento-valido l x y)
  (not (or
        (< x 0)                          ; x es negativo
        (< y 0)                          ; y es negativo
        (>= y (length l))                ; mayor que la dimension
        (>= x (length (list-ref l y)))))) ; mayor que la dimension

; crea una nueva copia de la matriz con el movimiento aplicado
(define (aplicar-movimiento-tablero l x y value)
  ; aplica el movimiento en una nueva lista
  (define (aplicar-movimiento-lista l i value)
    	; permite movernos hasta la posicion indicada
    (define (cabeza-posicion l k)
      (if (and (> k 0) (not (null? l)))
          (cons (car l) (cabeza-posicion (cdr l) (- k 1)))
          '()))
    (append (cabeza-posicion l i) (list value) (list-tail l (+ i 1))))
  (aplicar-movimiento-lista l y (aplicar-movimiento-lista (list-ref l y) x value)))

; recupera las posiciones posibles dada una fila y columna
(define (recuperarMovimientos x y field)
  ; nos permite filtrar los movimientos validos
  ; la version de C intentaba primero, a diferiencia
  ; de este que genera una lista
  (define (filtrar l comp)
    (if (null? l) '()
        (let ((r (filtrar (cdr l) comp)))
          (if (comp (car l)) (cons (car l) r) r))))
  (filtrar movements (lambda (m) (movimiento-valido
                                  field
                                  (+ x (move-x m))
                                  (+ y (move-y m))))))

; muestra un tablero
(define (mostrar-tablero l)
  ; nos permite alinear los numeros
  (define (alinear-numero x)
    (if (> x 9) (number->string x) (string-append " " (number->string x))))
  ; nos permite realizar un formato de las listas a un tablero
  ; de la misma forma que C, y python
  (define (join s l)
    (if (null? l) ""
        (if (null? (cdr l)) (car l)
            (string-append (car l) s (join s (cdr l))))))
  (display "(")
  (display (join " " (map alinear-numero (car l))))
  (display ")\n")
  (if (not (null? (cdr l)))
      (mostrar-tablero (cdr l))'())
  )

; salto recursivo del caballo
(define (saltoCaballoR dimension field x y moves visited)
  (define (valor-campo l x y)
    (if (movimiento-valido l x y)
        (list-ref (list-ref l y) x)'()))
  (cond
    ; saltoCaballoR debería retornar true pero es requerido exit
    ((= visited (* dimension dimension)) (mostrar-tablero field) (exit))
    ((null? moves) #f)
    (else
     	;campos nuevos
     (let* ((nx (+ x (move-x (car moves))))                     ; x
            (ny (+ y (move-y (car moves))))                     ; y
            (nv (+ visited 1))                                  ; visitado
            (nm (recuperarMovimientos nx ny field))             ; movimientos
            (nf (aplicar-movimiento-tablero field nx ny nv))    ; tablero
            (uv (= (valor-campo field nx ny) 0)))               ; sin visitar
       	   ; intentar la solucion siguiente si visitado o si no esta visitado y
       	   ; no proporciona una solucion
       (if (or (and uv (not (saltoCaballoR dimension nf nx ny nm nv))) (not uv))
           (saltoCaballoR dimension field x y (cdr moves) visited)'())))))

; crea el tablero
(define (crear-tablero dimension)
  (define (inicializar-lista n)
    (if (<= n 0) '()
        (cons 0 (inicializar-lista (- n 1))))
    )
  (define (inicializar-arreglo n)
    (if (<= n 0) '()
        (cons (inicializar-lista dimension) (inicializar-arreglo (- n 1))))
    )
  (inicializar-arreglo dimension)
  )

; Funcion principal, equivalente a la misma funcion en C
(define (saltoCaballo dimension x y)
  (let ((field (crear-tablero dimension)))
    (define solucion (saltoCaballoR dimension (aplicar-movimiento-tablero field x y 1)
                                    x y (recuperarMovimientos x y field) 1))
    (if (not solucion)
        (display "solucion no encontrada\n")'())))

(saltoCaballo 8 0 0)