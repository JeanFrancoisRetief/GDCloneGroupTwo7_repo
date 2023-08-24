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
    public AudioSource telephoneNight1;
    public AudioSource telephoneNight2;
    public AudioSource telephoneNight3;
    public AudioSource telephoneNight4;
    public AudioSource telephoneNight5;

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

    public void PhoneCall()
    {
        if (mainMenuScript.nightCounter == 1)
        {
            telephoneNight1.Play();
        }
        else if (mainMenuScript.nightCounter == 2)
        {
            telephoneNight2.Play();
        }
        else if (mainMenuScript.nightCounter == 3)
        {
            telephoneNight3.Play();
        }
        else if (mainMenuScript.nightCounter == 4)
        {
            telephoneNight4.Play();
        }
        if (mainMenuScript.nightCounter == 5)
        {
            telephoneNight5.Play();
        }
    }

    public void CheckRandomCounter()
    {
        randomCounter = UnityEngine.Random.Range(0, 60);

        if (randomCounter == 15)
        {
            organSong.Play();
        }

        if (randomCounter == 30)
        {
            foxySinging.Play();
        }

        if (randomCounter == 45)
        {
            swirlingNoise.Play();
        }

        if (randomCounter == 60)
        {
            subtleNoises.Play();
        }
    }
}
