using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Animator anim;
    [SerializeField] private float speedLimit = 0.7f;
    [SerializeField] private SpriteRenderer imagem;
    [SerializeField] private Transform FacingDirectionTransform;
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


        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement.x != 0 || movement.y != 0)
        {
            if (movement.x != 0 && movement.y != 0)
            {
                movement.x *= speedLimit;
                movement.y *= speedLimit;
            }
            rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }


    }
    private void SetAnimation(float x, float y)
    {
        if (x > 0)
        {
            anim.SetBool("andandoHorizontal", true);
            anim.SetBool("andandoVertical", false);
            FacingDirectionTransform.localPosition = new Vector3(3, 0, 0);
            imagem.flipX = false;
        }
        else if (x < 0)
        {
            anim.SetBool("andandoHorizontal", true);
            anim.SetBool("andandoVertical", false);
            FacingDirectionTransform.localPosition = new Vector3(-3, 0, 0);
            imagem.flipX = true;
        }
        else if (y > 0)
        {
            anim.SetBool("andandoVertical", true);
            anim.SetBool("andandoHorizontal", false);
            FacingDirectionTransform.localPosition = new Vector3(0, 3, 0);
        }
        else if (y < 0)
        {
            anim.SetBool("andandoVertical", true);
            anim.SetBool("andandoHorizontal", false);
            FacingDirectionTransform.localPosition = new Vector3(0, -3, 0);
        }

        else
        {
            anim.SetBool("andandoHorizontal", false);
            anim.SetBool("andandoVertical", false);
            imagem.flipX = false;
        }
    }
}
