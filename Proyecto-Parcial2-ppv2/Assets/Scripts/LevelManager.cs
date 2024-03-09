using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Level Data")]
    public Subject lesson;

    [Header("User interface")]
    public TMP_Text questiontxt;
    public TMP_Text questiongood;
    public List<Options> option;
    public GameObject checkbutton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;

    [Header("Game configuration")]
    public int QuestionAmount = 0;
    public int Currentquestion = 0;
    public string Question;
    public string Correctanswer;
    public int CorrectanswerfromUser = 9;

    [Header("Current Lesson")]
    public Leccion CurrentLesson;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }
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
            //establecemos las opcones
            CorrectanswerfromUser = 0;
            for (int i = 0; i < CurrentLesson.options.Count; i++)
            {
                option[i].GetComponent<Options>().optionName = CurrentLesson.options[i];
                option[i].GetComponent<Options>().OptionID = i;
                option[i].GetComponent<Options>().Updatetext();
            }


        }
        else
        {
            //si llegamos al final de las preguntas
            Debug.Log("Fin de las preguntas");
        }
    }
    public void NextQuestion()
    {
        if (CheckPlayerState())
        {


            if (Currentquestion < QuestionAmount)
            {
                bool isCorrect = CurrentLesson.options[CorrectanswerfromUser] == Correctanswer;
                AnswerContainer.SetActive(true);
                if (isCorrect)
                {
                    AnswerContainer.GetComponent<Image>().color = Green;
                    questiongood.text = "respuesta correcta." + Question + ":" + Correctanswer;
                }
                else
                {
                    AnswerContainer.GetComponent<Image>().color = Red;
                    questiongood.text = "respuesta incorrecta." + Question + ":" + Correctanswer;
                }
                //incrementamos el indice de la preugnta actual
                Currentquestion++;
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));
                //
               
                CorrectanswerfromUser = 9;
            }
            else
            {
                //cambio de escena
            }


        }





    }
    public void setPlayerAnswer(int _answer)
    {
        CorrectanswerfromUser = _answer;
    }
    public bool CheckPlayerState()
    {
        if (CorrectanswerfromUser != 9)
        {
            checkbutton.GetComponent<Button>().interactable = true;
            checkbutton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else
        {
            checkbutton.GetComponent<Button>().interactable = false;
            checkbutton.GetComponent<Image>().color = Color.grey;
            return false;
        }
    }
    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        yield return new WaitForSeconds(2.5f);// ajusta el tiempo que deseas mostar el rsultadi
        //oculta las respuestas
        AnswerContainer.SetActive(false);
        //carga la preguntaa
        LoadQuestion();
        //Activar el boton de mostrar resultado
        
        
        //puedes hacer esto aqui o en loadquestion

        CheckPlayerState();
    }
}
