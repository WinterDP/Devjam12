using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer imagem;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        SetAnimation(movement.x, movement.y);
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }
    private void SetAnimation(float x, float y)
    {
        if ((x != 0)||(y != 0))
        {
            if (x > 0)
            {
                anim.SetBool("andandoHorizontal", true);
                imagem.flipX = false;
            }
            if (x < 0)
            {
                anim.SetBool("andandoHorizontal", true);
                imagem.flipX = true;
            }
            if (y > 0)
            {
                anim.SetBool("andandoVertical", true);
            }
            if (y < 0)
            {
                anim.SetBool("andandoVertical", true);
            }
        }
        else
        {
            anim.SetBool("andandoHorizontal", false);
            anim.SetBool("andandoVertical", false);
            imagem.flipX = false;
        }
    }
}
