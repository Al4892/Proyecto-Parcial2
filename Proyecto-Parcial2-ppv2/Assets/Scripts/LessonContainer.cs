using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    using TMPro;

public class LessonContainer : MonoBehaviour
{
    [Header("GameObject Configuracion")]
    public int lection = 0;
    public int CurrentLesson = 0;
    public int TotalLessions = 0;
    public bool AreAllLessonsComplete = false;

    [Header("Ui Configuration")]
    public TMP_Text Stagetitle;
    public TMP_Text LessonStage;

    [Header("External GameObject Configuration")]
    public GameObject LesonContainer;
    public string LessonName;

    [Header("Lesson Data")]
    int xd;
    // Start is called before the first frame update
    void Start()
    {
        // si el game object esta puesto se va a onupdate ui
        if(LesonContainer != null)
        {
            OnUpdateUI();
        }
        else
        {
            Debug.LogWarning("GameObjet nulo, revisa las variables de tipo GameObject LessonContainer");
        }
        
    }

    // Update is called once per frame
    void OnUpdateUI()
    {
        // accedemos si el los textos de stagetitle y lessonStange estan escritos
        if(Stagetitle!= null|| LessonStage != null)
        {
            //lo que se muestra en la ui que seria la leccion y su seccion  de cada una
            Stagetitle.text = "Leccion " + lection;
            LessonStage.text = "Leccion " + CurrentLesson + " de " + TotalLessions;
        }
        else//si no se cumple la funciom
        {
            //mandamos un mensaje por si no estan puesto los textos 
            Debug.LogWarning("GameObject nulo, revisa las variables de tipo TMP_Text");
        }
    }
    //este meotod activa /desactiva la ventana lessomcontainer
    public void EnableWindow()
    {
        OnUpdateUI();
        //hacemos que la ventana de la leccion aparezca y desaparezca
        if (LesonContainer.activeSelf)
        {
            LesonContainer.SetActive(false);
        }
        else
        {
            LesonContainer.SetActive(true);
            MainScript.instance.SetSelectedLesson(LessonName);
        }
    }
}
