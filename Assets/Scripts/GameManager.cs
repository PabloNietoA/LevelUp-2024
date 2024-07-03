using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
  
    [SerializeField] private GameObject EsbirroMensajePrefab;
    [SerializeField] private GameObject RespuestasBotonPrefab;

    private List<Dictionary<string,string>> questionData = new List<Dictionary<string,string>>();
    private string[] keys;

    [SerializeField] TextMeshProUGUI questionText;
    TextMeshProUGUI answer1;
    TextMeshProUGUI answer2;

    private int questionIndex;

    Resources sinews;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadCSV();
        questionIndex = GetLine();
        LoadCSVLine(questionIndex);
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

    //Funcion que genera el index de la pregunta aleatoria
    int GetLine (){
        return Random.Range(1,questionData.Count);
    }

    //Funcion que cargara una Linea del CSV especificada
    void LoadCSVLine (int lineNumber){
        if(lineNumber < questionData.Count){
            Dictionary<string,string> lineData = questionData[lineNumber];
            if(lineData !=null ){
                foreach (KeyValuePair<string,string> item in lineData)
                {
                    ChargeNewMessage();
                    //Debug.Log("Linea: "+ (lineNumber+1)+" : "+ item.Key+" : "+ item.Value);
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

    void ChargeNewMessage()
    { 
        Dictionary<string, string> entry = questionData[questionIndex];
        string question = entry["Pregunta"];
        questionText.text = question;
    }


}
