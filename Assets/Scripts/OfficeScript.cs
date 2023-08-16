using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfficeScript : MonoBehaviour
{
    public float panSpeed = 3f; // Speed of background panning
    public RawImage backgroundImage; // Reference to the RawImage component

    private Vector3 initialPosition; // Initial position of the background
    private float imageWidth = 2650f; // Width of the background image
    private float screenWidth; // Width of the screen

    public GameObject LeftLightsContainer;
    public GameObject RightLightsContainer;

    public bool AreLeftLightsActive;
    public bool AreRightLightsActive;

    public GameObject LeftDoor;
    public GameObject RightDoor;

    public bool IsLeftDoorClosed;
    public bool IsRightDoorClosed;

    public GameObject camNav;

    public bool AreCamsActive;

    private int varA = 0;
    private int varB = 0;
    private int varC = 0;
    private int varD = 0;
    private int varE = 0;

    public int totalActiveBars;

    public GameObject oneBar;
    public GameObject twoBars;
    public GameObject threeBars;
    public GameObject fourBars;
    public GameObject fiveBars;
    void Start()
    {
        initialPosition = backgroundImage.transform.position;
        screenWidth = Screen.width;
        
    }


    void Update()
    {
        float mousePosX = Input.mousePosition.x;

        float minX = initialPosition.x - imageWidth / 2f + screenWidth / 2f;
        float maxX = initialPosition.x + imageWidth / 2f - screenWidth / 2f;

        Vector3 targetPosition = new Vector3(
            Mathf.Clamp(initialPosition.x - (mousePosX - Screen.width / 2f) / Screen.width * imageWidth, minX, maxX),
            initialPosition.y,
            initialPosition.z
        );

        backgroundImage.transform.position = Vector3.Lerp(backgroundImage.transform.position, targetPosition, Time.deltaTime * panSpeed);

        if (LeftLightsContainer.activeSelf)
        {
            AreLeftLightsActive = true;
            varA = 1;
            
        }
        else
        {
            AreLeftLightsActive = false;
            varA = 0;
        }
        if (RightLightsContainer.activeSelf)
        {
            AreRightLightsActive = true;
            varB = 1;
        }
        else
        {
            AreRightLightsActive = false;
            varB = 0;
        }

        //sets the camera navigation to active is space bar is clicked, if already active and spacebar is clicked then deactivates camNav
        if (Input.GetKeyDown(KeyCode.Space) && camNav.activeInHierarchy == true)
        {
            camNav.SetActive(false);
            AreCamsActive = false;
            varC = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            camNav.SetActive(true);
            AreCamsActive = true;
            varC = 1;

        }

        totalActiveBars = varA + varB + varC + varD + varE + 1;

        if(totalActiveBars == 1)
        {
            oneBar.SetActive(true);
        }
        else
        {
            oneBar.SetActive(false);
        }
        if(totalActiveBars == 2)
        {
            twoBars.SetActive(true);
        }
        else
        {
            twoBars.SetActive(false);
        }
        if(totalActiveBars == 3)
        {
            threeBars.SetActive(true);
        }
        else
        {
            threeBars.SetActive(false);
        }
        if(totalActiveBars == 4)
        {
            fourBars.SetActive(true);
        }
        else
        {
            fourBars.SetActive(false);
        }
        if (totalActiveBars == 5)
        {
            fiveBars.SetActive(true);
        }
        else
        {
            fiveBars.SetActive(false);
        }


    }

    public void OnLeftDoorButtonClick()
    {
        if(LeftDoor.activeInHierarchy == true)
        {
            LeftDoor.SetActive(false);
            IsLeftDoorClosed = false;
            varD = 0;
            
        }
        else
        {
            LeftDoor.SetActive(true);
            IsLeftDoorClosed = true;
            varD = 1;
        }
    }

    public void OnRightDoorButtonClick()
    {
        if (RightDoor.activeInHierarchy == true)
        {
            RightDoor.SetActive(false);
            IsRightDoorClosed = false;
            varE = 0;
        }
        else
        {
            RightDoor.SetActive(true);
            IsRightDoorClosed = true;
            varE = 1;
        }
    }

    
}
