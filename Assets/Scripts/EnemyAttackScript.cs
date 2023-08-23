using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttackScript : MonoBehaviour
{
    public OfficeScript OfficeScript;
    public CameraScript CameraScript;
    public SoundScript SoundScript;

    public int BonnieAttackCounter;
    public int ChicaAttackCounter;
    public int FreddyAttackCounter;
    public int FoxyRunCounter;

    public GameObject BlackOut;
    public GameObject OfficePower;
    public int FreddyFlickerCounter;
    public int FreddyPowerOutAttackCounter;

    public bool runOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        BonnieAttackCounter = 15 * 60;
        ChicaAttackCounter = 15 * 60;
        FreddyAttackCounter = 20 * 60;
        FoxyRunCounter = 4 * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if((CameraScript.BonnieLocation == CameraScript.Location.OFFICE))
        {
            BonnieAttackCounter--;
            if((BonnieAttackCounter <= 0) && !(OfficeScript.IsLeftDoorClosed))
            {
                PlayBonnieJumpScare();
                
            }
            else if ((BonnieAttackCounter <= 0) && (OfficeScript.IsLeftDoorClosed))
            {
                CameraScript.BonnieLocation = CameraScript.Location.DiningArea;
                BonnieAttackCounter = 15 * 60;
                SoundScript.DoorBanging();
            }
        }

        if ((CameraScript.ChicaLocation == CameraScript.Location.OFFICE))
        {
            ChicaAttackCounter--;
            if ((ChicaAttackCounter <= 0) && !(OfficeScript.IsRightDoorClosed))
            {
                PlayChicaJumpScare();

            }
            else if ((ChicaAttackCounter <= 0) && (OfficeScript.IsRightDoorClosed))
            {
                CameraScript.ChicaLocation = CameraScript.Location.DiningArea;
                ChicaAttackCounter = 15 * 60;
                SoundScript.DoorBanging();
            }
        }

        if ((CameraScript.FreddyLocation == CameraScript.Location.EastHallCorner))
        {
            FreddyAttackCounter--;
            if ((FreddyAttackCounter <= 0) && !(OfficeScript.IsRightDoorClosed))
            {
                if (OfficeScript.powerLeft > 0)
                {
                    PlayFreddyJumpScare();
                }
                else
                {

                }
            }
            else if ((FreddyAttackCounter <= 0) && (OfficeScript.IsRightDoorClosed))
            {
                CameraScript.FreddyLocation = CameraScript.Location.MainStage;
                FreddyAttackCounter = 20 * 60;
                SoundScript.DoorBanging();
            }
        }

        if ((CameraScript.FoxyStage >= 4))
        {
            //Play Foxy RUNING NOISE------------------
            SoundScript.FoxyRunnning();

            //----------------------------------------
            FoxyRunCounter--;
            if ((FoxyRunCounter <= 0) && !(OfficeScript.IsLeftDoorClosed))
            {
                PlayFoxyJumpScare();

            }
            else if ((FoxyRunCounter <= 0) && (OfficeScript.IsLeftDoorClosed))
            {
                CameraScript.FoxyStage = 2;
                CameraScript.foxyCounter = 0;
                FoxyRunCounter = 4 * 60;
                SoundScript.DoorBanging();
            }
        }

        //---------------------------------------------------------
        if (OfficeScript.powerLeft == 0 && runOnce == false)
        {

           OfficePower.SetActive(false); //Power shuts down (dark room) -> stop all animatronics from attacking (isGameActive = false???)

           BlackOut.SetActive(true);

                //Screen completely darken, player just hears Freddy now walinkg around for 2 to 10 sec (random)
           FreddyPowerOutAttackCounter = Random.Range(60, 240);

           if (FreddyPowerOutAttackCounter == 0)
            {
               //After 1 sec, Freddy starts to play music (and flickers eye-lights for 5 to 15 sec (random)
               FreddyFlickerCounter = Random.Range(240, 900);
               FreddyFlickerCounter--;

               if (FreddyFlickerCounter <= 0)
                {
                   PlayFreddyJumpScare();
                }
            }

            runOnce = true;
            if (runOnce)
            {
                FreddyPowerOutAttackCounter--;
                FreddyFlickerCounter--;
            }
        }
        //--------------------------------------------------------


    }

    public void PlayBonnieJumpScare()
    {
        SceneManager.LoadScene("BonnieJumpScare");
    }
    
    public void PlayChicaJumpScare()
    {
        SceneManager.LoadScene("ChicaJumpScare");
    }

    public void PlayFreddyJumpScare()
    {
        SceneManager.LoadScene("FreddieJumpScare");
    }

    public void PlayFoxyJumpScare()
    {
        SceneManager.LoadScene("FoxyJumpScare");
    }
}
