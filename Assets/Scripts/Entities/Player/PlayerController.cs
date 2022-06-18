using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed = 1f;

    public PlayerInput input;
    private Rigidbody2D rb;
    private bool alive = true;
    private bool canMove = true;

    public AudioClip deathSFX;
    private AudioSource audioSource;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (canMove)
            Movement();
    }

    void Movement()
    {
        animator.SetFloat("Speed", Mathf.Abs(input.horizontal) * movespeed);
        if (input.horizontal == 0)
            animator.SetFloat("Speed", Mathf.Abs(input.vertical) * movespeed);

        if (input.horizontal > 0)
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        if (input.horizontal < 0)
            gameObject.transform.localScale = new Vector3(-1, 1, 1);

        rb.velocity = new Vector2(input.horizontal * movespeed, input.vertical * movespeed);
    }

    public void TakeDamage()
    {
        StartCoroutine(ResolveDamage());
    }

    public bool IsAlive()
    {
        return alive;
    }

    IEnumerator ResolveDamage()
    {
        //rb.velocity = new Vector2(0,0);
        Destroy(rb);
        canMove = false;
        audioSource.PlayOneShot(deathSFX, 1f);
        yield return new WaitForSeconds(1f);
        alive = false;
    }
}
