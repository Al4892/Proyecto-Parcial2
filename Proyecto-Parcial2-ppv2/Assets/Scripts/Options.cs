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
        transform.GetChild(0).GetComponent<TMP_Text>().text = optionName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
