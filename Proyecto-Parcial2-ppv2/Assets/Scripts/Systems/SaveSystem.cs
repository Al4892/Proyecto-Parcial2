using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
        public static SaveSystem instance;
        public Leccion data;
    public SubjectContainer subject;
    public Subject Subjects;
    //sigleton que hace instancia se hace una sola vez y si se quiere crear otra solo se devuleve la que ya se hizo anteriormente
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
        subject = LoadFromJSON<SubjectContainer>(PlayerPrefs.GetString("SelectLesson"));
    }

  // se reproduce lo que hay aqui desde el primer frame
    private void Start()
    {
        // adquiere la funcion saveToJSon y guarda el nombre 
        //SaveToJSON("LeccionDummy",data);
        //agarra el subject o un Json con el nombre y lo guarda
    }
    public void createFile(string filename, string extension)
    {

    }

    // funcion encargada de almacenar objetos en archivos JSON
    public void SaveToJSON(string _filename, object _data)
    {
        // se comprueba ei data es nulo 
        if(_data != null)
        {
            // comvierte el data en un Json de jasonUtilyti
            string JSONData= JsonUtility.ToJson( _data, true );
            // comprueba y tiene un objeto o guardado el JsonData
            if (JSONData.Length != 0)
            {
                //mesnaje que indica que agarro la informacion
                Debug.Log("JSON STRING: "+ JSONData);
                //se cra el string filename
                string fileName = _filename + ".json";
                //aqui se hace la ruta paara guardar el Json en su respeectiva carpeta
                string filepath= Path.Combine(Application.dataPath + "/materiales/JSONS/", fileName);
                //Se escribe el Json en el archivo con el write text que muestra la info en forma de texto
                File.WriteAllText(filepath, JSONData);
                //confirmacion del guardado
                Debug.Log("Json almacenado en la direccion: "+ filepath);
            }
            else 
            {
                //mensaje que muestra por error queno hay datos 
                Debug.Log("ERROR - FyleSystem: _data is null, check for param [ string JSONData]");

            }
        }
        else
        {
            //mensaje que dice que no hay datos y se cheque el data del objeto 
            Debug.Log("ERROR - FyleSystem: _data is null, check for param [object _data]");
        }
    }
   //metodo que carga datos y puede devolverlos como en cualquier tipo el cual toma filename y duevuelve en tipo T
    public T LoadFromJSON<T>(string _filename) where T: new()
    {
        // secrea un dato del tipo generico T
        T dato = new T();
        //se carga la ruta de la cual va a cargar el archivp agarrando el objeto de la carpeta 
        string path = Application.dataPath+ "/materiales/JSONS/" + _filename+ ".json";
        //se hace un texto vacio para poder tener los datos de Json leidos
        string JSONdata = "";
        // comprueba si existe el Json en donde se le indico la ruta
        if (File.Exists(path)) 
        { 
            //lee el contenido del jason de path y la manda a Json data
         JSONdata = File.ReadAllText(path);
            //se pone la informacion de la consola del Jsondata y la informacion que obtuvo
            Debug.Log("JSON STRING: "+ JSONdata);
        }
        //comprueba si el Json tiene contenido
        if(JSONdata.Length != 0)
        {
            //Sobre escribe la informacion de dato con los valores que JsonData obtuvo anteriormente
            JsonUtility.FromJsonOverwrite(JSONdata, dato);
        }
        else
        {
            // mensaje que manda cuando o hay datos en JsonData
            Debug.LogWarning("ERROR - FyleSystem: JsonData is null, check for param [ string JSONData]");
        }
        // devuelve dato la informacion de que se sobreescribio anteriormente
        return dato;
    }
   
}
