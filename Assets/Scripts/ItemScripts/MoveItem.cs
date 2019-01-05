using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
    [HideInInspector]
    public float speed;//speed is given via the spawn script;

    private void Update()
    {
        transform.Translate(new Vector2(0, -1 * speed * Time.deltaTime));
    }
}
