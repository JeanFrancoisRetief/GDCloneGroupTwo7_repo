using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public int BonnieDifficulty;
    public int ChicaDifficulty;
    public int FreddyDifficulty;
    public int FoxyDifficulty;

    public Text BonnieDifficultyTxt;
    public Text ChicaDifficultyTxt;
    public Text FreddyDifficultyTxt;
    public Text FoxyDifficultyTxt;

    public int freddyImageNumber;
    public GameObject freddyImg1;
    public GameObject freddyImg2;
    public GameObject freddyImg3;
    public GameObject freddyImg4;
    public GameObject freddyImg5;

    private void Start()
    {
        BonnieDifficulty = 0;
        ChicaDifficulty = 0;
        FreddyDifficulty = 0;
        FoxyDifficulty = 0;
    }

    #region difficulty buttons

    //bonnie
    public void IncreaseBonnieDifficulty()
    {
        BonnieDifficulty += 1;

        if (BonnieDifficulty >= 20)
        {
            BonnieDifficulty = 20;
        }
    }

    public void DecreaseBonnieDifficulty()
    {
        BonnieDifficulty -= 1;

        if (BonnieDifficulty <= 0)
        {
            BonnieDifficulty = 0;
        }
    }

    public void IncreaseChicaDifficulty()
    {
        ChicaDifficulty += 1;

        if (ChicaDifficulty >= 20)
        {
            ChicaDifficulty = 20;
        }
    }

    //chica
    public void DecreaseChicaDifficulty()
    {
        ChicaDifficulty -= 1;

        if (ChicaDifficulty <= 0)
        {
            ChicaDifficulty = 0;
        }
    }

    //freddy
    public void IncreaseFreddyDifficulty()
    {
        FreddyDifficulty += 1;

        if (FreddyDifficulty >= 20)
        {
            FreddyDifficulty = 20;
        }
    }

    public void DecreaseFreddyDifficulty()
    {
        FreddyDifficulty -= 1;

        if (FreddyDifficulty <= 0)
        {
            FreddyDifficulty = 0;
        }
    }

    //foxy
    public void IncreaseFoxyDifficulty()
    {
        FoxyDifficulty += 1;

        if (FoxyDifficulty >= 20)
        {
            FoxyDifficulty = 20;
        }
    }

    public void DecreaseFoxyDifficulty()
    {
        FoxyDifficulty -= 1;

        if (FoxyDifficulty <= 0)
        {
            FoxyDifficulty = 0;
        }
    }

    #endregion

    private void Update()
    {
        BonnieDifficultyTxt.text = BonnieDifficulty.ToString();
        ChicaDifficultyTxt.text = ChicaDifficulty.ToString();
        FreddyDifficultyTxt.text = FreddyDifficulty.ToString();
        FoxyDifficultyTxt.text = FoxyDifficulty.ToString();
    }

    //public IEnumerator CheckFreddyImgNumber()
    //{
    //    freddyImageNumber = Random.Range(0, 7);

    //    #region freddy image

    //    if (freddyImageNumber == 1)
    //    {
    //        freddyImg1.SetActive(false);
    //        freddyImg2.SetActive(true);
    //        freddyImg3.SetActive(false);
    //        freddyImg4.SetActive(false);
    //        freddyImg5.SetActive(false);
    //    }
    //    else if (freddyImageNumber == 2)
    //    {
    //        freddyImg1.SetActive(false);
    //        freddyImg2.SetActive(false);
    //        freddyImg3.SetActive(true);
    //        freddyImg4.SetActive(false);
    //        freddyImg5.SetActive(false);
    //    }
    //    else if (freddyImageNumber == 3)
    //    {
    //        freddyImg1.SetActive(false);
    //        freddyImg2.SetActive(false);
    //        freddyImg3.SetActive(false);
    //        freddyImg4.SetActive(true);
    //        freddyImg5.SetActive(false);
    //    }
    //    else if (freddyImageNumber == 4)
    //    {
    //        freddyImg1.SetActive(true);
    //        freddyImg2.SetActive(false);
    //        freddyImg3.SetActive(false);
    //        freddyImg4.SetActive(false);
    //        freddyImg5.SetActive(false);
    //    }
    //    else if (freddyImageNumber == 5)
    //    {
    //        freddyImg1.SetActive(false);
    //        freddyImg2.SetActive(false);
    //        freddyImg3.SetActive(false);
    //        freddyImg4.SetActive(false);
    //        freddyImg5.SetActive(true);
    //    }
    //    else if (freddyImageNumber == 6)
    //    {
    //        freddyImg1.SetActive(false);
    //        freddyImg2.SetActive(false);
    //        freddyImg3.SetActive(false);
    //        freddyImg4.SetActive(false);
    //        freddyImg5.SetActive(false);
    //    }

    //    #endregion

    //    yield return new WaitForSeconds(5);
    //}
}
