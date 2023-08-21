using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfficeScript : MonoBehaviour
{
    public CameraScript CameraScript;
    public SoundScript soundScript;

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

    public GameObject bonnieInDoor;
    public GameObject chicaInWindow;

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

    public float powerLeft = 100f;
    public float decreaseSpeed;
   
    

    private float decVarA1 = 0;
    private float decVarB1 = 0;
    private float decVarC1 = 0;
    private float decVarD1 = 0;
    private float decVarE1 = 0;
    public Text powerText; // Reference to the Text UI element
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
            decVarA1 = 0.1f;

            if (powerLeft <= 0)
            {
                soundScript.LightsClick();
            }
            else
            {
                soundScript.UsingLights();
            }
        }
        else
        {
            AreLeftLightsActive = false;
            varA = 0;
            decVarA1 = 0f;
        }
        if (RightLightsContainer.activeSelf)
        {
            AreRightLightsActive = true;
            varB = 1;
            decVarB1 = 0.1f;

            if (powerLeft <= 0)
            {
                soundScript.LightsClick();
            }
            else
            {
                soundScript.UsingLights();
            }
        }
        else
        {
            AreRightLightsActive = false;
            varB = 0;
            decVarB1 = 0f;
        }

        //sets the camera navigation to active is space bar is clicked, if already active and spacebar is clicked then deactivates camNav
        if (Input.GetKeyDown(KeyCode.Space) && camNav.activeInHierarchy == true)
        {
            camNav.SetActive(false);
            AreCamsActive = false;
            varC = 0;
            decVarC1 = 0f;

            CameraScript.inCams = false;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            camNav.SetActive(true);
            AreCamsActive = true;
            varC = 1;
            decVarC1 = 0.1f;

            CameraScript.inCams = true;

            soundScript.OpenCamera();
            soundScript.UsingCams();
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
        decreaseSpeed = decVarA1 + decVarB1 + decVarC1 + decVarD1 + decVarE1 + 0.1f;

        if(CameraScript.isGameActive == true)
        {
            powerLeft -= decreaseSpeed * Time.deltaTime;
            powerLeft = Mathf.Max(powerLeft, 0f);

            UpdatePowerText(); // Call the method to update the UI text
        }
        
        if(CameraScript.BonnieLocation == CameraScript.Location.OFFICE)
        {
            bonnieInDoor.SetActive(true);
        }
        else
        {
            bonnieInDoor.SetActive(false);
        }
        if(CameraScript.ChicaLocation == CameraScript.Location.OFFICE)
        {
            chicaInWindow.SetActive(true);
        }
        else
        {
            chicaInWindow.SetActive(false);
        }

        if (powerLeft <= 0f)
        {
            soundScript.PowerDown();
        }

    }

    public void OnLeftDoorButtonClick()
    {
        if(LeftDoor.activeInHierarchy == true)
        {
            LeftDoor.SetActive(false);
            IsLeftDoorClosed = false;
            varD = 0;
            decVarD1 = 0f;
        }
        else
        {
            LeftDoor.SetActive(true);
            IsLeftDoorClosed = true;
            varD = 1;
            decVarD1 = 0.1f;

            soundScript.ClosedDoor();
        }
    }

    public void OnRightDoorButtonClick()
    {
        if (RightDoor.activeInHierarchy == true)
        {
            RightDoor.SetActive(false);
            IsRightDoorClosed = false;
            varE = 0;
            decVarE1 = 0f;
        }
        else
        {
            RightDoor.SetActive(true);
            IsRightDoorClosed = true;
            varE = 1;
            decVarE1 = 0.1f;

            soundScript.ClosedDoor();
        }
    }

    private void UpdatePowerText()
    {
        // Update the Text UI element's text with the current powerLeft value
        if (powerText != null)
        {
            powerText.text = powerLeft.ToString("F0") + "%"; // Format as whole number
        }
    }


}
