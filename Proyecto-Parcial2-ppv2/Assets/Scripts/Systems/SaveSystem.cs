using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
        public static SaveSystem instance;
        public Leccion data;
    public SubjectContainer subject;
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

  
     private void Start()
    {
        SaveToJSON("LeccionDummy",data);
        subject = LoadFromJSON<SubjectContainer>("SubjectDummy");
    }

    // funcion encargada de almacenar objetos en archivos JSON
    public void SaveToJSON(string _filename, object _data)
    {
        if(_data != null)
        {
            string JSONData= JsonUtility.ToJson( _data, true );
            if (JSONData.Length != 0)
            {
                Debug.Log("JSON STRING: "+ JSONData);
                string fileName = _filename + ".json";
                string filepath= Path.Combine(Application.dataPath + "/materiales/JSONS/", fileName);
                File.WriteAllText(filepath, JSONData);
                Debug.Log("Json almacenado en la direccion: "+ filepath);
            }
            else 
            {

                Debug.Log("ERROR - FyleSystem: _data is null, check for param [ string JSONData]");

            }
        }
        else
        {

            Debug.Log("ERROR - FyleSystem: _data is null, check for param [object _data]");
        }
    }
   
    public T LoadFromJSON<T>(string _filename) where T: new()
    {
        T dato = new T();
        string path = Application.dataPath+ "/materiales/ JSONS/" + _filename+ ".json";
        string JSONdata = "";
        if (File.Exists(path)) 
        { 
         JSONdata = File.ReadAllText(path);
            Debug.Log("JSON STRING: "+ JSONdata);
        }
        if(JSONdata.Length != 0)
        {
            JsonUtility.FromJsonOverwrite(JSONdata, dato);
        }
        else
        {
            Debug.LogWarning("ERROR - FyleSystem: JsonData is null, check for param [ string JSONData]");
        }
        return dato;
    }
   
}
