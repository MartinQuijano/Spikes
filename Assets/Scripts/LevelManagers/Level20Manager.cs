using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level20Manager : MonoBehaviour
{
    public SpikeController[] firstGroupOfSpikes;
    public SpikeController[] secondGroupOfSpikes;
    public SpikeController[] thirdGroupOfSpikes;
    public SpikeController[] constantGroupOfSpikes;

    public AudioClip spikeSFX;
    private AudioSource audioSource;
    private float spikesVolume = 0.35f;

    public float timeBetweenSpikeChange = 1f;

    public bool shouldRestartSecuence = true;

    private int currentIndexInPathToNotSpawnSpike = 0;

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
        for (int i = 0; i < firstGroupOfSpikes.Length; i++)
        {
            if (i != currentIndexInPathToNotSpawnSpike)
                firstGroupOfSpikes[i].Activate();
        }
        for (int i = 0; i < secondGroupOfSpikes.Length; i++)
        {
            if (i != currentIndexInPathToNotSpawnSpike)
                secondGroupOfSpikes[i].Activate();
        }
        for (int i = 0; i < thirdGroupOfSpikes.Length; i++)
        {
            if (i != currentIndexInPathToNotSpawnSpike)
                thirdGroupOfSpikes[i].Activate();
        }
        for (int i = 0; i < constantGroupOfSpikes.Length; i++)
        {
            constantGroupOfSpikes[i].Activate();
        }

        audioSource.PlayOneShot(spikeSFX, spikesVolume);


        yield return new WaitForSeconds(timeBetweenSpikeChange);

        for (int i = 0; i < firstGroupOfSpikes.Length; i++)
        {
            if (i != currentIndexInPathToNotSpawnSpike)
                firstGroupOfSpikes[i].Deactivate();
        }
        for (int i = 0; i < secondGroupOfSpikes.Length; i++)
        {
            if (i != currentIndexInPathToNotSpawnSpike)
                secondGroupOfSpikes[i].Deactivate();
        }
        for (int i = 0; i < thirdGroupOfSpikes.Length; i++)
        {
            if (i != currentIndexInPathToNotSpawnSpike)
                thirdGroupOfSpikes[i].Deactivate();
        }
        for (int i = 0; i < constantGroupOfSpikes.Length; i++)
        {
            constantGroupOfSpikes[i].Deactivate();
        }

        yield return new WaitForSeconds(timeBetweenSpikeChange);

        currentIndexInPathToNotSpawnSpike++;
        if (currentIndexInPathToNotSpawnSpike == 5)
            currentIndexInPathToNotSpawnSpike = 0;

        shouldRestartSecuence = true;
    }
}
