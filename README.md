# Proyecto-Parcial2
Este es un Proyecto del parcial 2 de la materia de Programacion para videojuegos 2.

-+-Es un proyecto basado en la aplicación duolingo, el buildeo 1 que es el menu contiene lo que es una interfaz, que muestra dependiendo del boton, la leccion que se reproduciria. hecho con listas de string junto con clases para que aparezca la ventana.

-+-El segundo build contiene lo que es una leccion. Contiene preguntas sobre programación, con listas y un scriptableObjct que contiene la informacion de las preguntas, esto lo agarra otro script y y utiliza un boton comprobar, que hace que aparezca si estas bien y cambia de pregunta asi como realiza un tiempo para poder ver la respuesta. 

-+-Para poder instalar el ejecutable desde github puede clonar el repositorio o darle click en code y dale en DownloadZip, si tiene alguna duda, no dude en contactar conmigo. Buen dia.

El proyecto se conforma de tres scripts principales:
---
LeccionManager: que se encarga de supervisar el tipo de leccion que vas a entrar.

levelManager: que es una leccion que agarra los datos del scriptable object para hacer las preguntas y modificar los textos de las opciones asi como comprobar si esta bien o mal. 

options: se encarga de establecer las opciones, su id y el texto de la opcion.

scriptableobject: mantiene todo la informacion de las preguntas, sus respuestas asi como las opciones.
