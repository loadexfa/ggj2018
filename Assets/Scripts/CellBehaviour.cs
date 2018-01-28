using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour {

	public Sprite redBloodCellSprite;
	public Sprite whiteBloodCellSprite;
	public Sprite virusSprite;
	public float speed;

	private SpriteRenderer m_SpriteRenderer;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private Vector3 displacement;
	private Rigidbody2D m_rigidBody;
	private int hp = 1;
	private bool virusNear;

    private GameObject scoreKeeper;

	void Start()
	{
		if (this.gameObject.tag == "white blood cell") {
			hp = 4;
		}
		m_rigidBody = this.GetComponent<Rigidbody2D>();

        scoreKeeper = GameObject.Find("Score");
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
		
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("White blood cell has detected virus");
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "virus") {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, other.transform.position, step);
		}
	}

    void changeToVirus() {
		//Get the SpriteRenderer on this GameObject
		m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
		m_SpriteRenderer.sprite = virusSprite;
		if (this.tag == "white blood cell") {
			// Scale down virus from white blood cell
			transform.localScale += new Vector3 (-0.05F, -0.05F, 0);
            scoreKeeper.SendMessage("IncrementScoreBig"); // tired... this feels like a cheap solution....
		} else if (this.tag == "red blood cell") {
			// Scale up virus from red blood cell
			transform.localScale += new Vector3 (0.06F, 0.06F, 0);
            scoreKeeper.SendMessage("IncrementScore");
		}
		this.tag = "virus";
		this.GetComponent<CellMovement>().enabled = true;
	}
}
