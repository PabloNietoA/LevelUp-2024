using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
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
    [SerializeField] private GameObject canvasGame;
    [SerializeField] private GameObject canvasResume;
    [SerializeField] private GameObject ObjetoContenidos;
    [SerializeField] private GameObject ContenidoMensajesEsbirros;
    [SerializeField] private GameObject ContenidoMensajesNuestros;

    [Header("Recursos")]

    [SerializeField] private GameObject RecursoLocura;
    [SerializeField] private GameObject RecursoIntel;
    [SerializeField] private GameObject RecursoFelicidad;

    [Header("Color&Images Esbirros")]
    private string[] colors = {"#b3a1d4","#c0baf7","#e1bc93","#abc7e6","#ca89c8","#9ec29f"};
    private Sprite[] colorsimages;
    private Sprite[] images;

    [Header("Idioma")]

    [SerializeField] private string idioma = "ESP"; //ESP ENG CAT

    [SerializeField] private float tiempoEntrePreguntas = 5f;

    [SerializeField] private SceneManagment sceneManagmentObject;


    //Guardar el dato de la pregunta encontrada
    private int NumeroPregunta=0;

    private List<Dictionary<string,string>> questionData = new List<Dictionary<string,string>>();
    private string[] keys;

    string questionText;
    string shortAnswerText1;
    string shortAnswerText2;
    string answerText1;
    string answerText2;

    private int questionIndex;

    Resources sinews;

    private string nombreSecta;
    private int day=5;
    private int messageNumber=0;
    private int acolyteGoal=0;

    private int numPreguntas = 0;

    private void Awake() {
        sinews = FindObjectOfType<Resources>();
    }

    // Start is called before the first frame update
    void Start()
    {
        sinews.SetResourceIcons(RecursoLocura, RecursoIntel, RecursoFelicidad);
        LoadCSV();
        LoadMembersImage();
        questionIndex = GetLine();
        //LoadCSVLine(questionIndex);
        StartCoroutine(GenerarPreguntaYRespuestas());
        ObjetoContenidos = GameObject.FindGameObjectWithTag("Content");


    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadMembersImage (){
        images = UnityEngine.Resources.LoadAll<Sprite>("Images");
        colorsimages = UnityEngine.Resources.LoadAll<Sprite>("Background");
    }

    //Funcion que cargara el CSV entero
    void LoadCSV (){
        string filePath;
        filePath = Path.Combine(Application.dataPath + "/Textos", idioma+".tsv");
        /**if (idioma == "ESP")
        {
            filePath = Path.Combine(Application.dataPath + "/Textos", "ESP.tsv");
        }
        else if (idioma == "ENG")
        {
            filePath = Path.Combine(Application.dataPath + "/Textos", "ENG.tsv");
        }
        else if (idioma == "CAT")
        {
            filePath = Path.Combine(Application.dataPath + "/Textos", "CAT.tsv");
        }
        else filePath = "";**/
        if(File.Exists(filePath))
        {
            string[] data = File.ReadAllLines(filePath);
            keys = data[0].Split("\t");

            for (int i = 1; i < data.Length; i++)
            {
                string[] values = data[i].Split("\t");
                Dictionary<string,string> entry = new Dictionary<string,string>();

                for (int j = 0; j < keys.Length; j++)
                {
                    entry[keys[j]] = values[j];
                }
                questionData.Add(entry);
            }
        }
        else
        {
            Debug.Log("No hay Archivo CSV");
        }
    }

    //Funcion que genera el index de la pregunta aleatoria
    int GetLine (){
        return Random.Range(1,questionData.Count);
    }

    /*
    Numero random para coger pregunta random del csv
    Coger este texto para meterselo a la pregunta instanciada
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
    */

    void ChargeNewMessage()
    {
        if(messageNumber == 5){
            CheckFinals();
            FadeIn();
            Refresh();
            messageNumber = 0;
            day +=1;
        }
        Dictionary<string, string> entry = questionData[questionIndex];
        questionText = entry["Eventos"];
        messageNumber +=1;
    }

    void ChargeAnswers()
    {
        Dictionary<string, string> entry = questionData[questionIndex];
        shortAnswerText1 = entry["Respuesta1"];
        shortAnswerText2 = entry["Respuesta2"];
        answerText1 = entry["CortoR1"];
        if (answerText1 == "") answerText1 = entry["Respuesta1"];
        answerText2 = entry["CortoR2"];
        if (answerText2 == "") answerText2 = entry["Respuesta2"];
    }

    IEnumerator GenerarPreguntaYRespuestas()
    {
        ChargeNewMessage();
        ChargeAnswers();

        yield return new WaitForSeconds(tiempoEntrePreguntas);

        //Esbirro
        GameObject ObjetoTemporal = Instantiate(EsbirroMensajePrefab);//texto (Aun queda por cambiar el texto, se cambia siguiente a este)
        ObjetoTemporal.transform.parent = ContenidoMensajesEsbirros.transform;
        Image[] aux = ObjetoTemporal.GetComponentsInChildren<Image>();
        Color color = GenerateRandomColor();
        //aux[0].color = color;
        int imageNumber= Random.Range(0,colorsimages.Length);
        aux[0].sprite = colorsimages[imageNumber];
        imageNumber= Random.Range(0,images.Length);
        aux[2].sprite = images[imageNumber];
        ObjetoTemporal.GetComponentInChildren<TMP_Text>().text = questionText;

        ObjetoTemporal = Instantiate(EsbirroMensajeVacioPrefab); //Vacio
        ObjetoTemporal.transform.parent = ContenidoMensajesEsbirros.transform;


        //Nuestro
        ObjetoTemporal = Instantiate(RespuestasVacioPrefab); //Vacio
        ObjetoTemporal.transform.parent = ContenidoMensajesNuestros.transform;

        ObjetoTemporal = Instantiate(RespuestasBotonPrefab); //texto (Aun queda por cambiar el texto, se cambia siguiente a este)
        ObjetoTemporal.transform.parent = ContenidoMensajesNuestros.transform;
        TMP_Text[] text= ObjetoTemporal.GetComponentsInChildren<TMP_Text>();
        text[0].text= answerText1;
        text[1].text= answerText2;

        numPreguntas++;
        if (numPreguntas >= 3)
            ObjetoContenidos.GetComponent<RefreshHeighttByContent>().ChangePositionY();

    }

    Color GenerateRandomColor(){
        int t= Random.Range(0,colors.Length);
        Color color;
        ColorUtility.TryParseHtmlString(colors[t], out color);
        return color;
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
        if(numeroRespuesta == 1){
            ObjetoTemporal.GetComponentInChildren<TMP_Text>().text = answerText1;
        }else{
            ObjetoTemporal.GetComponentInChildren<TMP_Text>().text = answerText2;
        }


        ModifyValues(questionIndex,numeroRespuesta);
        questionIndex = GetLine();

        //cargar de nuevo los mensajes

        StartCoroutine(GenerarPreguntaYRespuestas());

        //aplicar movimiento al contenido

        //ObjetoContenidos.GetComponent<RefreshHeighttByContent>().ChangePositionY();


    }

    public void IntroducirNombreSecta(GameObject inputField)
    {
        TMP_InputField ifComp = inputField.GetComponent<TMP_InputField>();
        nombreSecta = ifComp.text;
        ifComp.interactable = false;
    }

    string[] ModifyValues(int questionIndex, int response){
        Dictionary<string, string> entry = questionData[questionIndex];
        string[] values = new string[4];
        if(response == 1){
            //Valores de la Respuesta 1
            values[0] = entry["FelicidadResp1"];
            values[1] = entry["LocR1"];
            values[2] = entry["IntR1"];
            values[3] = entry["VarMiem1"];
            if (values[3] == "") values[3] = "0";

            //return values;
        }else if(response == 2){
            //Valores de la Respuesta 2
            values[0] = entry["FelicidadResp2"];
            values[1] = entry["LocR2"];
            values[2] = entry["IntR2"];
            values[3] = entry["VarMiem2"];
            if (values[3] == "") values[3] = "0";
            //return values;
        }
        else{
            //Valores de Respuesta Random
            values[0] = entry["FelicidadResp1"];
            values[1] = entry["LocR2"];
            values[2] = entry["IntR2"];
            values[3] = entry["VarMiem1"];
            if (values[3] == "") values[3] = "0";
            //return values;
        }
        sinews.ModifyResource(values);
        sinews.ShowResources();

        return values;
    }
    void CheckFinals(){
        CheckMad();
        CheckInt();
        if(day == 0){
            CheckAcolyte();
        }
    }

    void FadeIn()
    {
        canvasGame.SetActive(false);
        canvasResume.SetActive(true);
    }

    public void FadeOut()
    {
        canvasGame.SetActive(true);
        canvasResume.SetActive(false);
    }

    void Refresh(){
        foreach (Transform child in ContenidoMensajesEsbirros.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in ContenidoMensajesNuestros.transform)
        {
            Destroy(child.gameObject);
        }
    }

    //Cambiar esto vic, no te pierdas
    void CheckMad(){
        if(sinews.GetMadness()==100){
            sceneManagmentObject.ChangeSceneByName("Mad100");
        }
        if(sinews.GetMadness()==0){
            sceneManagmentObject.ChangeSceneByName("Mad0");
        }
    }
    void CheckInt(){
        if(sinews.GetIntelligence()==100){
            sceneManagmentObject.ChangeSceneByName("Int100");
        }
        if(sinews.GetIntelligence()==0){
            sceneManagmentObject.ChangeSceneByName("Int0");
        }
    }
    void CheckAcolyte(){
        if(sinews.GetAcolyte()==acolyteGoal){
            sceneManagmentObject.ChangeSceneByName("Win");
        }
        else{
            sceneManagmentObject.ChangeSceneByName("Lose");
     
        }
    }
    /**
    string[] ModifyValues(int questionIndex, int response){
        Dictionary<string, string> entry = questionData[questionIndex];
        string[] values = new string[4];
        Debug.Log("Respuesta: "+response);
        Debug.Log("OK");
        if(response == 1){
            Debug.Log("OKKKKKK");
            //Valores de la Respuesta 1
            values[0] = entry["FelicidadResp1"];
            values[1] = entry["LocR1"];
            values[2] = entry["IntR1"];
            values[3] = entry["VarMiem1"];
            if (values[3] == "") values[3] = "0";

            //return values;
        }else if(response == 2){
            Debug.Log("Noooooo");
            //Valores de la Respuesta 2
            values[0] = entry["FelicidadResp2"];
            values[1] = entry["LocR2"];
            values[2] = entry["IntR2"];
            values[3] = entry["VarMiem2"];
            if (values[3] == "") values[3] = "0";
            //return values;
        }
        else{
            Debug.Log("yeyeyeyeye");
            //Valores de Respuesta Random
            values[0] = entry["FelicidadResp1"];
            values[1] = entry["LocR2"];
            values[2] = entry["IntR2"];
            values[3] = entry["VarMiem1"];
            if (values[3] == "") values[3] = "0";
            //return values;
        }
        sinews.ModifyResource(values);
        sinews.ShowResources();

        return values;
    }**/

}
