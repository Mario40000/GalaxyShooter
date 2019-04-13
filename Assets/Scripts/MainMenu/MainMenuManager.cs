using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //Metodos para cargar las escenas

    public void LoadSingle ()
    {
        SceneManager.LoadScene("SinglePlayer");
    }

    public void LoadCoop ()
    {
        SceneManager.LoadScene("CoopMode");
    }
	
}
