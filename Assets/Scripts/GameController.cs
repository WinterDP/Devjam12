using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform jogador;
    [SerializeField] private Transform[] lugar;
    [SerializeField] private SpriteRenderer[] ativa;
    [SerializeField] private int minimo;
    public static bool chave = false;
    private float[] distancia;
    private int menor;
    public bool IsSeeing;
    private void Start()
    {
        menor = 0;
        chave = false;
        distancia = new float[lugar.Length];
    }
    private void FixedUpdate()
    {
        if(lugar.Length != 0)
        {
            NearestEnemy();
        }
    }

    public void NearestEnemy()
    {

        for (int i = 0; i < lugar.Length; i++)
        {
            distancia[i] = CalculaDistancia(i);
            if (distancia[menor] > distancia[i])
            {
                menor = i;
            }
        }
        if (minimo > distancia[menor])
        {
            for (int j = 0; j < lugar.Length; j++)
            {
                if (j == menor)
                {
                    ativa[menor].enabled = true;
                    IsSeeing = true;
                    if (ativa[menor].gameObject.CompareTag("Enemy"))
                    {
                        AudioManager.Instance.PlaySound("Som Inimigo");
                    }

                }
                else
                {
                    ativa[j].enabled = false;
                    IsSeeing = true;
                    if (ativa[j].gameObject.CompareTag("Enemy"))
                    {
                        AudioManager.Instance.PlaySound("Som Inimigo");
                    }
                }
                
            }
        }
        else
        {
            for (int j = 0; j < lugar.Length; j++)
            {
                ativa[j].enabled = false;
                IsSeeing = false;
            }
        }
    }
    private float CalculaDistancia(int i)
    {
        return Vector3.Distance(jogador.position, lugar[i].position);
    }
}
