using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Mensajes Prefabs")]
    [SerializeField] private GameObject EsbirroMensajePrefab;
    [SerializeField] private GameObject EsbirroMensajeVacioPrefab;
    [SerializeField] private GameObject RespuestasBotonPrefab;
    [SerializeField] private GameObject RespuestasVacioPrefab;
    [SerializeField] private GameObject RespuestaPrefab;

    [Header("Canvas donde instanciar")]
    [SerializeField] private GameObject ContenidoMensajesEsbirros;
    [SerializeField] private GameObject ContenidoMensajesNuestros;

    //Guardar el dato de la pregunta encontrada
    private int NumeroPregunta=0;

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
        GenerarPreguntaYRespuestas();
        ObjetoContenidos = GameObject.FindGameObjectWithTag("Content");
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


    void GenerarPreguntaYRespuestas()
    {

        //Esbirro
        GameObject ObjetoTemporal = Instantiate(EsbirroMensajePrefab);//texto (Aun queda por cambiar el texto, se cambia siguiente a este)
        ObjetoTemporal.transform.parent = ContenidoMensajesEsbirros.transform;
        ObjetoTemporal = Instantiate(EsbirroMensajeVacioPrefab); //Vacio
        ObjetoTemporal.transform.parent = ContenidoMensajesEsbirros.transform;
        //Nuestro
        ObjetoTemporal = Instantiate(RespuestasVacioPrefab); //Vacio
        ObjetoTemporal.transform.parent = ContenidoMensajesNuestros.transform;
        ObjetoTemporal = Instantiate(RespuestasBotonPrefab); //texto (Aun queda por cambiar el texto, se cambia siguiente a este)
        ObjetoTemporal.transform.parent = ContenidoMensajesNuestros.transform;

    }


    public void EliminarBotonesYGenerarTexto(int numeroRespuesta)
    {
        Transform parentTransform = ContenidoMensajesNuestros.transform;


        //Aqui cojo el hijo y lo elimino
        int numeroHijo = parentTransform.childCount - 1;
        Destroy(parentTransform.GetChild(numeroHijo).gameObject);

        //aqui en seria utilizar el numeroRespuesta y sacar el texto apropiado
        GameObject ObjetoTemporal = Instantiate(RespuestaPrefab);
        ObjetoTemporal.transform.parent = ContenidoMensajesNuestros.transform;
        AplicarEstadisticas();

        //cargar de nuevo los mensajes

        GenerarPreguntaYRespuestas();

        //aplicar movimiento al contenido

        ObjetoContenidos.GetComponent<RefreshHeighttByContent>().ChangePositionY();


    }

    void AplicarEstadisticas()
    {
        //por hacer


    }





    /*
    Numero random para coger pregunta random del csv
    Coger este texto para meterselo a la pregunta instanciada
    */




}
