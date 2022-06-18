using System.Collections;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    public Sprite[] spritesDeactivated;
    public Sprite[] spritesActivated;

    private int spriteIndex;

    public int number;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;

        spriteIndex = Random.Range(0, 5);
    }

    public void Activate()
    {
        spriteRenderer.sprite = spritesActivated[spriteIndex];
        boxCollider2D.enabled = true;
    }

    public void Deactivate()
    {
        spriteRenderer.sprite = spritesDeactivated[spriteIndex];
        boxCollider2D.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){
            PlayerController playerController = collider.gameObject.GetComponent<PlayerController>();
            playerController.TakeDamage();
        }
    }

    public int GetNumber(){
        return number;
    }
}