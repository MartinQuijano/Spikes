using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    public SpikeController[] firstGroupOfSpikes;
    public SpikeController[] secondGroupOfSpikes;
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
        for (int i = 0; i < firstGroupOfSpikes.Length; i++)
            firstGroupOfSpikes[i].Activate();
        audioSource.PlayOneShot(spikeSFX, spikesVolume);
        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < firstGroupOfSpikes.Length; i++)
            firstGroupOfSpikes[i].Deactivate();

        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < secondGroupOfSpikes.Length; i++)
            secondGroupOfSpikes[i].Activate();
        audioSource.PlayOneShot(spikeSFX, spikesVolume);
        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < secondGroupOfSpikes.Length; i++)
            secondGroupOfSpikes[i].Deactivate();

        shouldRestartSecuence = true;
    }
}
