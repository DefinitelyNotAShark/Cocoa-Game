using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    private string horizontalAxisName;

    [SerializeField]
    private float speed;

    private float horizontalAxisValue;
	
	void Update ()
    {
        GetInput();
	}

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        horizontalAxisValue = Input.GetAxis(horizontalAxisName);
    }

    private void Move()
    {
        transform.Translate(horizontalAxisValue * speed * Time.deltaTime, 0, 0);//move the player along the x axis
    }

}
