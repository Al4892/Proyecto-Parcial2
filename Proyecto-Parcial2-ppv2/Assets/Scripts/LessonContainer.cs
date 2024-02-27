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

    [Header("Lesson Data")]
    public ScriptableObject LessonData;
    // Start is called before the first frame update
    void Start()
    {
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
        if(Stagetitle!= null|| LessonStage != null)
        {
            Stagetitle.text = "Leccion" + lection;
            LessonStage.text = "Leccion" + CurrentLesson + "de" + TotalLessions;
        }
        else
        {
            Debug.LogWarning("GameObject nulo, revisa las variables de tipo TMP_Text");
        }
    }
    //este meotod activa /desactiva la ventana lessomcontainer
    public void EnableWindow()
    {
        OnUpdateUI();

        if (LesonContainer.activeSelf)
        {
            LesonContainer.SetActive(false);
        }
        else
        {
            LesonContainer.SetActive(true);
        }
    }
}
