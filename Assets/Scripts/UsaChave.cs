using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsaChave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("E"))
            {
                if (GameController.chave)
                {
                    GameController.chave = false;
                    gameObject.SetActive(false);
                }
            }

        }
    }
}
