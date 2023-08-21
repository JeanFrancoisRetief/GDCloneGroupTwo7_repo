using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    [Header("Text")]
    public Text RoomText;

    [Header("Raw Images")]
    public RawImage MainStage;
    public RawImage DiningArea;
    public RawImage BackStage;
    public RawImage PiratesCove;
    public RawImage Restrooms;
    public RawImage SupplyCloset;
    public RawImage Kitchen;
    public RawImage WestHall;
    public RawImage WestHallCorner;
    public RawImage EastHall;
    public RawImage EastHallCorner;

    [Header("Main Stage")]
    public Texture imgStageFull;
    public Texture imgStageNoB;
    public Texture imgStageNoBorC;
    public Texture imgStageEmpty;

    [Header("Dining Area")]
    public Texture imgDiningEmpty;
    public Texture imgDiningBonnie;
    public Texture imgDiningChica;
    public Texture imgDingingBandC;

    [Header("BackStage")]
    public Texture imgBackstageEmpty;
    public Texture imgBackstageBonnie;

    [Header("Pirates Cove")]
    public Texture imgPiratePhase1;
    public Texture imgPiratePhase2;
    public Texture imgPiratePhase3;
    public Texture imgPiratePhase4;

    [Header("Restrooms")]
    public Texture imgRestroomsEmpty;
    public Texture imgRestroomsChica;
    public Texture imgRestroomsFreddy;

    [Header("Supply Closet")]
    public Texture imgClosetEmpty;
    public Texture imgClosetBonnie;

    //Kitchen never changes

    [Header("WestHall")]
    public Texture imgWestHallEmpty;
    public Texture imgWestHallBonnie;
    public Texture imgWestHallCornerEmpty;
    public Texture imgWestHallCornerBonnie;

    [Header("EastHall")]
    public Texture imgEastHallEmpty;
    public Texture imgEastHallChica;
    public Texture imgEastHallCornerEmpty;
    public Texture imgEastHallCornerChica;
    public Texture imgEastHallCornerFreddy;

    [Header("Difficulty")]
    public int BonnieDifficulty;
    public int ChicaDifficulty;
    public int FreddyDifficulty;
    public int FoxyDifficulty;

    [Header("Game State")]
    public bool isGameActive; //false = in main menu
    public bool inCams;

    [Header("AI")]
    //frame counters
    public int bonnieCounter; //every 4.97 sec = 298,2 frames
    public int chicaCounter; //every 4.98 sec = 298,8 frames
    public int freddyCounter; //every 3.02 sec = 181,2 frames
    public int foxyCounter; //every 5.01 sec = 300,6 frames

    [Header("MovementBools")]
    public bool BonnieMoving;
    public bool ChicaMoving;
    public bool FreddyMoving;

    [Header("Scripts")]
    public SoundScript soundScript;
    public OfficeScript officeScript;
    public MainMenuScript mainMenuScript;

    /*
     Note:
        From ExitScript
    ---------------------
    Application.targetFrameRate = 60;//lock frame rate;
    ----------------------
        Thus
        if(____counter = 60)
        {
            One second has passed.
        }
     */

    [Header("AI Locations")]
    public Location BonnieLocation;
    public Location ChicaLocation;
    public Location FreddyLocation;
    public Location FoxyLocation;
    public int FoxyStage;
    public enum Location
    {
        MainStage,
        DiningArea,
        BackStage,
        PiratesCove,
        Restrooms,
        SupplyCloset,
        Kitchen,
        WestHall,
        WestHallCorner,
        EastHall,
        EastHallCorner,
        OFFICE
    }



    // Start is called before the first frame update
    void Start()
    {
        //initial state
        isGameActive = false; //--------------------------------------------------------true for testing,    SET TO false FOR FINAL GAME!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        inCams = true;      //--------------------------------------------------------false for testing,   SET TO true  FOR FINAL GAME!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        //initial cam
        MainStage.gameObject.SetActive(true);
        
        //initial locations
        BonnieLocation = Location.MainStage;
        ChicaLocation = Location.MainStage;
        FreddyLocation = Location.MainStage;
        FoxyLocation = Location.PiratesCove;

        //initital times
        bonnieCounter = 0;
        chicaCounter = 0;
        freddyCounter = 0;
        foxyCounter = 0;

        FoxyStage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameActive)
        {
            Freddy();
            Chica();
            Bonnie();

            Foxy();

            LocationTracker();

            soundScript.fanSoundLower.volume = 0.4f;
        }

        #region sounds

        //stops main menu sounds when a night starts
        if (isGameActive == true)
        {
            soundScript.mainMenuSound.Stop();
            soundScript.mainMenuSound1.Stop();
        }

        //plays when Chica is in the kitchen
        if (ChicaLocation == Location.Kitchen)
        {
            soundScript.KitchenSounds();

            //plays louder when cams are active
            if (officeScript.AreCamsActive == true)
            {
                soundScript.kitchenSounds.volume = 1f;
            }
        }

        //plays a different audio as Freddy gets closer
        if (FreddyLocation == Location.DiningArea)
        {
            soundScript.FreddyLaugh1();
        }

        if (FreddyLocation == Location.Restrooms)
        {
            soundScript.FreddyLaugh2();
        }

        if (FreddyLocation == Location.EastHallCorner)
        {
            soundScript.FreddyLaugh3();
        }

        //plays if camera is active and an animatronic moves
        if (officeScript.AreCamsActive == true)
        {
            if (BonnieMoving == true || ChicaMoving == true)
            {
                soundScript.AnimatronicMoving();
            }
            else if (FreddyDifficulty >= 1)
            {
                if (FreddyMoving == true)
                {
                    soundScript.AnimatronicMoving();
                }
            }
        }

        //plays an opening camera sound, a continous using camera sound and lowers the volume of the fan
        if (officeScript.AreCamsActive == true)
        {
            soundScript.FanSoundLower();
        }

        if (officeScript.IsLeftDoorClosed == true || officeScript.IsRightDoorClosed == true)
        {
            if(BonnieLocation == Location.OFFICE || ChicaLocation == Location.OFFICE || FreddyLocation == Location.OFFICE || FoxyLocation == Location.OFFICE)
            {
                soundScript.DoorBanging();
            }
        }

        //plays if an animatronic is the corner and player puts the light on during or after night 3
        if (mainMenuScript.nightCounter >= 3)
        {
            if (BonnieLocation == Location.SupplyCloset)
            {
                if (officeScript.AreCamsActive == true)
                {
                    soundScript.AnimatronicAtCorner();
                }
            }

            if (ChicaLocation == Location.EastHall)
            {
                if (officeScript.AreCamsActive == true)
                {
                    soundScript.AnimatronicAtCorner();
                }
            }
        }

        //plays if Bonnie is in the doorway and the left lights are switched on
        if (officeScript.AreLeftLightsActive)
        {
            if (BonnieLocation == Location.OFFICE)
            {
                soundScript.AnimatronicInDoorway();
            }
        }

        //plays if Chica is in the window and the right lights are switched on
        if (officeScript.AreRightLightsActive) 
        { 
            if (ChicaLocation == Location.OFFICE)
            {
                soundScript.AnimatronicInDoorway();
            }
        }

        if (officeScript.powerLeft <= 0f)
        {
            soundScript.PowerDown();
        }

        //plays if there is 0 power and freddy is in the office
        if (officeScript.powerLeft == 0f)
        {
            if (FreddyLocation == Location.EastHallCorner)
            {
                soundScript.FreddyAtDoor();
            }
        }

        #endregion
    }

    //AI~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private void LocationTracker()
    {
        //Main Stage
        if((FreddyLocation == Location.MainStage) && (ChicaLocation == Location.MainStage) && (BonnieLocation == Location.MainStage))
        {
            MainStage.texture = imgStageFull;
        }
        else if ((FreddyLocation == Location.MainStage) && (ChicaLocation == Location.MainStage))
        {
            MainStage.texture = imgStageNoB;
        } 
        else if ((FreddyLocation == Location.MainStage))
        {
            MainStage.texture = imgStageNoBorC;
        }
        else
        {
            MainStage.texture = imgStageEmpty;
        }

        //Dining Area
        if((BonnieLocation == Location.DiningArea) && (ChicaLocation == Location.DiningArea))
        {
            DiningArea.texture = imgDingingBandC;
        }
        else if ((BonnieLocation == Location.DiningArea) && (ChicaLocation != Location.DiningArea))
        {
            DiningArea.texture = imgDiningBonnie;
        }
        else if ((ChicaLocation == Location.DiningArea) && (BonnieLocation != Location.DiningArea))
        {
            DiningArea.texture = imgDiningChica;
        }
        else
        {
            DiningArea.texture = imgDiningEmpty;
        }

        //Backstage
        if(BonnieLocation == Location.BackStage)
        {
            BackStage.texture = imgBackstageBonnie;
        }
        else
        {
            BackStage.texture = imgBackstageEmpty;
        }

        //PirateCove
        if(FoxyStage == 1)
        {
            PiratesCove.texture = imgPiratePhase1;
        }
        else if (FoxyStage == 2)
        {
            PiratesCove.texture = imgPiratePhase2;
        }
        else if (FoxyStage == 3)
        {
            PiratesCove.texture = imgPiratePhase3;
        }
        else
        {
            PiratesCove.texture = imgPiratePhase4;
        }

        //Restrooms
        if (FreddyLocation == Location.Restrooms)
        {
            Restrooms.texture = imgRestroomsFreddy;
        } 
        else if (ChicaLocation == Location.Restrooms)
        {
            Restrooms.texture = imgRestroomsChica;
        }
        else
        {
            Restrooms.texture = imgRestroomsEmpty;
        }

        //Closet
        if (BonnieLocation == Location.SupplyCloset)
        {
            SupplyCloset.texture = imgClosetBonnie;
        }
        else
        {
            SupplyCloset.texture = imgClosetEmpty;
        }

        //Kitchen doent change

        //West Hall
        if (BonnieLocation == Location.WestHall)
        {
            WestHall.texture = imgWestHallBonnie;
        }
        else
        {
            WestHall.texture = imgWestHallEmpty;
        }

        //West Hall Corner
        if (BonnieLocation == Location.WestHallCorner)
        {
            WestHallCorner.texture = imgWestHallCornerBonnie;
        }
        else
        {
            WestHallCorner.texture = imgWestHallCornerEmpty;
        }

        //East Hall
        if (ChicaLocation == Location.EastHall)
        {
            EastHall.texture = imgEastHallChica;
        }
        else
        {
            EastHall.texture = imgEastHallEmpty;
        }

        //East Hall Corner
        if (ChicaLocation == Location.EastHallCorner)
        {
            EastHallCorner.texture = imgEastHallCornerChica;
        }
        else if (FreddyLocation == Location.EastHallCorner)
        {
            EastHallCorner.texture = imgEastHallCornerFreddy;
        }
        else
        {
            EastHallCorner.texture = imgEastHallCornerEmpty;
        }


    }

    private void Bonnie()
    {
        bonnieCounter++;
        if(bonnieCounter >= 298) //frame counter
        {
            bonnieCounter = 0; //reset counter

            //Movement Oppertunity
            Debug.Log("Bonnie Tries to Move");

            int bonnieSkillCheck = Random.Range(1,20);
            if(BonnieDifficulty >= bonnieSkillCheck)
            {
                

                
                if(BonnieLocation == Location.MainStage)
                {
                    BonnieLocation = Location.DiningArea;
                    Debug.Log("Bonnie in Dining Area");
                }
                else if (BonnieLocation == Location.DiningArea)
                {
                    BonnieLocation = Location.BackStage;
                    Debug.Log("Bonnie in BackStage");
                }
                else if (BonnieLocation == Location.BackStage)
                {
                    BonnieLocation = Location.WestHall;
                    Debug.Log("Bonnie in WestHall");
                }
                else if(BonnieLocation == Location.WestHall)
                {
                    BonnieLocation = Location.SupplyCloset;
                    Debug.Log("Bonnie in Closet");
                }
                else if (BonnieLocation == Location.SupplyCloset)
                {
                    BonnieLocation = Location.WestHallCorner;
                    Debug.Log("Bonnie in West Hall Corner");
                }
                else if (BonnieLocation == Location.WestHallCorner)
                {
                    BonnieLocation = Location.OFFICE; //danger zone
                    Debug.Log("Bonnie in OFFICE");
                }

                BonnieMoving = true; //bool becomes true on a successful skill check

            }
        }

        if (bonnieCounter >= 150) //might need some adjusting
        {
            BonnieMoving = false; //bool becomes false after some time has passed to allow for a safe range for sound to play
        }
    }
    private void Chica()
    {
        chicaCounter++;
        if (chicaCounter >= 299) //frame counter
        {
            chicaCounter = 0; //reset counter

            //Movement Oppertunity
            Debug.Log("Chica Tries to Move");

            int chicaSkillCheck = Random.Range(1, 20);
            if (ChicaDifficulty >= chicaSkillCheck)
            {
                Debug.Log("Chica Moved!!!");


                if ((ChicaLocation == Location.MainStage) && (BonnieLocation != Location.MainStage))
                {
                    ChicaLocation = Location.DiningArea;
                }
                else if ((ChicaLocation == Location.DiningArea) && (FreddyLocation != Location.Restrooms))
                {
                    ChicaLocation = Location.Restrooms;
                }
                else if (ChicaLocation == Location.Restrooms)
                {
                    ChicaLocation = Location.Kitchen;
                }
                else if (ChicaLocation == Location.Kitchen)
                {
                    ChicaLocation = Location.EastHall;
                }
                else if ((ChicaLocation == Location.EastHall) && (FreddyLocation != Location.EastHallCorner))
                {
                    ChicaLocation = Location.EastHallCorner;
                } 
                else if (ChicaLocation == Location.EastHallCorner)
                {
                    ChicaLocation = Location.OFFICE; //danger zone
                }
                
                ChicaMoving = true;
      
            }

        }

        if (chicaCounter >= 150) //might need some adjusting
        {
            ChicaMoving = false; //bool becomes false after some time has passed to allow for a safe range for sound to play
        }
    }
    private void Freddy()
    {
        freddyCounter++;
        if (freddyCounter >= 181) //frame counter
        {
            freddyCounter = 0; //reset counter

            //Movement Oppertunity
            Debug.Log("Freddy Tries to Move");

            int freddySkillCheck = Random.Range(1, 20);
            if (FreddyDifficulty >= freddySkillCheck)
            {
                Debug.Log("Freddy Moved!!!");


                if ((FreddyLocation == Location.MainStage) && (ChicaLocation != Location.Restrooms) && (ChicaLocation != Location.MainStage))
                {
                    FreddyLocation = Location.Restrooms;
                    Debug.Log("Freddy Moved to the restrooms");
                }
                else if((FreddyLocation == Location.Restrooms) && (ChicaLocation != Location.EastHallCorner))
                {
                    FreddyLocation = Location.EastHallCorner; //danger zone (not office)
                }
                
            }

            FreddyMoving = true;

        }

        if (freddyCounter >= 150) //might need some adjusting
        {
            FreddyMoving = false; //bool becomes false after some time has passed to allow for a safe range for sound to play
        }
    }
    private void Foxy()
    {
        foxyCounter++;

        if (inCams)
        {
            foxyCounter = 0; //reset foxy timer
        }

        if (foxyCounter >= 301) //frame counter
        {
            foxyCounter = 0; //reset counter

            //Movement Oppertunity
            Debug.Log("Foxy Tries to Move");

            int foxySkillCheck = Random.Range(1, 20);
            if (FoxyDifficulty >= foxySkillCheck)
            {
                Debug.Log("Foxy Moved!!!");

                FoxyStage++;
                
            }

        }
    }
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    //Navigation~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public void OnCamMainStageClick()
    {
        MainStage.gameObject.SetActive(true);
        DiningArea.gameObject.SetActive(false);
        BackStage.gameObject.SetActive(false);
        PiratesCove.gameObject.SetActive(false);
        Restrooms.gameObject.SetActive(false);
        SupplyCloset.gameObject.SetActive(false);
        Kitchen.gameObject.SetActive(false);
        WestHall.gameObject.SetActive(false);
        WestHallCorner.gameObject.SetActive(false);
        EastHall.gameObject.SetActive(false);
        EastHallCorner.gameObject.SetActive(false);

        RoomText.text = "Main Stage";
    }
    public void OnCamDiningAreaClick()
    {
        MainStage.gameObject.SetActive(false);
        DiningArea.gameObject.SetActive(true);
        BackStage.gameObject.SetActive(false);
        PiratesCove.gameObject.SetActive(false);
        Restrooms.gameObject.SetActive(false);
        SupplyCloset.gameObject.SetActive(false);
        Kitchen.gameObject.SetActive(false);
        WestHall.gameObject.SetActive(false);
        WestHallCorner.gameObject.SetActive(false);
        EastHall.gameObject.SetActive(false);
        EastHallCorner.gameObject.SetActive(false);

        RoomText.text = "Dining Area";
    }
    public void OnCamBackStageClick()
    {
        MainStage.gameObject.SetActive(false);
        DiningArea.gameObject.SetActive(false);
        BackStage.gameObject.SetActive(true);
        PiratesCove.gameObject.SetActive(false);
        Restrooms.gameObject.SetActive(false);
        SupplyCloset.gameObject.SetActive(false);
        Kitchen.gameObject.SetActive(false);
        WestHall.gameObject.SetActive(false);
        WestHallCorner.gameObject.SetActive(false);
        EastHall.gameObject.SetActive(false);
        EastHallCorner.gameObject.SetActive(false);

        RoomText.text = "Backstage";
    }
    public void OnCamPiratesCoveClick()
    {
        MainStage.gameObject.SetActive(false);
        DiningArea.gameObject.SetActive(false);
        BackStage.gameObject.SetActive(false);
        PiratesCove.gameObject.SetActive(true);
        Restrooms.gameObject.SetActive(false);
        SupplyCloset.gameObject.SetActive(false);
        Kitchen.gameObject.SetActive(false);
        WestHall.gameObject.SetActive(false);
        WestHallCorner.gameObject.SetActive(false);
        EastHall.gameObject.SetActive(false);
        EastHallCorner.gameObject.SetActive(false);

        RoomText.text = "Pirate's Cove";
    }
    public void OnCamRestroomsClick()
    {
        MainStage.gameObject.SetActive(false);
        DiningArea.gameObject.SetActive(false);
        BackStage.gameObject.SetActive(false);
        PiratesCove.gameObject.SetActive(false);
        Restrooms.gameObject.SetActive(true);
        SupplyCloset.gameObject.SetActive(false);
        Kitchen.gameObject.SetActive(false);
        WestHall.gameObject.SetActive(false);
        WestHallCorner.gameObject.SetActive(false);
        EastHall.gameObject.SetActive(false);
        EastHallCorner.gameObject.SetActive(false);

        RoomText.text = "Restrooms";
    }
    public void OnCamSupplyClosetClick()
    {
        MainStage.gameObject.SetActive(false);
        DiningArea.gameObject.SetActive(false);
        BackStage.gameObject.SetActive(false);
        PiratesCove.gameObject.SetActive(false);
        Restrooms.gameObject.SetActive(false);
        SupplyCloset.gameObject.SetActive(true);
        Kitchen.gameObject.SetActive(false);
        WestHall.gameObject.SetActive(false);
        WestHallCorner.gameObject.SetActive(false);
        EastHall.gameObject.SetActive(false);
        EastHallCorner.gameObject.SetActive(false);

        RoomText.text = "Supply Closet";
    }
    public void OnCamKitchenClick()
    {
        MainStage.gameObject.SetActive(false);
        DiningArea.gameObject.SetActive(false);
        BackStage.gameObject.SetActive(false);
        PiratesCove.gameObject.SetActive(false);
        Restrooms.gameObject.SetActive(false);
        SupplyCloset.gameObject.SetActive(false);
        Kitchen.gameObject.SetActive(true);
        WestHall.gameObject.SetActive(false);
        WestHallCorner.gameObject.SetActive(false);
        EastHall.gameObject.SetActive(false);
        EastHallCorner.gameObject.SetActive(false);

        RoomText.text = "Kitchen";
    }
    public void OnCamWestHallClick()
    {
        MainStage.gameObject.SetActive(false);
        DiningArea.gameObject.SetActive(false);
        BackStage.gameObject.SetActive(false);
        PiratesCove.gameObject.SetActive(false);
        Restrooms.gameObject.SetActive(false);
        SupplyCloset.gameObject.SetActive(false);
        Kitchen.gameObject.SetActive(false);
        WestHall.gameObject.SetActive(true);
        WestHallCorner.gameObject.SetActive(false);
        EastHall.gameObject.SetActive(false);
        EastHallCorner.gameObject.SetActive(false);

        RoomText.text = "West Hall";
    }
    public void OnCamWestCornerClick()
    {
        MainStage.gameObject.SetActive(false);
        DiningArea.gameObject.SetActive(false);
        BackStage.gameObject.SetActive(false);
        PiratesCove.gameObject.SetActive(false);
        Restrooms.gameObject.SetActive(false);
        SupplyCloset.gameObject.SetActive(false);
        Kitchen.gameObject.SetActive(false);
        WestHall.gameObject.SetActive(false);
        WestHallCorner.gameObject.SetActive(true);
        EastHall.gameObject.SetActive(false);
        EastHallCorner.gameObject.SetActive(false);

        RoomText.text = "West Hall Corner";
    }
    public void OnCamEastHallClick()
    {
        MainStage.gameObject.SetActive(false);
        DiningArea.gameObject.SetActive(false);
        BackStage.gameObject.SetActive(false);
        PiratesCove.gameObject.SetActive(false);
        Restrooms.gameObject.SetActive(false);
        SupplyCloset.gameObject.SetActive(false);
        Kitchen.gameObject.SetActive(false);
        WestHall.gameObject.SetActive(false);
        WestHallCorner.gameObject.SetActive(false);
        EastHall.gameObject.SetActive(true);
        EastHallCorner.gameObject.SetActive(false);

        RoomText.text = "East Hall";
    }
    public void OnCamEastCornerClick()
    {
        MainStage.gameObject.SetActive(false);
        DiningArea.gameObject.SetActive(false);
        BackStage.gameObject.SetActive(false);
        PiratesCove.gameObject.SetActive(false);
        Restrooms.gameObject.SetActive(false);
        SupplyCloset.gameObject.SetActive(false);
        Kitchen.gameObject.SetActive(false);
        WestHall.gameObject.SetActive(false);
        WestHallCorner.gameObject.SetActive(false);
        EastHall.gameObject.SetActive(false);
        EastHallCorner.gameObject.SetActive(true);

        RoomText.text = "East Hall Corner";
    }
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

}
