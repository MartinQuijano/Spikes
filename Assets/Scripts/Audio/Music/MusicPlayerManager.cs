using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerManager : MonoBehaviour
{
    private static MusicPlayerManager instance = null;
    public AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    { 
        audioSource.Play();
    }

    public void MuteUnmuteMusic(){
        audioSource.mute = !audioSource.mute;
    }

    public bool IsAudioOn(){
        return !audioSource.mute;
    }
}