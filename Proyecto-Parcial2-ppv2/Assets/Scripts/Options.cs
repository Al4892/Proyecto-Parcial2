using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public int OptionID;
    public string optionName;
    // Start is called before the first frame update
    void Start()
    {
        //adquirimos el componente texto de la opcion y sera igual al nombre al dels scripbatle object
        transform.GetChild(0).GetComponent<TMP_Text>().text = optionName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //actualiza el texto
    public void Updatetext()
    {
        // lo actualiza el texto conforme vayan pasando las preguntas
        transform.GetChild(0).GetComponent<TMP_Text>().text = optionName;
    }
    public void SelectOptions()
    {
        //mandamos el contenido de OptionId al setplayer answer
        LevelManager.Instance.setPlayerAnswer(OptionID);
        //con el check player state checamos para la activacion del comprobar
        LevelManager.Instance.CheckPlayerState();
    }
}
