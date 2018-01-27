﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour {
	public Sprite redBloodCellSprite;
	public Sprite whiteBloodCellSprite;
	public Sprite virusSprite;
	private SpriteRenderer m_SpriteRenderer;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private Vector3 displacement;
	private Rigidbody2D m_rigidBody;
	private int hp = 1;

	void Start()
	{
		m_rigidBody = this.GetComponent<Rigidbody2D> ();
		if (this.gameObject.tag == "white blood cell") {
			hp = 5;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "virus") {
			Debug.Log ("collided with virus");
			if ((this.gameObject.tag == "red blood cell")||(hp <= 0)) {
				changeToVirus ();
			} else if (this.gameObject.tag == "white blood cell") {
				hp -= 1;
				Destroy(coll.gameObject);
			}
		}
	}

	void changeToVirus() {
		//Get the SpriteRenderer on this GameObject
		m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
		m_SpriteRenderer.sprite = virusSprite;
		this.tag = "virus";
		this.GetComponent<CellMovement>().enabled = true;
	}
}
