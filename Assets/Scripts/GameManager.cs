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

    [SerializeField]private GameObject ObjetoContenidos;
    
    void Start()
    {
        GenerarPreguntaYRespuestas();
        ObjetoContenidos = GameObject.FindGameObjectWithTag("Content");
    }

   
    void Update()
    {
        
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
