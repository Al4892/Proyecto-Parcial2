# Proyecto-Parcial2
Este es un Proyecto del parcial 2 de la materia de Programacion para videojuegos 2.

-+-Es un proyecto basado en la aplicación duolingo, el buildeo 1 que es el menu contiene lo que es una interfaz, que muestra dependiendo del boton, la leccion que se reproduciria. hecho con listas de string junto con clases para que aparezca la ventana.

-+-El segundo build contiene lo que es una leccion. Contiene preguntas sobre programación, con listas y un scriptableObjct que contiene la informacion de las preguntas, esto lo agarra otro script y y utiliza un boton comprobar, que hace que aparezca si estas bien y cambia de pregunta asi como realiza un tiempo para poder ver la respuesta. 

-+-Para poder instalar el ejecutable desde github puede clonar el repositorio o darle click en code y dale en DownloadZip, si tiene alguna duda, no dude en contactar conmigo. Buen dia.

El proyecto se conforma de estos scripts principales:
---
LeccionManager: que se encarga de supervisar el tipo de leccion que vas a entrar.

levelManager: que es una leccion que agarra los datos del scriptable object para hacer las preguntas y modificar los textos de las opciones asi como comprobar si esta bien o mal. 

options: se encarga de establecer las opciones, su id y el texto de la opcion.

scriptableobject: mantiene todo la informacion de las preguntas, sus respuestas asi como las opciones.

SaveSystem: Este script, es utilizado para guardar y/o cargar archivos de tipo Json. este script con un getString localiza el nombre y donde se encuentra el archivo Json el cual se encargara de cargar las preguntas.

MainScript: Este se encarga de de recibir el nombre de la leccion el cual a partir de un setString la envia a SaveSystem. Tambien se encarga de cambiar la escena, para que del menu se pueda dirigir a la escena de las lecciones.

Caracteristicas del programa:
---
-+- Contiene Un menu en donde se puede elegir diferentes lecciones 

-+- Lecciones las cuales son completamente interactuables y se evalua tu respuesta correcta e incorrecta

-+- Si fallas se restan vidas y si te acabas tus vidas, sale una pantalla de GameOver la cual te regresa a la escena del menu de lecciones. 

-+- Puedes cambiar a deseo las lecciones y salir y entrar de ellas

Modo de uso. 
---
•Al iniciar el juego, aparecera un menu el cual tiene unos botones amarillos y al pulsarlos aparecera un menu el cual te dira que lección es y si deseas empezarla, si no quieres empezar vuleve a pulsar el boton o pulsa otro boton para desactivar el menu de confirmacion. 

•Al entrar en una leccion te aparecera en la parte superior una pregunta, en la parte inferior tendras 5 opciones, al seleccionar una opcion el boton de confirmar se iluminara y si estas seguro de tu respuesta, puedes pulsarlo para ver si era la respuesta correcta.

•Se puede salir de la lección en cualquer momento, pulsando en la "X" que esta en la esquina superior izquierda, el cual te regresara al menu de lecciones, tambien podras salir de la lección si fallas 4 preguntas, que activara una ventana diciendo que fallaste y te regresara al menu, Tambien podras regresar al menu de lecciones si completas la lección sin gastarte tus vidas, tambien activara un menu que te indicara que ya es todo y en unos momentos se te regresara al menu.
