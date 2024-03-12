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
    public TMP_Text lives;
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
    //singleton es para renstringir la creacion de objetos pertencientes
    //a una clase o el valor de un tipo, en este caso renstringe la instancia
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
    //funcion que se ecnarga de cargar la pregunta y cambiar las opciones a elejir
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
                //el id del boton/opcion
                option[i].GetComponent<Options>().OptionID = i;
                //hace la funcion de update text del boton
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
    //clase donde se checa si la respuess son correctas y incorrectas
    public void NextQuestion()
    {
        //checa el player state si esta activo y se pulsa el boton de comprobar
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
                    questiongood.text = "respuesta correcta " + ": " + Correctanswer;
                }
                else// si no se cumple el iscorrect, se pone rojo y manda mensaje de que se equivoco
                {
                    AnswerContainer.GetComponent<Image>().color = Red;
                    questiongood.text = "respuesta incorrecta. "+"Correcta"+": " + Correctanswer;
                }
                //incrementamos el indice de la preugnta actual
                Currentquestion++;
                //iniciamos una corroutina donde mandamos el resultado de is correct a la funcion showresults
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));
                
               
                CorrectanswerfromUser = 9;
            }
            else
            {
                //cambio de escena
            }


        }





    }
    //funcion que agarra el id de option y correctanswer es igual al idoption
    public void setPlayerAnswer(int _answer)
    {
        CorrectanswerfromUser = _answer;
    }
    //funcion que se encarga de ser interactuable el boton o desactivarlo al elejir una opcion
    public bool CheckPlayerState()
    {
        // activamos el boton de comprobar si el ccorect answer es diferente a 9
        if (CorrectanswerfromUser != 9)
        {
            //activa el bot0n
            checkbutton.GetComponent<Button>().interactable = true;
            //lo cambia a su color normal
            checkbutton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else// aqui lo desactivamos si el correctasnwer from user es 9 (se mantiene desactivado hasta que el jugador pulse una opcion) 
        {
            //desactiva el boton, no se puede pulsar
            checkbutton.GetComponent<Button>().interactable = false;
            // hace el boton de un color gris
            checkbutton.GetComponent<Image>().color = Color.grey;
            return false;
        }
    }
    //funcion que inicia el proceso de la corrutina la cual suspende el proceso del codigo
    //dependiendo de lo que se escriba de la misma funcion.
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
