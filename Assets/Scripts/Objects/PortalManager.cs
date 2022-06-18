using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameManager gameManager;

    public AudioClip teleportSFX;
    private AudioSource audioSource;

     void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){
            audioSource.PlayOneShot(teleportSFX, 0.8f);
            gameManager.LoadNextLevel();
        }
    }
}
