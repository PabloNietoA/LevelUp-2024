using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    private int intelligence=50;
    private int madness=50;
    private int happiness=50;
    private int acolytes=0;

    private GameObject MadIcon;
    private GameObject IntIcon;
    private GameObject HapIcon;

    //Modifica los valores actuales de Inteligencia, Locra y Felicidad
    public void ModifyResource(string[] values){

        Animator hapAnim = HapIcon.GetComponent<Animator>();
        Animator madAnim = MadIcon.GetComponent<Animator>();
        Animator intAnim = IntIcon.GetComponent<Animator>();

        int hapVar = int.Parse(values[0]);
        happiness += hapVar;
        hapAnim.SetInteger("Increase", hapVar);

        int madVar = int.Parse(values[1]);
        madness += madVar;
        madAnim.SetInteger("Increase", madVar);

        int intVar = int.Parse(values[2]);
        intelligence += intVar;
        intAnim.SetInteger("Increase", intVar);

        acolytes += int.Parse(values[3]);

        hapAnim.SetTrigger("TriggerAnim");
        madAnim.SetTrigger("TriggerAnim");
        intAnim.SetTrigger("TriggerAnim");
    }

    public void SetResourceIcons(GameObject mad, GameObject intel, GameObject hap)
    {
        MadIcon = mad;
        IntIcon = intel;
        HapIcon = hap;
    }

    public void ShowResources(){
        Debug.Log("Int: "+intelligence+" Mad:"+madness+" Hap:"+happiness+" Acol: "+acolytes);
        private int intelligence=10;
        private int madness=10;
        private int happiness=10;
        private int acolyte=10;
/**
    //Modifica los valores actuales de Inteligencia, Locra y Felicidad
    public void ModifyResource(string[] values){
        for (int i = 0; i < values.Length; i++)
        {
            if(string.IsNullOrEmpty(values[i])){
                values[i] = "0";
            }

        }
        intelligence += int.Parse(values[0]);
        madness += int.Parse(values[1]);
        happiness += int.Parse(values[2]);
        //acolyte += int.Parse(values[3]);
    }
**/
    public void ShowResources(){
        Debug.Log("Int: "+intelligence+" Mad:"+madness+" Happy:"+happiness+" Acol: "+acolyte);
    }

    public int GetIntelligence(){
        return intelligence;
    }

    public int GetMadness(){
        return madness;
    }

    public int GetHappines(){
        return happiness;
    }
}
