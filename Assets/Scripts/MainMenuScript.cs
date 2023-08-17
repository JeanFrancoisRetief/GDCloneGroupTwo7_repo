using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [Header("Scripts")]
    public CameraScript CameraScript;

    [Header("Time")]
    public int time;
    public Text timeTxt;
    public int frameCounter;

    [Header("Night")]
    public int nightCounter;

    [Header("Difficulty")]
    public Text BonnieDifficultyTxt;
    public Text ChicaDifficultyTxt;
    public Text FreddyDifficultyTxt;
    public Text FoxyDifficultyTxt;

    [Header("Menu Image")]
    public int freddyImageNumber;
    public int freddyImageCounter;
    public GameObject freddyImg1;
    public GameObject freddyImg2;
    public GameObject freddyImg3;
    public GameObject freddyImg4;
    public GameObject freddyImg5;

    private void Start()
    {
        time = 12;
    }

    #region difficulty buttons inc/dec

    //bonnie
    public void IncreaseBonnieDifficulty()
    {
        CameraScript.BonnieDifficulty += 1;

        if (CameraScript.BonnieDifficulty >= 20)
        {
            CameraScript.BonnieDifficulty = 20;
        }
    }

    public void DecreaseBonnieDifficulty()
    {
        CameraScript.BonnieDifficulty -= 1;

        if (CameraScript.BonnieDifficulty <= 0)
        {
            CameraScript.BonnieDifficulty = 0;
        }
    }

    public void IncreaseChicaDifficulty()
    {
        CameraScript.ChicaDifficulty += 1;

        if (CameraScript.ChicaDifficulty >= 20)
        {
            CameraScript.ChicaDifficulty = 20;
        }
    }

    //chica
    public void DecreaseChicaDifficulty()
    {
        CameraScript.ChicaDifficulty -= 1;

        if (CameraScript.ChicaDifficulty <= 0)
        {
            CameraScript.ChicaDifficulty = 0;
        }
    }

    //freddy
    public void IncreaseFreddyDifficulty()
    {
        CameraScript.FreddyDifficulty += 1;

        if (CameraScript.FreddyDifficulty >= 20)
        {
            CameraScript.FreddyDifficulty = 20;
        }
    }

    public void DecreaseFreddyDifficulty()
    {
        CameraScript.FreddyDifficulty -= 1;

        if (CameraScript.FreddyDifficulty <= 0)
        {
            CameraScript.FreddyDifficulty = 0;
        }
    }

    //foxy
    public void IncreaseFoxyDifficulty()
    {
        CameraScript.FoxyDifficulty += 1;

        if (CameraScript.FoxyDifficulty >= 20)
        {
            CameraScript.FoxyDifficulty = 20;
        }
    }

    public void DecreaseFoxyDifficulty()
    {
        CameraScript.FoxyDifficulty -= 1;

        if (CameraScript.FoxyDifficulty <= 0)
        {
            CameraScript.FoxyDifficulty = 0;
        }
    }

    #endregion

    private void Update()
    {
        #region time + difficulty increases

        if (CameraScript.isGameActive == true)
        {
            frameCounter++;
        }

        if (frameCounter == 5400)
        {
            time = 1;
        }
        else if (frameCounter == 10800)
        {
            time = 2;
            if (nightCounter != 7)
            {
                CameraScript.BonnieDifficulty += 1;
            }
        }
        else if (frameCounter == 16200)
        {
            time = 3;
            if (nightCounter != 7)
            {
                CameraScript.BonnieDifficulty += 1;
                CameraScript.ChicaDifficulty += 1;
                CameraScript.FoxyDifficulty += 1;
            }
        }
        else if (frameCounter == 21600)
        {
            time = 4;
            if (nightCounter != 7)
            {
                CameraScript.BonnieDifficulty += 1;
                CameraScript.ChicaDifficulty += 1;
                CameraScript.FoxyDifficulty += 1;
            }    
        }
        else if (frameCounter == 27000)
        {
            time = 5;
        }
        else if (frameCounter == 32400)
        {
            time = 6;
        }

        timeTxt.text = time + " AM";

        #endregion

        BonnieDifficultyTxt.text = CameraScript.BonnieDifficulty.ToString();
        ChicaDifficultyTxt.text = CameraScript.ChicaDifficulty.ToString();
        FreddyDifficultyTxt.text = CameraScript.FreddyDifficulty.ToString();
        FoxyDifficultyTxt.text = CameraScript.FoxyDifficulty.ToString();

        #region freddy image

        freddyImageCounter++;
        if (freddyImageCounter == 120)
        {
            CheckFreddyImage();
            freddyImageCounter = 0;
        }

        #endregion
    }

    #region nights

    public void Night1()
    {
        nightCounter = 1;

        CameraScript.BonnieDifficulty = 0;
        CameraScript.ChicaDifficulty = 0;
        CameraScript.FreddyDifficulty = 0;
        CameraScript.FoxyDifficulty = 0;
    }

    public void Night2()
    {
        nightCounter = 2;

        CameraScript.BonnieDifficulty = 3;
        CameraScript.ChicaDifficulty = 1;
        CameraScript.FreddyDifficulty = 0;
        CameraScript.FoxyDifficulty = 1;
    }

    public void Night3()
    {
        nightCounter = 3;

        CameraScript.BonnieDifficulty = 3; //should be 0, but not with how our version works
        CameraScript.ChicaDifficulty = 5;
        CameraScript.FreddyDifficulty = 1;
        CameraScript.FoxyDifficulty = 2;
    }

    public void Night4()
    {
        nightCounter = 4;

        CameraScript.BonnieDifficulty = 2;
        CameraScript.ChicaDifficulty = 4;
        CameraScript.FreddyDifficulty = Random.Range(0, 2);
        CameraScript.FoxyDifficulty = 6;
    }

    public void Night5()
    {
        nightCounter = 5;

        CameraScript.BonnieDifficulty = 5;
        CameraScript.ChicaDifficulty = 7;
        CameraScript.FreddyDifficulty = 3;
        CameraScript.FoxyDifficulty = 5;
    }

    public void Night6()
    {
        nightCounter = 6;

        CameraScript.BonnieDifficulty = 10;
        CameraScript.ChicaDifficulty = 12;
        CameraScript.FreddyDifficulty = 4;
        CameraScript.FoxyDifficulty = 16;
    }

    #endregion

    public void CheckFreddyImage()
    {
        freddyImageNumber = Random.Range(0, 7);

        #region freddy image

        if (freddyImageNumber == 1)
        {
            freddyImg1.SetActive(false);
            freddyImg2.SetActive(true);
            freddyImg3.SetActive(false);
            freddyImg4.SetActive(false);
            freddyImg5.SetActive(false);
        }
        else if (freddyImageNumber == 2)
        {
            freddyImg1.SetActive(false);
            freddyImg2.SetActive(false);
            freddyImg3.SetActive(true);
            freddyImg4.SetActive(false);
            freddyImg5.SetActive(false);
        }
        else if (freddyImageNumber == 3)
        {
            freddyImg1.SetActive(false);
            freddyImg2.SetActive(false);
            freddyImg3.SetActive(false);
            freddyImg4.SetActive(true);
            freddyImg5.SetActive(false);
        }
        else if (freddyImageNumber == 4)
        {
            freddyImg1.SetActive(true);
            freddyImg2.SetActive(false);
            freddyImg3.SetActive(false);
            freddyImg4.SetActive(false);
            freddyImg5.SetActive(false);
        }
        else if (freddyImageNumber == 5)
        {
            freddyImg1.SetActive(false);
            freddyImg2.SetActive(false);
            freddyImg3.SetActive(false);
            freddyImg4.SetActive(false);
            freddyImg5.SetActive(true);
        }
        else if (freddyImageNumber == 6)
        {
            freddyImg1.SetActive(false);
            freddyImg2.SetActive(false);
            freddyImg3.SetActive(false);
            freddyImg4.SetActive(false);
            freddyImg5.SetActive(false);
        }

        #endregion
    }

    public void EnableGame()
    {
        CameraScript.isGameActive = true;
    }
}
