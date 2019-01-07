using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum Quality
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
        Bad,
        Awful,
        Disgusting,
        Inedible,
        LiterallyGarbage
    }

    public static Quality cocoaQuality = Quality.Satisfactory;
    
    [SerializeField]
    private Text pointText;

    [SerializeField]
    private Text comboText;

    private ParticleSystem comboParticles;
    private int points = 0;
    public static int comboNum = 0;


    private void Start()
    {
        comboParticles = comboText.GetComponentInChildren<ParticleSystem>();
    }
    private void Update()
    {
        pointText.text = "Points: " + points;
        comboText.text = "Combo x " + comboNum + "!";

        if(comboNum >=5)
        {
            comboText.enabled = true;//show our combo
            if(comboNum == 10)
            {
                comboText.color = Color.yellow;
                comboParticles.Play();
            }
        }
        else
        {
            comboText.enabled = false;
            comboText.color = Color.white;
            comboParticles.Stop();
        }
    }
    #region Public Functions

    public void IncreasePoints(int pointAmount)
    {
        points += pointAmount;
    }

    public void IncreaseQuality()
    {  
        if (cocoaQuality > 0)//if quality isn't at top notch
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