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
    // Start is called before the first frame update
    void Start()
    {
        BonnieAttackCounter = 15 * 60;
        ChicaAttackCounter = 15 * 60;
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
    }

    public void PlayBonnieJumpScare()
    {
        SceneManager.LoadScene("BonnieJumpScare");
    }
}
