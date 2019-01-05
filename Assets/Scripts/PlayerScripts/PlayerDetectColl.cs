using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectColl : MonoBehaviour
{
    [SerializeField]
    private UIManager uIManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("There's a collision here");

        if (collision.gameObject.tag == "Marshmallow")//marshmallow
        {
            uIManager.IncreasePoints(1);//HACK magic number
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Nasty")//nasty
        {
            uIManager.DecreaseQuality();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "CandyCane")//candy cane
        {
            uIManager.IncreaseQuality();
            uIManager.IncreasePoints(3);//HACK magic number change later for combos?
            Destroy(collision.gameObject);
        }
    }
}
