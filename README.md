# Proyecto-Parcial 3
Este es un Proyecto del parcial 3 de la materia de Programacion para videojuegos 2.

-+-Es un proyecto basado en la aplicación duolingo, el Game que es el menu contiene lo que es una interfaz, que muestra dependiendo del boton, la leccion que se reproduciria. hecho con listas de string junto con clases para que aparezca la ventana.

-+-Para poder instalar el ejecutable desde github puede clonar el repositorio o darle click en code y dale en DownloadZip, si tiene alguna duda, no dude en contactar conmigo. Buen dia.

El proyecto se conforma de estos scripts principales:
---
LeccionManager: Este script se encarga de supervisar el tipo de leccion que vas a entrar asi como darte paso a la escena de la leccion.

levelManager: Este script es una leccion que agarra los datos del scriptable object para hacer las preguntas y modificar los textos de las opciones asi como comprobar si esta bien o mal asi como agarra los datos que da el savesystem sobre el json. 

options: se encarga de establecer las opciones, su id y el texto de la opcion desde otro script llamado leccion y pone lo que es las posibles respuestas a la leccion.

scriptableobject: mantiene todo la informacion de las preguntas, sus respuestas asi como las opciones.

SaveSystem: Este script, es utilizado para guardar y/o cargar archivos de tipo Json. este script con un getString localiza el nombre y donde se encuentra el archivo Json el cual se encargara de cargar las preguntas.

MainScript: Este se encarga de de recibir el nombre de la leccion el cual a partir de un setString la envia a SaveSystem. Tambien se encarga de cambiar la escena, para que del menu se pueda dirigir a la escena de las lecciones.

Caracteristicas del programa:
---
-+- Contiene Un menu en donde se puede elegir diferentes lecciones 

-+- Lecciones las cuales son completamente interactuables y se evalua tu respuesta correcta e incorrecta

-+- Si fallas se restan vidas y si te acabas tus vidas, sale una pantalla de GameOver la cual te regresa a la escena del menu de lecciones. 
![4](https://github.com/Al4892/Proyecto-Parcial2/assets/156052736/04bee2fc-168b-4bb2-ad4a-4dc6193e9c2c)


-+- Puedes cambiar a deseo las lecciones y salir y entrar de ellas

Modo de uso. 
---
•Al iniciar el juego, aparecera un menu el cual tiene unos botones amarillos y al pulsarlos aparecera un menu el cual te dira que lección es y si deseas empezarla, si no quieres empezar vuleve a pulsar el boton o pulsa otro boton para desactivar el menu de confirmacion. 
![1](https://github.com/Al4892/Proyecto-Parcial2/assets/156052736/7ca102b6-4e86-462d-86ae-58a1d6fd13db)


•Al entrar en una leccion te aparecera en la parte superior una pregunta, en la parte inferior tendras 5 opciones, al seleccionar una opcion el boton de confirmar se iluminara y si estas seguro de tu respuesta, puedes pulsarlo para ver si era la respuesta correcta.
![3](https://github.com/Al4892/Proyecto-Parcial2/assets/156052736/d436a5bd-26ff-43f6-bb21-e5c7096b9669)


•Se puede salir de la lección en cualquer momento, pulsando en la "X" que esta en la esquina superior izquierda, el cual te regresara al menu de lecciones, tambien podras salir de la lección si fallas 4 preguntas, que activara una ventana diciendo que fallaste y te regresara al menu, Tambien podras regresar al menu de lecciones si completas la lección sin gastarte tus vidas, tambien activara un menu que te indicara que ya es todo y en unos momentos se te regresara al menu.
