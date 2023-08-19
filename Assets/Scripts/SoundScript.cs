using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [Header("Advantageous Sounds")]
    public AudioSource kitchenSounds;

    public AudioSource freddyLaugh1;
    public AudioSource freddyLaugh2;
    public AudioSource freddyLaugh3;

    public AudioSource animatronicInOffice;
    public AudioSource freddyInOffice;

    [Header("Environmental Sounds")]
    public AudioSource openCamera;
    public AudioSource usingCams;
    public AudioSource fanSoundLower;

    public AudioSource closedDoor;
    public AudioSource usingLights;

    public int randomCounter;
    public int organCounter;
    public int foxySingingCounter;
    public int swirlingNoiseCounter;
    public int subtleNoisesCounter;
    public AudioSource organSong;
    public AudioSource foxySinging;
    public AudioSource swirlingNoise;
    public AudioSource subtleNoises;

    public AudioSource animatronicAtCorner;

    #region advantageous sounds

    public void KitchenSounds()
    {
        kitchenSounds.Play();
    }

    public void FreddyLaugh1()
    {
        freddyLaugh1.Play();
    }

    public void FreddyLaugh2()
    {
        freddyLaugh2.Play();
    }

    public void FreddyLaugh3()
    {
        freddyLaugh3.Play();
    }

    public void AnimatronicInOffice()
    {
        animatronicInOffice.Play();
    }

    public void FreddyInOffice()
    {
        freddyInOffice.Play();
    }

    #endregion

    #region environmental sounds

    public void OpenCamera()
    {
        openCamera.Play();
    }

    public void UsingCams()
    {
        usingCams.Play();
    }

    public void FanSoundLower()
    {
        fanSoundLower.volume = 0.1f;
    }

    public void ClosedDoor()
    {
        closedDoor.Play();
    }

    public void UsingLights()
    {
        usingLights.Play();
    }

    public void OrganSong()
    {
        if (randomCounter == organCounter)
        {
            organSong.Play();
        }
    }

    public void FoxySingning()
    {
        if (randomCounter == foxySingingCounter)
        {
            foxySinging.Play();
        }
    }

    public void SwirlingNoise()
    {
        if (randomCounter == swirlingNoiseCounter)
        {
            swirlingNoise.Play();
        }
    }

    public void SubtleNoises()
    {
        if (randomCounter == subtleNoisesCounter)
        {
            subtleNoises.Play();
        }
    }

    public void AnimatronicAtCorner()
    {
        animatronicAtCorner.Play();
    }

    #endregion

    private void Update()
    {
        randomCounter = UnityEngine.Random.Range(0, 780);
        organCounter = UnityEngine.Random.Range(0, 780);
        foxySingingCounter = UnityEngine.Random.Range(0, 780);
        swirlingNoiseCounter = UnityEngine.Random.Range(0, 780);
        subtleNoisesCounter = UnityEngine.Random.Range(0, 780);
    }
}
