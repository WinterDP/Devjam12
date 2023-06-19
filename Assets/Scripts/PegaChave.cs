using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegaChave : MonoBehaviour
{
    [SerializeField] private Vector3 move;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!GameController.chave)
            {
                GameController.chave = true;
                gameObject.transform.position = move;
            }
        }
    }
}
