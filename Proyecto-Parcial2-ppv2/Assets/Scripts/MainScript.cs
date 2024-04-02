using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    public static MainScript instance;
    public string SelectedLesson = "dummy";
    private void Awake()
    {
       
            if (instance != null)
            {
                return;
            }
            else
            {
                instance = this;
            }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSelectedLesson(string lesson)
    {
        SelectedLesson = lesson;
        PlayerPrefs.SetString("SelectLesson", SelectedLesson);
    }
    public void BeginGame()
    {
        SceneManager.LoadScene("Lesson");
    }
}
