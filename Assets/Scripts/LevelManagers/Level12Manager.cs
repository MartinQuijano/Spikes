using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level12Manager : MonoBehaviour
{

    public SpikeController[] pathGroupOfSpikes;
    public SpikeController[] pathGroupOfSpikes2;

    public SpikeController[] constantGroupOfSpikes;

    public AudioClip spikeSFX;
    private AudioSource audioSource;
    private float spikesVolume = 0.35f;

    public float timeBetweenSpikeChange = 1f;

    public bool shouldRestartSecuence = true;

    public int currentIndexToNotSpawnSpikesFirst = 0;
    public int currentIndexToNotSpawnSpikesSecond = 1;

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
        for (int i = 0; i < 7; i++)
        {
            if (i != currentIndexToNotSpawnSpikesFirst && i != currentIndexToNotSpawnSpikesSecond)
            {
                pathGroupOfSpikes[(i * 2)].Activate();
                pathGroupOfSpikes[(i * 2) + 1].Activate();
            }
        }
        for (int i = 6; i > -1; i--)
        {
            if (i != (6 - currentIndexToNotSpawnSpikesFirst) && i != (6 - currentIndexToNotSpawnSpikesSecond))
            {
                pathGroupOfSpikes2[(i * 2)].Activate();
                pathGroupOfSpikes2[(i * 2) + 1].Activate();
            }
        }
        for (int j = 0; j < constantGroupOfSpikes.Length; j++)
        {
            constantGroupOfSpikes[j].Activate();
        }
        audioSource.PlayOneShot(spikeSFX, spikesVolume);

        yield return new WaitForSeconds(timeBetweenSpikeChange);

        for (int i = 0; i < 7; i++)
        {
            if (i != currentIndexToNotSpawnSpikesFirst && i != currentIndexToNotSpawnSpikesSecond)
            {
                pathGroupOfSpikes[(i * 2)].Deactivate();
                pathGroupOfSpikes[(i * 2) + 1].Deactivate();
            }
        }
        for (int i = 6; i > -1; i--)
        {
            if (i != (6 - currentIndexToNotSpawnSpikesFirst) && i != (6 - currentIndexToNotSpawnSpikesSecond))
            {
                pathGroupOfSpikes2[(i * 2)].Deactivate();
                pathGroupOfSpikes2[(i * 2) + 1].Deactivate();
            }
        }
        for (int j = 0; j < constantGroupOfSpikes.Length; j++)
        {
            constantGroupOfSpikes[j].Deactivate();
        }

        yield return new WaitForSeconds(timeBetweenSpikeChange);

        currentIndexToNotSpawnSpikesFirst++;
        currentIndexToNotSpawnSpikesSecond++;

        if (currentIndexToNotSpawnSpikesSecond == 7)
            currentIndexToNotSpawnSpikesSecond = 0;

        if (currentIndexToNotSpawnSpikesFirst == 7)
            currentIndexToNotSpawnSpikesFirst = 0;


        shouldRestartSecuence = true;
    }
}
