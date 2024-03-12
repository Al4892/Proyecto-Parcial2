using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Lesson",menuName ="ScriptableObjects/NewLesson",order =1)]

public class Subject : ScriptableObject
{
    //es la leccion 
    [Header("Game object configuration")]
    public int Lesson = 0;
    // es la lista de la lecciones
    [Header("Lession Quest Configuration")]
   public List<Leccion> leccionlist;
}
