using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start() 
    {
        AudioManager.Instance.PlaySound("Musica Menu");
        Debug.Log("Tocando");    
    }
    public void PlayGame()
    {
        AudioManager.Instance.PlaySound("Botao");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.Instance.StopSound("Musica Menu");
    }

    public void QuitGame()
    {   
        AudioManager.Instance.PlaySound("Botao");
        Application.Quit();
    }
}
