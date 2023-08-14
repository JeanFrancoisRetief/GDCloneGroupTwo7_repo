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
        isGameActive = true; //--------------------------------------------------------true for testing,    SET TO false FOR FINAL GAME!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        inCams = false;      //--------------------------------------------------------false for testing,   SET TO true  FOR FINAL GAME!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

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
        }
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

            }

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
      
            }

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
                if(FoxyStage == 4)
                {
                    FoxyLocation = Location.OFFICE;

                    //if door closed --> FoxyStage = 1;


                }
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
