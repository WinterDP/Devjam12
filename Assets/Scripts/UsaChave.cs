using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsaChave : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameController.chave)
            {
                gameObject.GetComponent<Animator>().Play("DoorKeyOpen");
                AudioManager.Instance.PlaySound("Porta Chave");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                GameController.chave = false;
                //gameObject.SetActive(false);
            }
        }
    }
}
