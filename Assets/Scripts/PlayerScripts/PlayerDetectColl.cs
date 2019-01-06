using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectColl : MonoBehaviour
{
    [SerializeField]
    private UIManager uIManager;

    [SerializeField]
    private AnimateCombo comboAnimator;

    [SerializeField]
    private ParticleSystem goodSmoke, badSmoke, neutralSmoke;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Marshmallow")//marshmallow
        {
            if (UIManager.comboNum >= 5)
            {
                uIManager.IncreasePoints(1 * UIManager.comboNum);//points increase with our combo and rainbow particles

                goodSmoke.gameObject.SetActive(true);
                neutralSmoke.gameObject.SetActive(false);
                badSmoke.gameObject.SetActive(false);

            }
            else
                uIManager.IncreasePoints(1);//points increase with our combo

            if (badSmoke.isEmitting)//if it's bad, it goes neutral
            {
                goodSmoke.gameObject.SetActive(false);
                neutralSmoke.gameObject.SetActive(true);
                badSmoke.gameObject.SetActive(false);
            }
            UIManager.comboNum++;//give us an addition to our combo
            StartCoroutine(comboAnimator.AnimateCountdownText());//make our text move up a bit for effect
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Nasty")//nasty
        {
            UIManager.comboNum = 0;//give us an addition to our combo
            goodSmoke.gameObject.SetActive(false);
            neutralSmoke.gameObject.SetActive(false);
            badSmoke.gameObject.SetActive(true);
            uIManager.DecreaseQuality();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "CandyCane")//candy cane
        {
            UIManager.comboNum++;//give us an addition to our combo
            StartCoroutine(comboAnimator.AnimateCountdownText());//make our text move up a bit for effect

            if (UIManager.comboNum >= 5)
            {
                uIManager.IncreasePoints(2 * UIManager.comboNum);//points increase with our combo
            }
            else
                uIManager.IncreasePoints(3);//points increase with our combo

            if (badSmoke.isEmitting)//if it's bad, it goes neutral
            {
                goodSmoke.gameObject.SetActive(false);
                neutralSmoke.gameObject.SetActive(true);
                badSmoke.gameObject.SetActive(false);
            }
            else
            {
                goodSmoke.gameObject.SetActive(true);
                neutralSmoke.gameObject.SetActive(false);
                badSmoke.gameObject.SetActive(false);
            }

            uIManager.IncreaseQuality();
            Destroy(collision.gameObject);
        }
    }
}
