using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Leccion
{
    //las opciones que tiene el scriptableObject para las preguntas que nostros asignamos
    public int id;
    public string lessons;
    public List<string> options;
    public int correctanswer;

}

