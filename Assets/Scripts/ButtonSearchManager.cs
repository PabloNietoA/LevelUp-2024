using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSearchManager : MonoBehaviour
{

    [SerializeField]GameObject manager;

    private void Start() 
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
    }
    public void SearchManager(int respuesta)
    {
        manager.GetComponent<GameManager>().EliminarBotonesYGenerarTexto(respuesta); 
    }
}
