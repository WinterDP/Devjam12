using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start() 
    {
        FindObjectOfType<AudioManager>().PlaySound("Musica Menu");
        Debug.Log("Tocando");    
    }
    public void PlayGame()
    {   
        FindObjectOfType<AudioManager>().PlaySound("Botao");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<AudioManager>().StopSound("Musica Menu");
    }

    public void QuitGame()
    {   
        FindObjectOfType<AudioManager>().PlaySound("Botao");
        Application.Quit();
    }
}
