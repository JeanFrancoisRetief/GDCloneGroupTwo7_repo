using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource kitchenSounds;

    public AudioSource freddyLaugh1;
    public AudioSource freddyLaugh2;
    public AudioSource freddyLaugh3;

    public void KitchenSounds()
    {
        kitchenSounds.Play();
    }
}
