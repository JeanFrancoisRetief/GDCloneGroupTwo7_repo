using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [Header("Main Menu")]
    public AudioSource mainMenuSound;
    public AudioSource mainMenuSound1;
    public MainMenuScript mainMenuScript;

    [Header("Advantageous Sounds")]
    public AudioSource kitchenSounds;

    public AudioSource freddyLaugh1;
    public AudioSource freddyLaugh2;

    public AudioSource foxyRunning;
    public AudioSource doorBanging;

    [Header("Environmental Sounds")]
    public AudioSource openCamera;
    public AudioSource usingCams;
    public AudioSource fanSoundLower;

    public AudioSource closedDoor;
    public AudioSource usingRightLights;
    public AudioSource usingLeftLights;

    public int randomCounter;
    public int environmentalNoisesCounter;
    public AudioSource organSong;
    public AudioSource foxySinging;
    public AudioSource swirlingNoise;
    public AudioSource subtleNoises;

    public AudioSource animatronicInDoorWay;
    public AudioSource animatronicAtCorner;

    [Header("Lights Out Sounds")]
    public AudioSource powerDown;
    public AudioSource freddyAtDoor;

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

    public void FoxyRunnning()
    {
        foxyRunning.Play();   
    }

    public void DoorBanging()
    {
        doorBanging.Play();
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
        fanSoundLower.volume = 0.25f;
    }

    public void ClosedDoor()
    {
        closedDoor.Play();
    }

    public void UsingRightLights()
    {
        usingRightLights.Play();
    }

    public void UsingLeftLights()
    {
        usingLeftLights.Play();
    }

    public void AnimatronicAtCorner()
    {
        animatronicAtCorner.Play();
    }

    public void AnimatronicInDoorway()
    {
        animatronicInDoorWay.Play();
    }

    #endregion

    #region lights out

    public void PowerDown()
    {
        powerDown.Play();
    }

    public void FreddyAtDoor()
    {
        freddyAtDoor.Play();
    }

    #endregion

    private void Update()
    {
        environmentalNoisesCounter++;
        if (environmentalNoisesCounter == 60)
        {
            CheckRandomCounter();
            environmentalNoisesCounter = 0;
        }
    }

    public void CheckRandomCounter()
    {
        randomCounter = UnityEngine.Random.Range(0, 100);

        if (randomCounter == 25)
        {
            organSong.Play();
        }

        if (randomCounter == 50)
        {
            foxySinging.Play();
        }

        if (randomCounter == 75)
        {
            swirlingNoise.Play();
        }

        if (randomCounter == 100)
        {
            subtleNoises.Play();
        }
    }
}
