using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    
    void Start()
    {
        GenerarPreguntaYRespuestas(); 
    }

   
    void Update()
    {
        
    }

    void GenerarPreguntaYRespuestas()
    {
        //Esbirro
        GameObject ObjetoTemporal = Instantiate(EsbirroMensajePrefab);
        ObjetoTemporal.transform.parent = ContenidoMensajesEsbirros.transform; 
        ObjetoTemporal = Instantiate(EsbirroMensajeVacioPrefab);
        ObjetoTemporal.transform.parent = ContenidoMensajesEsbirros.transform;
        //Nuestro
        ObjetoTemporal = Instantiate(RespuestasVacioPrefab);
        ObjetoTemporal.transform.parent = ContenidoMensajesNuestros.transform; 
        ObjetoTemporal = Instantiate(RespuestasBotonPrefab);
        ObjetoTemporal.transform.parent = ContenidoMensajesNuestros.transform; 

    }


    public void EliminarBotonesYGenerarTexto(int numeroRespuesta)
    {
        Transform parentTransform = ContenidoMensajesNuestros.transform;
        Debug.Log(parentTransform.childCount);
        
    }

    /*
    Numero random para coger pregunta random del csv
    Coger este texto para meterselo a la pregunta instanciada
    */




}
