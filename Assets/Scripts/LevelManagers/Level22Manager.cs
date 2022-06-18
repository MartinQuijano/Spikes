using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level22Manager : MonoBehaviour
{
    public SpikeController[] groupOfSpikes;

    public AudioClip spikeSFX;
    private AudioSource audioSource;
    private float spikesVolume = 0.35f;

    public float timeBetweenSpikeChange = 1f;

    public bool shouldRestartSecuence = true;

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
            groupOfSpikes[i].Activate();
        }

        audioSource.PlayOneShot(spikeSFX, spikesVolume);

        yield return new WaitForSeconds(timeBetweenSpikeChange);

        for (int i = 0; i < groupOfSpikes.Length; i++)
        {
            groupOfSpikes[i].Deactivate();
        }

        yield return new WaitForSeconds(timeBetweenSpikeChange);

        shouldRestartSecuence = true;
    }
}
