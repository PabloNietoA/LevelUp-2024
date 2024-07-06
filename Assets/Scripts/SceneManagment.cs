using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    


    public void ChangeSceneByName(string nombreEscena) 
    {

        SceneManager.LoadScene(nombreEscena);
    }

    public void ChangeSceneByIndex(int numeroEscena)
    {
        SceneManager.LoadScene(numeroEscena);
    }

    public void CloseGame() 
    {
        Application.Quit(); 
    }



}
