using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    public SpikeController[] spikes;
    public float timeBetweenSpikeChange = 1f;

    public bool shouldRestartSecuence = true;

    public AudioClip spikeSFX;
    private AudioSource audioSource;
    private float spikesVolume = 0.35f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (shouldRestartSecuence)
        {
            shouldRestartSecuence = false;
            StartCoroutine(SpikeWave());
        }
    }

    IEnumerator SpikeWave()
    {
        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < 12; i++)
            spikes[i].Activate();
        audioSource.PlayOneShot(spikeSFX, spikesVolume);
        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < 12; i++)
            spikes[i].Deactivate();

        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 12; i < 24; i++)
            spikes[i].Activate();
        audioSource.PlayOneShot(spikeSFX, spikesVolume);
        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 12; i < 24; i++)
            spikes[i].Deactivate();

        shouldRestartSecuence = true;
    }
}
