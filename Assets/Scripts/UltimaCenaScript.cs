using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UltimaCenaScript : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;
    private int contador = 0;
    private void Start()
    {
    }
    private void Update()
    {
        Debug.Log(contador);
        if(contador > 300)
        {
            inimigos[1].SetActive(true);
        }
        if (contador > 600)
        {
            inimigos[2].SetActive(true);
            inimigos[3].SetActive(true);
        }
        if(contador > 1200)
        {
            for (int i = 0; i<20; i++)
            {
                inimigos[i].SetActive(true);
            }
        }
        if(contador > 2000)
        {
            SceneManager.LoadScene("PerderJogo");
        }
        contador++;
    }
}
