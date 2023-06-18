using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegueJogador : MonoBehaviour
{
    [SerializeField] private Transform segue;
    void Update()
    {
        transform.position = segue.position;
    }
}
