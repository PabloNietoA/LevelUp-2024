using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogicAnswer : MonoBehaviour
{
    private List<Dictionary<string,string>> questionData = new List<Dictionary<string,string>>();
    private string[] keys;

    // Start is called before the first frame update
    void Start()
    {
        LoadCSV();
        string[] dato = ModifyValues(3,"R1");
        Debug.Log(dato[0]+"---"+dato[1]+"---"+dato[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Funcion que cargara el CSV
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

    //Modificar los valores(Actualmente los Visualizo)
    string[] ModifyValues(int questionIndex, string response){
        Dictionary<string, string> entry = questionData[questionIndex];
        string[] values = new string[3];
        Debug.Log("Respuesta: "+response);
        if(response == "Respuesta1"){
            values[0] = entry["ValorF1"];
            values[1] = entry["ValorL1"];
            values[2] = entry["ValorI1"];

            return values;
        }else if(response =="Respuesta2"){
            values[0] = entry["ValorF2"];
            values[1] = entry["ValorL2"];
            values[2] = entry["ValorI2"];
            
            return values;
        }else{
            values[0] = entry["ValorF1"];
            values[1] = entry["ValorL2"];
            values[2] = entry["ValorI2"];

            return values;
        }
    }
}
