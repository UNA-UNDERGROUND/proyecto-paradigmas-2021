cmake_minimum_required(VERSION 3.10)
project(tarea_1 VERSION 0.1.0)


set(src_include
    include/Tablero.h
    include/SaltoDeCaballo.h
    include/Tablero.h
    include/VectorSalto.h
)



set(src
    ${src_include}
    src/Resolucion.c
    

)

add_executable(source ${src} src/main.c)
target_include_directories(source PRIVATE include)


