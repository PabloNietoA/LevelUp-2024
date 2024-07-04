using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    private int intelligence=50;
    private int madnes=50;
    private int happiness=50;
    private int acolyte=0;

    //Modifica los valores actuales de Inteligencia, Locra y Felicidad
    public void ModifyResource(string[] values){
        happiness += int.Parse(values[0]);
        madnes += int.Parse(values[1]);
        intelligence += int.Parse(values[2]);
        acolyte += int.Parse(values[3]);
    }

    public void ShowResources(){
        Debug.Log(acolyte);
        Debug.Log("Int: "+intelligence+" Mad:"+madnes+" Happy:"+happiness+" Acol: "+acolyte);
    }
}
