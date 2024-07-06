using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [Header("Sliders")]
    public Slider masterSlider; // asignar la barra de volumen master
    public Slider musicSlider; // asigar la barra de volumen musica
    public Slider soundSlider; // asignar la barra de volumen audio

    private const string MusicVolumeKey = "MusicVolume"; // clave para guardar el volumen musica
    private const string SoundVolumeKey = "SoundVolume"; // clave para guardar el volumen sonido
    private const string MasterVolumeKey = "MasterVolume"; // clave para guardar el volumen sonido




    private void Start()
    {
        //cargar el Musica volumen
        if (PlayerPrefs.HasKey(MusicVolumeKey)) 
        {
            float savedVolume = PlayerPrefs.GetFloat(MusicVolumeKey);
            musicSlider.value = savedVolume;
        }
        else
        {
            musicSlider.value = 1.0f; 
        }

        //Cargar el Sonido volumen
        if (PlayerPrefs.HasKey(SoundVolumeKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(SoundVolumeKey);
            soundSlider.value = savedVolume;
        }
        else 
        {
            soundSlider.value = 1.0f; 
        }

        if (PlayerPrefs.HasKey(MasterVolumeKey)) 
        {
            float savedVolume = PlayerPrefs.GetFloat(MasterVolumeKey);
            AudioListener.volume = savedVolume;
            masterSlider.value = savedVolume;
        }
        else 
        {
            AudioListener.volume = 1.0f;
            masterSlider.value = 1.0f; 
        }


    }



    public void SetVolume(int tipoAudioCambiar) 
    {
        //tipoAudioCambiar, 0: master, 1: Musica, 2: Audio.
        float valorTemporal = 1.0f; 
        switch(tipoAudioCambiar)
        {
            case 0: //master
                valorTemporal = masterSlider.value;
                AudioListener.volume = valorTemporal;
                PlayerPrefs.SetFloat(MasterVolumeKey, valorTemporal);
                PlayerPrefs.Save();
                break;

            case 1: //Musica
                valorTemporal = musicSlider.value;
                PlayerPrefs.SetFloat(MusicVolumeKey, valorTemporal);
                PlayerPrefs.Save(); 
                break;


            case 2: //Audio
                valorTemporal = soundSlider.value;
                PlayerPrefs.SetFloat(SoundVolumeKey, valorTemporal);
                PlayerPrefs.Save();
                break;
            default:
                Debug.Log("Error, no hay volumen asociado a ese numero"); 
                break; 

        }
        
    }

}
