using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6Manager : MonoBehaviour
{
    public SpikeController[] firstGroupOfSpikes;
    public SpikeController[] secondGroupOfSpikes;
    public SpikeController[] thirdGroupOfSpikes;
    public SpikeController[] fourthGroupOfSpikes;
    public SpikeController[] fifthGroupOfSpikes;
    public SpikeController[] sixthGroupOfSpikes;
    public SpikeController[] seventhGroupOfSpikes;
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

        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < thirdGroupOfSpikes.Length; i++)
            thirdGroupOfSpikes[i].Activate();
        audioSource.PlayOneShot(spikeSFX, spikesVolume);
        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < thirdGroupOfSpikes.Length; i++)
            thirdGroupOfSpikes[i].Deactivate();

        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < fourthGroupOfSpikes.Length; i++)
            fourthGroupOfSpikes[i].Activate();
        audioSource.PlayOneShot(spikeSFX, spikesVolume);
        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < fourthGroupOfSpikes.Length; i++)
            fourthGroupOfSpikes[i].Deactivate();

        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < fifthGroupOfSpikes.Length; i++)
            fifthGroupOfSpikes[i].Activate();
        audioSource.PlayOneShot(spikeSFX, spikesVolume);
        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < fifthGroupOfSpikes.Length; i++)
            fifthGroupOfSpikes[i].Deactivate();

        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < sixthGroupOfSpikes.Length; i++)
            sixthGroupOfSpikes[i].Activate();
        audioSource.PlayOneShot(spikeSFX, spikesVolume);
        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < sixthGroupOfSpikes.Length; i++)
            sixthGroupOfSpikes[i].Deactivate();
        
        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < seventhGroupOfSpikes.Length; i++)
            seventhGroupOfSpikes[i].Activate();
        audioSource.PlayOneShot(spikeSFX, spikesVolume);
        yield return new WaitForSeconds(timeBetweenSpikeChange);
        for (int i = 0; i < seventhGroupOfSpikes.Length; i++)
            seventhGroupOfSpikes[i].Deactivate();

        shouldRestartSecuence = true;
    }
}