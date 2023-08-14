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

    [Header("AI")]
    public int bonnieCounter;
    public int chicaCounter;
    public int freddyCounter;
    public int foxyCounter;

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
        isGameActive = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameActive)
        {
            Bonnie();
            Chica();
            Freddy();
            Foxy();
        }
    }

    //AI~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private void Bonnie()
    {

    }
    private void Chica()
    {
        
    }
    private void Freddy()
    {

    }
    private void Foxy()
    {

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
