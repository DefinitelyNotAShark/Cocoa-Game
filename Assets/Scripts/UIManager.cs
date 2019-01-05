using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private enum Quality
    {
        Perfect,
        Incredible,
        Excellent,
        Great,
        Tasty,
        Good,
        Satisfactory,
        Acceptable,
        Poor,
        Low,
        Bad,
        Disgusting,
        Inedible,
        LiterallyGarbage
    }

    private Quality cocoaQuality;

    [SerializeField]
    private Text pointText;

    private int points = 0;

    private void Update()
    {
        pointText.text = "Points: " + points;
    }
    #region Public Functions

    public void IncreasePoints(int pointAmount)
    {
        points += pointAmount;
    }

    public void IncreaseQuality()
    {
        if(cocoaQuality > 0)//if quality isn't at top notch
        {
            cocoaQuality--;
        }
    }

    public void DecreaseQuality()
    {
        if(!cocoaQuality.Equals(Quality.LiterallyGarbage))//this might not work, we can change it later 
        {
            cocoaQuality++;
        }
    }
    #endregion
}