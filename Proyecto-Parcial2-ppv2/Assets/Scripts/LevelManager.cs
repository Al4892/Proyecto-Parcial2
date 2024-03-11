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
    // los game objects que teneos qe poner para cada cosa
    [Header("User interface")]
    public TMP_Text questiontxt;
    public TMP_Text questiongood;
    public List<Options> option;
    public GameObject checkbutton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;
    // esto es lo que recibe el script del scriptableobject
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
            for (int i = 0; i < CurrentLesson.options.Count; i++)
            {
                //les agregamos el contenido(respuesta) asi como su id 
                option[i].GetComponent<Options>().optionName = CurrentLesson.options[i];
                option[i].GetComponent<Options>().OptionID = i;
                option[i].GetComponent<Options>().Updatetext();
            }


        }
        else
        {
            //si llegamos al final de las preguntas
            Debug.Log("Fin de las preguntas");
            questiontxt.text = "Bien, se acabo.";
        }
    }
    public void NextQuestion()
    {
        if (CheckPlayerState())
        {

            // igual que el anterior checamos que la pregunta este 
            if (Currentquestion < QuestionAmount)
            {
                //el bool es para comparar la respuesta del jugador con la preestablecida
                bool isCorrect = CurrentLesson.options[CorrectanswerfromUser] == Correctanswer;
                //activa el answer container
                AnswerContainer.SetActive(true);
                // si se cumple la variable iscorrect 
                if (isCorrect)
                {
                    // el contenedor se cambia de color a verde
                    AnswerContainer.GetComponent<Image>().color = Green;
                    // y pone un texto diciendo que estuvo correcto
                    questiongood.text = "respuesta correcta." + Question + ":" + Correctanswer;
                }
                else// si no se cumple el iscorrect, se pone rojo y manda mensaje de que se equivoco
                {
                    AnswerContainer.GetComponent<Image>().color = Red;
                    questiongood.text = "respuesta incorrecta." + Question + ":" + Correctanswer;
                }
                //incrementamos el indice de la preugnta actual
                Currentquestion++;
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));
                
               
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
        // activamos el boton de comprobar si el ccorect answer es diferente a 9
        if (CorrectanswerfromUser != 9)
        {
            checkbutton.GetComponent<Button>().interactable = true;
            checkbutton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else// aqui lo desactivamos si el correctasnwer from user es 9 (se mantiene desactivado hasta que el jugador pulse una opcion) 
        {
            checkbutton.GetComponent<Button>().interactable = false;
            checkbutton.GetComponent<Image>().color = Color.grey;
            return false;
        }
    }
    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        yield return new WaitForSeconds(2.5f);// ajusta el tiempo que deseas mostar el resultad0
        //oculta las respuestas
        AnswerContainer.SetActive(false);
        //carga la preguntaa
        LoadQuestion();
        //Activar el boton de mostrar resultado
        
        
        //puedes hacer esto aqui o en loadquestion

        CheckPlayerState();
    }
}
