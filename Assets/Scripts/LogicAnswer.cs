using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class LogicAnswer : MonoBehaviour
{
    private List<Dictionary<string,string>> questionData = new List<Dictionary<string,string>>();
    private string[] keys;

    private int index = 2;

    //Resources sinews;


    private void Awake() {
        //sinews = FindObjectOfType<Resources>();
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadCSV();
        LoadCSVLine(index);
        string[] dato = ModifyValues(index,"R1");
        Debug.Log(dato[0]+"---"+dato[1]+"---"+dato[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Funcion que cargara el CSV entero
    void LoadCSV (){
        string filePath = Path.Combine(Application.dataPath,"archivo.csv");
        if(File.Exists(filePath)){
            string[] data = File.ReadAllLines(filePath);
            keys = data[0].Split(",");

            for (int i = 1; i < data.Length; i++)
            {
                string[] values = data[i].Split(",");
                Dictionary<string,string> entry = new Dictionary<string,string>();

                for (int j = 0; j < keys.Length; j++)
                {
                    entry[keys[j]] = values[j];
                }
                questionData.Add(entry);
            }
        }else
        {
            Debug.Log("No hay Archivo CSV");
        }

    }

    //Funcion que cargara una Linea del CSV especificada
    void LoadCSVLine (int lineNumber){
        if(lineNumber < questionData.Count){
            Dictionary<string,string> lineData = questionData[lineNumber];
            if(lineData !=null ){
                foreach (KeyValuePair<string,string> item in lineData)
                {
                    Debug.Log("Linea: "+ (lineNumber+1)+" : "+ item.Key+" : "+ item.Value);
                }
            }
            else{
                Debug.Log("Linea no encotrada");
            }
        }else
        {
            Debug.Log("No hay Archivo CSV");
        }

    }

    /**
    //Funcion que averiguaria el Index de la pregunta
    int GetQuestionIndex(string question){
        for (int i = 0; i < questionData.Count; i++)
        {
            if(questionData[i]["Pregunta"]== question){
                return i;
            }
        }
        return 0;
    }
    **/

    //Funcion del Boton
    public void OnAnswerSelected(string respuesta){
        ModifyValues(index,respuesta);
    }

    //Modificar los valores(Actualmente los Visualizo)
    string[] ModifyValues(int questionIndex, string response){
        Dictionary<string, string> entry = questionData[questionIndex];
        string[] values = new string[3];
        Debug.Log("Respuesta: "+response);
        if(response == "Respuesta1"){
            //Valores de la Respuesta 1
            values[0] = entry["ValorF1"];
            values[1] = entry["ValorL1"];
            values[2] = entry["ValorI1"];

            return values;
        }else if(response =="Respuesta2"){
            //Valores de la Respuesta 2
            values[0] = entry["ValorF2"];
            values[1] = entry["ValorL2"];
            values[2] = entry["ValorI2"];
            
            return values;
        }else{
            //Valores de Respuesta Random
            values[0] = entry["ValorF1"];
            values[1] = entry["ValorL2"];
            values[2] = entry["ValorI2"];

            return values;
        }
        //sinews.ModifyResource(values);
    }
}
