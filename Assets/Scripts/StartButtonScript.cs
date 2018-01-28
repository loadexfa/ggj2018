using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour {

	public Sprite selected;
	public Sprite notSelected;
	public bool clockwise;

	void Start(){
		clockwise = true;
	}

	void Update(){
		animate ();
	}

	void OnMouseEnter(){
		gameObject.GetComponent<SpriteRenderer>().sprite = selected;
	}

	void OnMouseExit(){
		gameObject.GetComponent<SpriteRenderer>().sprite = notSelected;
	}

	void OnMouseUp(){
		SceneManager.LoadScene(1);
	}

	void animate(){
		//Debug.Log ("z is " +transform.rotation.z);
		if (clockwise) {
			if (transform.rotation.z > 0.3) {
				
				clockwise = false;
			} else {
				gameObject.transform.Rotate (new Vector3 (0, 0, 10) * Time.deltaTime);
			}
		} else {
			if (transform.rotation.z < -0.3) {
				clockwise = true;
			} else {
				gameObject.transform.Rotate (new Vector3 (0, 0, -10) * Time.deltaTime);
			}
		}

	}
}
