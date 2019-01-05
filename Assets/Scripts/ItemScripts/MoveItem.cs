using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
    [HideInInspector]
    public float speed;//speed is given via the spawn script;

    private Vector2 positionToWorld;
    private SpriteRenderer renderer;
    private float colorAlpha = 1;
    private Color thisColor;

    private void Start()
    {
        positionToWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        renderer = GetComponent<SpriteRenderer>();
        thisColor = renderer.color;//get our current color
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position.y > -positionToWorld.y + renderer.bounds.extents.y)//if the thing is higher than the bottom of the screen plus the item itself
            transform.Translate(new Vector2(0, -1 * speed * Time.deltaTime));//move it normally
        else
        {
            StartCoroutine(fadeOut());
        }
    }

    IEnumerator fadeOut()//this is going to fade our object out so the player really feels the weight of it disappearing
    {
        yield return new WaitForSeconds(.3f);//wait for just a bit before it starts to fade

        while(renderer.color.a > 0)//while it's not invisible
        {
            yield return new WaitForSeconds(.1f);
            colorAlpha -= .1f;//decrease the float
            thisColor.a = colorAlpha;//make the color var's alpha = the float
            renderer.color = thisColor;//set our color var to be our new color
        }

       Destroy(this.gameObject);//when it is invisible we fade it out
    }
}
