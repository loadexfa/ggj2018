﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMovement : MonoBehaviour {

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
    void OnMouseDown() {
        startPosition = Input.mousePosition;
    }

    private void OnMouseUp() {
        endPosition = Input.mousePosition;
        Vector3 displacement = endPosition - startPosition;
        rigidBody.AddForce(new Vector2(displacement.x, displacement.y));
    }

    public void TeleportLeft() {
        
    }
}
