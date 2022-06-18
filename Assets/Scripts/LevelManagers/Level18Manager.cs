using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level18Manager : MonoBehaviour
{
    public SpikeController[] groupOfSpikes;

    public AudioClip spikeSFX;
    private AudioSource audioSource;
    private float spikesVolume = 0.35f;

    public float timeBetweenSpikeChange = 1f;

    public bool shouldRestartSecuence = true;

    private int rowToSpawnSpikes = 0;
    private int columnToSpawnSpikes = 9;

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
        for (int i = 0; i < groupOfSpikes.Length; i++)
        {
            if((i % 10) == columnToSpawnSpikes || (i / 10) == rowToSpawnSpikes)
                groupOfSpikes[i].Activate();
        }

        audioSource.PlayOneShot(spikeSFX, spikesVolume);

        
        yield return new WaitForSeconds(timeBetweenSpikeChange);

        for (int i = 0; i < groupOfSpikes.Length; i++)
        {
            if((i % 10) == columnToSpawnSpikes || (i / 10) == rowToSpawnSpikes)
                groupOfSpikes[i].Deactivate();
        }

        yield return new WaitForSeconds(timeBetweenSpikeChange + 0.1f);

        rowToSpawnSpikes++;
        columnToSpawnSpikes--;

        if(rowToSpawnSpikes == 7)
            rowToSpawnSpikes = 0;
        if(columnToSpawnSpikes == -1)
            columnToSpawnSpikes = 9;

        shouldRestartSecuence = true;
    }
}
