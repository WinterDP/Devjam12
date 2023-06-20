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
    public bool jumpScareDone = false;
    private void Start()
    {
        menor = 0;
        chave = false;
        distancia = new float[lugar.Length];
        if (!AudioManager.Instance.IsPlayingSound("Musica Principal") && !AudioManager.Instance.IsPlayingSound("Ambiente"))
        {
            AudioManager.Instance.PlaySound("Musica Principal");
            AudioManager.Instance.PlaySound("Ambiente");
        }
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
                if (ativa[j] != null)
                {
                    if (j == menor)
                    {
                        ativa[menor].enabled = true;
                        IsSeeing = true;
                        if (ativa[menor].gameObject.CompareTag("Enemy") && !jumpScareDone)
                        {
                            if (!AudioManager.Instance.IsPlayingSound("Som Inimigo"))
                                AudioManager.Instance.PlaySound("Som Inimigo");

                            jumpScareDone = true;
                        }

                    }
                    else
                    {
                        ativa[j].enabled = false;
                        IsSeeing = true;
                        //jumpScareDone = false;
                    }
                }
                
                
            }
        }
        else
        {
            for (int j = 0; j < lugar.Length; j++)
            {
                if (ativa[j] != null)
                {
                    ativa[j].enabled = false;
                    IsSeeing = false;
                    jumpScareDone = false;
                }
                
            }
        }
    }
    private float CalculaDistancia(int i)
    {
        if (lugar[i] != null)
            return Vector3.Distance(jogador.position, lugar[i].position);

        else return Mathf.Infinity;
    }
}
