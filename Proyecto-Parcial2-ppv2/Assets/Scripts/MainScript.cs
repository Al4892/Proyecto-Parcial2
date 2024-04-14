using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    public static MainScript instance;
    // String que tendra el nombre de la leccion al seleccionarla
    public string SelectedLesson = "dummy";
    //Singleton, que realiza una unica instancia de la clase. Si requiere haver una segunda instancia, se toma y devuelve la instancia ya creada anteriormente 
    private void Awake()
    {
       
            if (instance != null)
            {
                return;
            }
            else
            {
                instance = this;
            }
        
    }
  // Clase que pone y obtiene el nombre de la leccion que se realizara en el juego
    public void SetSelectedLesson(string lesson)
    {
        // Variable que toma el contenido de lesson y la vuelve suya copiando su informacion
        SelectedLesson = lesson;
        //Usamos una llave identificadora para guardar el recurso string(el nombre de la lección) y mandarla a save system al selectedLesson
        PlayerPrefs.SetString("SelectLesson", SelectedLesson);
    }
    // Clase que se encarga de cambiar de escena a la leccion
    public void BeginGame()
    {
        //Es la escena de la lección que se cargara al darle al boton de empezar leccion
        SceneManager.LoadScene("Lesson");
    }
    //Clase que cambia al menu de lecciones a elegir
    public void EndGame()
    {
        //Carga la escena del menu principal
        SceneManager.LoadScene("SampleScene");
    }
}
