using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("Level Data")]
    public Subject lesson;
    [Header("User interface")]
    public TMP_Text questiontxt;
    public List<Options> option;
    [Header("Game configuration")]
    public int QuestionAmount = 0;
    public int Currentquestion = 0;
    public string Question;
    public string Correctanswer;
    [Header("Current Lesson")]
    public Leccion CurrentLesson;

    
    void Start()
    {
        //establecer cantidad de prgts en la leccion
        QuestionAmount = lesson.leccionlist.Count;
        // cargar la primera pregunta
        LoadQuestion();
    }
    private void LoadQuestion()
    {
        //Aseguramos que la pregumta este dentro del los limites
        if (Currentquestion < QuestionAmount)
        {
            //establecemos la leccion actual
            CurrentLesson = lesson.leccionlist[Currentquestion];
            //establecemos la pregunta
            Question = CurrentLesson.lessons;
            //Establecemos la respuesta correcta 
            Correctanswer = CurrentLesson.options[CurrentLesson.correctanswer];
            //establecemos la pregunta en ui
            questiontxt.text = Question;
           
            
        }
        else
        {
            //si llegamos al final de las preguntas
            Debug.Log("Fin de las preguntas");
        }
    }
    public void NextQuestion()
    {
        if (Currentquestion < QuestionAmount)
        {
         //incrementamos el indice de la preugnta actual
         Currentquestion++;
         //
         LoadQuestion();
        }
        else
        {
            //cambio de escena
        }
    }
    
}