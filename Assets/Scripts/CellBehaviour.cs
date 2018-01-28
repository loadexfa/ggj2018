using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour {

	public Sprite redBloodCellSprite;
	public Sprite whiteBloodCellSprite;
	public Sprite whiteBloodCellMouthOpenSprite;
	public Sprite virusSprite;
	public Sprite virusEyeClosedSprite;
	public float speed;
	public AudioClip squashSound;

	private AudioSource source;
	private SpriteRenderer m_SpriteRenderer;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private Vector3 displacement;
	private int hp = 1;

    private GameObject scoreKeeper;

	void Start()
	{
		m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
		source = GetComponent<AudioSource>();

		if (this.gameObject.tag == "white blood cell") {
			hp = 4;
		} else if (this.gameObject.tag == "virus") {
			ChangeToVirus ();
		}

        scoreKeeper = GameObject.Find("Score");
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "virus") {
			if (this.gameObject.tag == "red blood cell") {
				ChangeToVirus ();
			} else if (this.gameObject.tag == "white blood cell") {
				if (hp <= 0) {
					ChangeToVirus ();
				} else {
					Destroy (coll.gameObject);
					hp -= 1;
					// Scale down white blood cell
					transform.localScale += new Vector3 (-0.01F, -0.01F, 0);
				}
			}
		}
	}
		
	void OnTriggerEnter2D(Collider2D other) {
		if (this.gameObject.tag == "white blood cell" && other.gameObject.tag == "virus") {
			m_SpriteRenderer.sprite = whiteBloodCellMouthOpenSprite;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (this.gameObject.tag == "white blood cell" && other.gameObject.tag == "virus") {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, other.transform.position, step);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (this.gameObject.tag == "white blood cell" && other.gameObject.tag == "virus") {
			m_SpriteRenderer.sprite = whiteBloodCellSprite;
		}
	}
		

	void ChangeToVirus() {
		source.PlayOneShot(squashSound, 0.5f);
		if (this.tag == "white blood cell") {
			// Scale down virus from white blood cell
			transform.localScale += new Vector3 (-0.01F, -0.01F, 0);
            scoreKeeper.SendMessage("IncrementScoreBig"); // tired... this feels like a cheap solution....
		} else if (this.tag == "red blood cell") {
			// Scale up virus from red blood cell
			transform.localScale += new Vector3 (0.06F, 0.06F, 0);
            scoreKeeper.SendMessage("IncrementScore");
		}
		this.tag = "virus";
		m_SpriteRenderer.sprite = virusSprite;
		this.GetComponent<CellMovement>().enabled = true;

		float blinkStartTime = Random.Range(0f, 1f);
		float blinkRepeatTime = Random.Range(3f, 10f);
		InvokeRepeating("VirusBlink", blinkStartTime, blinkRepeatTime);
	}

	void VirusBlink() {
		float blinkTime = Random.Range(0.1f, 0.5f);
		CloseVirusEye();
		Invoke("OpenVirusEye", blinkTime);
	}

	void OpenVirusEye(){
		m_SpriteRenderer.sprite = virusSprite;
	}

	void CloseVirusEye(){
		m_SpriteRenderer.sprite = virusEyeClosedSprite;
	}
}
