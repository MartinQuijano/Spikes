using System.Collections;
using UnityEngine;

public class Level10Manager : MonoBehaviour
{
    public SpikeController[] pathGroupOfSpikes;
    public SpikeController[] pathGroupOfSpikes2;
    public SpikeController[] pathGroupOfSpikes3;
    public SpikeController[] pathGroupOfSpikes4;
    public SpikeController[] pathGroupOfSpikes5;
    public SpikeController[] pathGroupOfSpikes6;
    public SpikeController[] pathGroupOfSpikes7;

    public SpikeController[] constantGroupOfSpikes;

    public float timeBetweenSpikeChange = 1f;

    public bool shouldRestartSecuence = true;

    public int pathCurrentIndexToNotSpawnSpikes = 0;

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

        for (int i = 0; i < pathGroupOfSpikes.Length; i++)
        {
            if (i == 2 && pathCurrentIndexToNotSpawnSpikes == 0)
            {

            }
            else
            if (i != pathCurrentIndexToNotSpawnSpikes)
                pathGroupOfSpikes[i].Activate();
        }
        for (int i = 0; i < pathGroupOfSpikes2.Length; i++)
            if (i != pathCurrentIndexToNotSpawnSpikes)
                pathGroupOfSpikes2[i].Activate();
        for (int i = 0; i < pathGroupOfSpikes3.Length; i++)
        {
            if (i == 0 && pathCurrentIndexToNotSpawnSpikes == 2)
            {

            }
            else
            if (i != pathCurrentIndexToNotSpawnSpikes)
                pathGroupOfSpikes3[i].Activate();
        }
        for (int i = 0; i < pathGroupOfSpikes4.Length; i++)
            if (i != pathCurrentIndexToNotSpawnSpikes)
                pathGroupOfSpikes4[i].Activate();
        for (int i = 0; i < pathGroupOfSpikes5.Length; i++)
        {
            if (i == 0 && pathCurrentIndexToNotSpawnSpikes == 3)
            {

            }
            else
            if (i != pathCurrentIndexToNotSpawnSpikes)
                pathGroupOfSpikes5[i].Activate();
        }
        for (int i = 0; i < pathGroupOfSpikes6.Length; i++)
        {
            if (i == 3 && pathCurrentIndexToNotSpawnSpikes == 0)
            {

            }
            else
            if (i != pathCurrentIndexToNotSpawnSpikes)
                pathGroupOfSpikes6[i].Activate();
        }
        for (int i = 0; i < pathGroupOfSpikes7.Length; i++)
            if (i != pathCurrentIndexToNotSpawnSpikes)
                pathGroupOfSpikes7[i].Activate();
        for (int j = 0; j < constantGroupOfSpikes.Length; j++)
            constantGroupOfSpikes[j].Activate();
        audioSource.PlayOneShot(spikeSFX, spikesVolume);
        yield return new WaitForSeconds(timeBetweenSpikeChange);

        for (int i = 0; i < pathGroupOfSpikes.Length; i++)
            if (i != pathCurrentIndexToNotSpawnSpikes)
                pathGroupOfSpikes[i].Deactivate();
        for (int i = 0; i < pathGroupOfSpikes2.Length; i++)
            if (i != pathCurrentIndexToNotSpawnSpikes)
                pathGroupOfSpikes2[i].Deactivate();
        for (int i = 0; i < pathGroupOfSpikes3.Length; i++)
            if (i != pathCurrentIndexToNotSpawnSpikes)
                pathGroupOfSpikes3[i].Deactivate();
        for (int i = 0; i < pathGroupOfSpikes4.Length; i++)
            if (i != pathCurrentIndexToNotSpawnSpikes)
                pathGroupOfSpikes4[i].Deactivate();
        for (int i = 0; i < pathGroupOfSpikes5.Length; i++)
            if (i != pathCurrentIndexToNotSpawnSpikes)
                pathGroupOfSpikes5[i].Deactivate();
        for (int i = 0; i < pathGroupOfSpikes6.Length; i++)
            if (i != pathCurrentIndexToNotSpawnSpikes)
                pathGroupOfSpikes6[i].Deactivate();
        for (int i = 0; i < pathGroupOfSpikes7.Length; i++)
            if (i != pathCurrentIndexToNotSpawnSpikes)
                pathGroupOfSpikes7[i].Deactivate();
        for (int j = 0; j < constantGroupOfSpikes.Length; j++)
            constantGroupOfSpikes[j].Deactivate();
        yield return new WaitForSeconds(timeBetweenSpikeChange);

        pathCurrentIndexToNotSpawnSpikes++;
        if (pathCurrentIndexToNotSpawnSpikes == 5)
        {
            pathCurrentIndexToNotSpawnSpikes = 0;
        }

        shouldRestartSecuence = true;
    }

}