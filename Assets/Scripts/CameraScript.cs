using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
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

    [Header("Stage")]
    public Texture imgStageFull;
    public Texture imgStageNoB;
    public Texture imgStageNoBorC;
    public Texture imgStageEmpty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
