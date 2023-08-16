using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSystemScript : MonoBehaviour
{
    public OfficeScript officeScript;

    public GameObject[] usageBars; // Array of all usage bar gameObjects
    public GameObject generalPowerDrainBar; // General power drain bar gameObject
    //private int nextInactiveIndex = 0; // Index of the next inactive object
    public int activeBars = 0; 

    //private int activeBarCount = 0; // Count of currently active bars
    // Start is called before the first frame update
    void Start()
    {
        // Reset all usage bars to inactive
        foreach (GameObject bar in usageBars)
        {
            bar.SetActive(false);
        }

        // Activate the general power drain bar
        generalPowerDrainBar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject bar in usageBars)
        {
            if (bar.activeSelf)
            {
                activeBars++;
            }
        }
       
        // Check each boolean and activate the corresponding usage bar
        if (officeScript.AreLeftLightsActive == true)
        {
            usageBars[activeBars].SetActive(true);
        }
        else
        {
            usageBars[activeBars].SetActive(false);
        }
       /* if (officeScript.AreRightLightsActive == true)
        {
            ActivateNextBar();
        }
        if (officeScript.AreCamsActive == true)
        {
            ActivateNextBar();
        }
        if (!officeScript.IsLeftDoorClosed == true)
        {
            ActivateNextBar();
        }
        if (!officeScript.IsRightDoorClosed == true)
        {
            ActivateNextBar();
        }*/
    }

    // Activate the next available usage bar
     /*void ActivateNextBar()
    {
       if(activeBars < usageBars.Length)
        {
            usageBars[activeBars].SetActive(true);
        }
    }*/

}
