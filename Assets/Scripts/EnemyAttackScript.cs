using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttackScript : MonoBehaviour
{
    public OfficeScript OfficeScript;
    public CameraScript CameraScript;

    public int BonnieAttackCounter;
    public int ChicaAttackCounter;
    public int FreddyAttackCounter;
    // Start is called before the first frame update
    void Start()
    {
        BonnieAttackCounter = 15 * 60;
        ChicaAttackCounter = 15 * 60;
        FreddyAttackCounter = 20 * 60;
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
            else if ((OfficeScript.IsLeftDoorClosed))
            {
                CameraScript.BonnieLocation = CameraScript.Location.DiningArea;
                BonnieAttackCounter = 15 * 60;
            }
        }

        if ((CameraScript.ChicaLocation == CameraScript.Location.OFFICE))
        {
            ChicaAttackCounter--;
            if ((ChicaAttackCounter <= 0) && !(OfficeScript.IsRightDoorClosed))
            {
                PlayChicaJumpScare();

            }
            else if ((OfficeScript.IsRightDoorClosed))
            {
                CameraScript.ChicaLocation = CameraScript.Location.DiningArea;
                ChicaAttackCounter = 15 * 60;
            }
        }

        if ((CameraScript.FreddyLocation == CameraScript.Location.EastHallCorner))
        {
            FreddyAttackCounter--;
            if ((FreddyAttackCounter <= 0) && !(OfficeScript.IsRightDoorClosed))
            {
                PlayFreddyJumpScare();

            }
            else if ((OfficeScript.IsRightDoorClosed))
            {
                CameraScript.FreddyLocation = CameraScript.Location.MainStage;
                FreddyAttackCounter = 20 * 60;
            }
        }

        if ((CameraScript.FoxyLocation == CameraScript.Location.EastHallCorner))
        {
            FreddyAttackCounter--;
            if ((FreddyAttackCounter <= 0) && !(OfficeScript.IsRightDoorClosed))
            {
                PlayFoxyJumpScare();

            }
            else if ((OfficeScript.IsRightDoorClosed))
            {
                CameraScript.FreddyLocation = CameraScript.Location.MainStage;
                FreddyAttackCounter = 20 * 60;
            }
        }
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
