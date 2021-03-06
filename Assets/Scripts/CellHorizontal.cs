﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHorizontal : MonoBehaviour {

    public enum direction { right, left };

    public direction currentDirection;

    Rigidbody2D m_rigidBody;

    // Use this for initialization
    void Start () {
        m_rigidBody = this.GetComponent<Rigidbody2D>();

		// add some randomized force that prefers right direction
		Vector3 randomDirection = Random.insideUnitSphere * 40 + Vector3.right * 40;
		randomDirection.z = 0;
		m_rigidBody.AddForce (randomDirection);
        InvokeRepeating("ChangeDirection", 0, 1f);

    }

    void ChangeDirection()
    {
        if (currentDirection == direction.left)
            currentDirection = direction.right;

        else if (currentDirection == direction.right)
            currentDirection = direction.left;
    }
    // Update is called once per frame
    void Update ()
    {
        if (currentDirection == direction.right)
        {
            m_rigidBody.AddForce(Vector3.right * .3f);
        }
        else 
        {
            m_rigidBody.AddForce(Vector3.left * .25f);
        }
		
	}
}
