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
        string dato = ModifyValues(2,"R1");
        Debug.Log("dato");
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

    string ModifyValues(int questionIndex, string response){
        Dictionary<string, string> entry = questionData[questionIndex];
        if(response == "Res1"){
            return entry["Fel1"];
        }else if(response =="Res2"){
            return entry["Fel2"];
        }else{
            return "Random";
        }
    }
}
