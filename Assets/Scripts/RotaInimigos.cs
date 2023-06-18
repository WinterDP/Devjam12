using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaInimigos : MonoBehaviour
{
    [SerializeField] private Transform[] lugar;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float velocidade;
    private int numero;
    private bool volta;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        numero = 0;
        volta = false;
    }
    private void Update()
    {
        if (!volta)
        {
            if (Vector2.Distance(lugar[numero].position, gameObject.transform.position) > 0.3f)
            {
                if ((lugar[numero].position.x - gameObject.transform.position.x > 0.1f))
                {
                    rb.velocity = new Vector2(velocidade, 0);
                }
                if ((lugar[numero].position.x - gameObject.transform.position.x < -0.1f))
                {
                    rb.velocity = new Vector2(-velocidade, 0);
                }
                if (lugar[numero].position.y - gameObject.transform.position.y > 0.1f)
                {
                    rb.velocity = new Vector2(0, velocidade);
                }
                if (lugar[numero].position.y - gameObject.transform.position.y < -0.1f)
                {
                    rb.velocity = new Vector2(0, -velocidade);
                }
            }
            else
            {
                numero++;
            }
            if (numero == lugar.Length)
            {
                volta = true;
            }
        }
        else
        {
            if (numero == lugar.Length)
            {
                numero--;
            }
            if (Vector2.Distance(lugar[numero].position, gameObject.transform.position) > 0.3f)
            {
                if ((lugar[numero].position.x - gameObject.transform.position.x > 0.1f))
                {
                    rb.velocity = new Vector2(velocidade, 0);
                }
                if ((lugar[numero].position.x - gameObject.transform.position.x < -0.1f))
                {
                    rb.velocity = new Vector2(-velocidade, 0);
                }
                if (lugar[numero].position.y - gameObject.transform.position.y > 0.1f)
                {
                    rb.velocity = new Vector2(0, velocidade);
                }
                if (lugar[numero].position.y - gameObject.transform.position.y < -0.1f)
                {
                    rb.velocity = new Vector2(0, -velocidade);
                }
            }
            else
            {
                numero--;
            }
            if (numero == 0)
            {
                volta = false;
            }
        }
    }
}