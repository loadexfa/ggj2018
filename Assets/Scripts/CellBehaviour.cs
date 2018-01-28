using System.Collections;
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
			if (this.gameObject.tag == "red blood cell") {
				changeToVirus ();
			} else if (this.gameObject.tag == "white blood cell") {
				if (hp <= 0) {
					changeToVirus ();
				} else {
					Destroy (coll.gameObject);
					hp -= 1;
				}
			}
		}
	}
		
	void OnTriggerEnter(Collider other) {
		Debug.Log ("White blood cell has detected virus");
//		Destroy(other.gameObject);
	}

	void changeToVirus() {
		//Get the SpriteRenderer on this GameObject
		m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
		m_SpriteRenderer.sprite = virusSprite;
		if (this.tag == "white blood cell") {
			// Scale down virus from white blood cell
			transform.localScale += new Vector3 (-0.05F, -0.05F, 0);
		} else if (this.tag == "red blood cell") {
			// Scale up virus from red blood cell
			transform.localScale += new Vector3 (0.06F, 0.06F, 0);
		}
		this.tag = "virus";
		this.GetComponent<CellMovement>().enabled = true;
	}
}
