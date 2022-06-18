using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicIconSwap : MonoBehaviour
{
    private bool soundOn;
    public Sprite soundOnImage;
    public Sprite soundOffImage;
    private MusicPlayerManager musicPlayerManager;

    void Start()
    {
        musicPlayerManager = GameObject.FindGameObjectWithTag("MusicPlayerManager").GetComponent<MusicPlayerManager>();
        soundOn = musicPlayerManager.IsAudioOn();
        
        if (soundOn)
            gameObject.GetComponent<Image>().sprite = soundOnImage;
        else gameObject.GetComponent<Image>().sprite = soundOffImage;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwapImage();
        }
    }

    public void SwapImage()
    {
        musicPlayerManager.MuteUnmuteMusic();
        if (soundOn)
        {
            soundOn = false;
            gameObject.GetComponent<Image>().sprite = soundOffImage;
        }
        else
        {
            soundOn = true;
            gameObject.GetComponent<Image>().sprite = soundOnImage;
        }
    }
}