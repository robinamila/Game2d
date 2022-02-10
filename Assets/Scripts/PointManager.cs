using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{


    public int Point = 0;
    public TextMeshProUGUI PointText;
    
    public int PointsToEnableTarget;

    public GameObject TargetToEnable;


    public void AddPoint(int amount)
    {
        Point += amount;
        PointText.text = "Point: " + Point;

        if(Point >= PointsToEnableTarget)
        {
            TargetToEnable.SetActive(true);
        }
    }
   
}
