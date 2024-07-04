using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    private int intelligence=10;
    private int madnes=10;
    private int happiness=10;
    private int acolyte=10;

    //Modifica los valores actuales de Inteligencia, Locra y Felicidad
    public void ModifyResource(string[] values){
        for (int i = 0; i < values.Length; i++)
        {
            if(string.IsNullOrEmpty(values[i])){
                values[i] = "0";
            }
            
        }
        intelligence += int.Parse(values[0]);
        madnes += int.Parse(values[1]);
        happiness += int.Parse(values[2]);
        //acolyte += int.Parse(values[3]);
    }

    public void ShowResources(){
        Debug.Log("Int: "+intelligence+" Mad:"+madnes+" Happy:"+happiness+" Acol: "+acolyte);
    }
}
