#lang racket

; Bjoern Hoehrmann -- <bjoern@hoehrmann.de> -- <http://bjoern.hoehrmann.de>

; Global constants and type definitions
(define empty-char 0)
(define HEIGHT 6)
(define WIDTH 6)
(define START-X 0)
(define START-Y 0)
(define-struct move (x y))
(define knightmoves
  (list
   (make-move -1 -2) (make-move  1 -2) (make-move  2 -1) (make-move  2  1)
   (make-move  1  2) (make-move -1  2) (make-move -2  1) (make-move -2 -1)))

; greps all elements in l for which a comparison 
; with comp yields in a true value
(define (grep l comp)
  (if (null? l) '()
      (let ((r (grep (cdr l) comp)))
        (if (comp (car l)) (cons (car l) r) r))))

; creates a list with n elements using the function func to create each
; element. Function func takes one parameter indicating the number of
; elements still to be created including the current element.
(define (create-list n func)
  (if (<= n 0) '()
      (cons (func n) (create-list (- n 1) func))))

; creates a matrix with n,m fields using func
(define (create-list-xy n m func)
  (create-list n (lambda(i) (create-list m func))))

; tests whether x,y is a position out of the boundaries of matrix l
(define (out-of-bounds? l x y)
  (or
   (< x 0)                          ; negative index
   (< y 0)                          ; negative index
   (>= y (length l))                ; less rows
   (>= x (length (list-ref l y))))) ; less columns in row

; returns the value of the field at x,y of the matrix l or #<void>
; if x,y denotes a field outside the boundaries of the matrix
(define (list-ref-xy l x y)
  (if (not (out-of-bounds? l x y))
      (list-ref (list-ref l y) x)'()))

; first k elements of l or a copy of l if l has less than k elements
(define (list-head l k)
  (if (and (> k 0) (not (null? l)))
      (cons (car l) (list-head (cdr l) (- k 1)))
      '()))

; returns a modified copy of the list l where the i-th element is v
(define (set-element-at l i value)
  (append (list-head l i) (list value) (list-tail l (+ i 1))))

; returns a modified copy of the matrix l where the field at x,y is v
(define (set-element-at-xy l x y value)
  (set-element-at l y (set-element-at (list-ref l y) x value)))

; displays the matrix l
(define (display-matrix l)
  (display "(")
  (display (join " " (map fn (car l))))
  (display ")\n")
  (if (not (null? (cdr l)))
      (display-matrix (cdr l))'())
  )

; converts the list of strings l to a single string by inserting the
; string s between all elements in l. E.g. (join "+" (list 1 2 3))
; would return the string "1+2+3".
(define (join s l)
  (if (null? l) ""
      (if (null? (cdr l)) (car l)
          (string-append (car l) s (join s (cdr l))))))

; possible moves for player at poscolumn,posrow in field
(define (getlistofmoves poscolumn posrow field)
  (grep knightmoves (lambda (m) (not (out-of-bounds?
                                      field
                                      (+ poscolumn (move-x m))
                                      (+ posrow (move-y m)))))))

; right-aligns a number in a string
(define (fn x)
  (if (> x 9) (number->string x) (string-append " " (number->string x))))

; a recursive solution for the "Springerproblem"
(define (turn field x y moves visited)
  (cond
    ; turn should return #t in this case but (exit) is required...
    ((= visited (* WIDTH HEIGHT)) (display-matrix field) (exit))
    ((null? moves) #f)
    (else
     (let* ((nx (+ x (move-x (car moves))))                ; new x
            (ny (+ y (move-y (car moves))))                ; new y
            (nv (+ visited 1))                             ; new visited
            (nm (getlistofmoves nx ny field))              ; new moves
            (nf (set-element-at-xy field nx ny nv))        ; new field
            (uv (= (list-ref-xy field nx ny) empty-char))) ; unvisited?

       ; if the next field is visited or if it is unvisited and does not
       ; yield in a solution, try the next move in the list of moves
       (if (or (and uv (not (turn nf nx ny nm nv))) (not uv))
           (turn field x y (cdr moves) visited)'())))))

; Entry point, setup field/possible moves and place knight to start
(define (start)
  (let ((field (create-list-xy HEIGHT WIDTH (lambda(x) empty-char))))
    (if (not (turn (set-element-at-xy field START-X START-Y 1)
          START-X START-Y (getlistofmoves START-X START-Y field) 1))
    (display "There is no applicable solution\n")'())))

(start)