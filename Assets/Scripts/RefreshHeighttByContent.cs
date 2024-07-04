using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefreshHeighttByContent : MonoBehaviour
{
    [SerializeField] private GameObject ContentMaster;
    [SerializeField] private GameObject ContentChild;

    public int CantidadDeSuma = 100; 


    private void Update()
    {
        UpdateRectTransform(); 
    }


    void UpdateRectTransform() 
    {

        Vector2 sizeHijo = ContentChild.GetComponent<RectTransform>().sizeDelta;
        Vector2 sizePadre = ContentMaster.GetComponent<RectTransform>().sizeDelta;
        sizePadre.y = sizeHijo.y;
        ContentMaster.GetComponent<RectTransform>().sizeDelta = sizePadre; 

    }


    public void ChangePositionY() 
    {

        //add espacio para que el usuario pueda subir

        //Debug.Log(ContentMaster.GetComponent<RectTransform>().anchoredPosition);


        Vector3 positionContent = ContentMaster.GetComponent<RectTransform>().anchoredPosition;
        positionContent.y += CantidadDeSuma;
        ContentMaster.GetComponent<RectTransform>().anchoredPosition = positionContent; 


    }
}
