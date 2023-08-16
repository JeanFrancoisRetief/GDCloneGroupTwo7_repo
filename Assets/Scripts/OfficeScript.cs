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
        }
        else
        {
            AreLeftLightsActive = false;
        }
        if (RightLightsContainer.activeSelf)
        {
            AreRightLightsActive = true;
        }
        else
        {
            AreRightLightsActive = false;
        }

        //sets the camera navigation to active is space bar is clicked, if already active and spacebar is clicked then deactivates camNav
        if (Input.GetKeyDown(KeyCode.Space) && camNav.activeInHierarchy == true)
        {
            camNav.SetActive(false);
            AreCamsActive = false;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            camNav.SetActive(true);
            AreCamsActive = true;

        }
    }

    public void OnLeftDoorButtonClick()
    {
        if(LeftDoor.activeInHierarchy == true)
        {
            LeftDoor.SetActive(false);
            IsLeftDoorClosed = false;
        }
        else
        {
            LeftDoor.SetActive(true);
            IsLeftDoorClosed = true;
        }
    }

    public void OnRightDoorButtonClick()
    {
        if (RightDoor.activeInHierarchy == true)
        {
            RightDoor.SetActive(false);
            IsRightDoorClosed = false;
        }
        else
        {
            RightDoor.SetActive(true);
            IsRightDoorClosed = true;
        }
    }

}
