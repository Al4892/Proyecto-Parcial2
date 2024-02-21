using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Leccion
{
    public int id;
    public string lessons;
    public List<string> options;
    public int correctanswer;
   
}

[CreateAssetMenu(fileName ="New Lesson",menuName ="ScriptableObjects/NewLesson",order =1)]

public class Subject : ScriptableObject
{
   public List<Leccion> leccionlist;
}
