using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    private int intelligence=50;
    private int madness=50;
    private int happiness=50;
    private int acolytes=5;

    private int percentage;

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

        AddAcolyte();
        acolytes += int.Parse(values[3]);

        ModifyMaxMin();

        hapAnim.SetTrigger("TriggerAnim");
        madAnim.SetTrigger("TriggerAnim");
        intAnim.SetTrigger("TriggerAnim");
        
        Image hapImg = HapIcon.GetComponent<Image>();
        Sprite[] hapImages = UnityEngine.Resources.LoadAll<Sprite>("Happiness");

        if (happiness <= 30)
        {
            hapImg.sprite = hapImages[0];
            percentage = -35;
        }
        else if (happiness <= 65)
        {
            hapImg.sprite = hapImages[1];
            percentage = 35;
        }
        else
        {
            hapImg.sprite = hapImages[2];
            percentage = 75;
        }

        Image intImg = IntIcon.GetComponent<Image>();
        Sprite[] intImages = UnityEngine.Resources.LoadAll<Sprite>("Intelligence");

        if (intelligence <= 10)
        {
            intImg.sprite = intImages[0];
        }
        else if (intelligence <= 35)
        {
            intImg.sprite = intImages[1];
        }
        else if (intelligence <= 65)
        {
            intImg.sprite = intImages[2];
        }
        else if (intelligence <= 85)
        {
            intImg.sprite = intImages[3];
        }
        else
        {
            intImg.sprite = intImages[4];
        }

        Image madImg = MadIcon.GetComponent<Image>();
        Sprite[] madImages = UnityEngine.Resources.LoadAll<Sprite>("Madness");

        if (madness <= 10)
        {
            madImg.sprite = madImages[0];
        }
        else if (madness <= 35)
        {
            madImg.sprite = madImages[1];
        }
        else if (madness <= 65)
        {
            madImg.sprite = madImages[2];
        }
        else if (madness <= 85)
        {
            madImg.sprite = madImages[3];
        }
        else
        {
            Image[] bigImage = MadIcon.GetComponentsInChildren<Image>();
            madImg.color = new Color(255, 255, 255, 0);
            bigImage[1].color = new Color(255, 255, 255, 255);
        }

        if (madness <= 85)
        {
           Image[] bigImage = MadIcon.GetComponentsInChildren<Image>();
            madImg.color = new Color(255, 255, 255, 255);
            bigImage[1].color = new Color(255, 255, 255, 0);
        }
    }

    void AddAcolyte(){
        percentage= (happiness-50)+5;
        acolytes += (acolytes*percentage/100);
    }

    public void SetResourceIcons(GameObject mad, GameObject intel, GameObject hap)
    {
        MadIcon = mad;
        IntIcon = intel;
        HapIcon = hap;
    }

    void ModifyMaxMin(){
        if (happiness < 0)
        {
            happiness=0;
        }
        if (madness < 0)
        {
            madness= 0;
        }
        if (intelligence < 0)
        {
            intelligence = 0;
        }

        if (happiness > 100)
        {
            happiness=100;
        }
        if (madness >100)
        {
            madness= 100;
        }
        if (intelligence >100)
        {
            intelligence = 100;
        }
    }
    public void ShowResources(){
        Debug.Log("Int: "+intelligence+" Mad:"+madness+" Hap:"+happiness+" Acol: "+acolytes);
    }

    public int GetMadness(){
        return madness;
    }

    public int GetIntelligence(){
        return intelligence;
    }

    public int GetHappines(){
        return happiness;
    }

    public int GetAcolyte(){
        return acolytes;
    }
}
