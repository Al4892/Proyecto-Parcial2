using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Lesson",menuName ="ScriptableObjects/NewLesson",order =1)]

public class Subject : ScriptableObject
{
    [Header("Game object configuration")]
    public int Lesson = 0;

    [Header("Lession Quest Configuration")]
   public List<Leccion> leccionlist;
}
