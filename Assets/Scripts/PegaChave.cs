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
            GameController.chave = true;
            gameObject.transform.position = move;
        }
    }
}
