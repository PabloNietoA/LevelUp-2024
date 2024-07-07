using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveLanguage : MonoBehaviour
{
    [Header("Botones")]
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject options;    
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject languageText;
    [SerializeField] private GameObject sonido;
    [SerializeField] private GameObject master;
    [SerializeField] private GameObject SFX;  
    [SerializeField] private GameObject music;
    [SerializeField] private GameObject spanishText;
    [SerializeField] private GameObject englishText;
    [SerializeField] private GameObject catalanaText;
    [SerializeField] private GameObject back;
    [SerializeField] private GameObject back2;
    [SerializeField] private GameObject back3;


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("language")){
            if(PlayerPrefs.GetString("language")=="ENG"){
                ModifyToEn();
            }
            if(PlayerPrefs.GetString("language")=="CAT"){
                ModifyToCat();
            }
        }else{
            ModifyToEs();
        }
    }

    public void ModifyToCat(){
        start.GetComponent<TMP_Text>().text = "Jugar";
        options.GetComponent<TMP_Text>().text = "Opcions";
        exit.GetComponent<TMP_Text>().text = "Sortir";
        languageText.GetComponent<TMP_Text>().text = "Idioma";
        sonido.GetComponent<TMP_Text>().text = "So";
        master.GetComponent<TMP_Text>().text = "Volum";
        SFX.GetComponent<TMP_Text>().text = "Volum d´Efectes";
        music.GetComponent<TMP_Text>().text = "Volum de Musica";
        spanishText.GetComponent<TMP_Text>().text = "Espanyol";
        englishText.GetComponent<TMP_Text>().text = "Angles";
        catalanaText.GetComponent<TMP_Text>().text = "Catala";
        back.GetComponent<TMP_Text>().text = "Tornar";
        back2.GetComponent<TMP_Text>().text = "Tornar";
        back3.GetComponent<TMP_Text>().text = "Tornar";
        PlayerPrefs.SetString("language","CAT");
        PlayerPrefs.Save();
    }

    public void ModifyToEn(){
        start.GetComponent<TMP_Text>().text = "Start";
        options.GetComponent<TMP_Text>().text = "Options";
        exit.GetComponent<TMP_Text>().text = "Exit";
        languageText.GetComponent<TMP_Text>().text = "Language";
        sonido.GetComponent<TMP_Text>().text = "Sound";
        master.GetComponent<TMP_Text>().text = "Volume";
        SFX.GetComponent<TMP_Text>().text = "SFX Volume";
        music.GetComponent<TMP_Text>().text = "Music Volume";
        spanishText.GetComponent<TMP_Text>().text = "Spanish";
        englishText.GetComponent<TMP_Text>().text = "English";
        catalanaText.GetComponent<TMP_Text>().text = "Catalana";
        back.GetComponent<TMP_Text>().text = "Back";
        back2.GetComponent<TMP_Text>().text = "Back";
        back3.GetComponent<TMP_Text>().text = "Back";
        PlayerPrefs.SetString("language","ENG");
        PlayerPrefs.Save();
    }

    public void ModifyToEs(){
        start.GetComponent<TMP_Text>().text = "Jugar";
        options.GetComponent<TMP_Text>().text = "Opciones";
        exit.GetComponent<TMP_Text>().text = "Salir";
        languageText.GetComponent<TMP_Text>().text = "Idioma";
        sonido.GetComponent<TMP_Text>().text = "Sonido";
        master.GetComponent<TMP_Text>().text = "Volumen General";
        SFX.GetComponent<TMP_Text>().text = "Volumen de Efectos";
        music.GetComponent<TMP_Text>().text = "Volumen de Musica";
        spanishText.GetComponent<TMP_Text>().text = "Español";
        englishText.GetComponent<TMP_Text>().text = "Ingles";
        catalanaText.GetComponent<TMP_Text>().text = "Catalan";
        back.GetComponent<TMP_Text>().text = "Volver";
        back2.GetComponent<TMP_Text>().text = "Volver";
        back3.GetComponent<TMP_Text>().text = "Volver";
        PlayerPrefs.SetString("language","ESP");
        PlayerPrefs.Save();
    }
}
