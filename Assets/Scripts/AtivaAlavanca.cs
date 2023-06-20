using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaAlavanca : MonoBehaviour
{
    [SerializeField] private GameObject[] libera;
    [SerializeField] private Vector3 move;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < libera.Length; i++)
                {
                //libera[i].gameObject.SetActive(false);
                libera[i].GetComponent<Animator>().Play("OpenDoorLever");
                    
                libera[i].GetComponent<Collider2D>().enabled = false;
                libera[i].GetComponent<SpriteRenderer>().sortingOrder = 8;
            }
            gameObject.GetComponent<Animator>().Play("PullLever");
            gameObject.GetComponent<Collider2D>().enabled = false;
            AudioManager.Instance.PlaySound("Alavanca");
            AudioManager.Instance.PlaySound("Porta Alavanca");
            //gameObject.transform.position = move;
        }
    }
}
