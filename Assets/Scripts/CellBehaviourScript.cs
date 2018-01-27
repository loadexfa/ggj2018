using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviourScript : MonoBehaviour {
	public GameObject virus;
	private Vector3 pos;
	// Use this for initialization
	void Start () {
		Debug.Log ("start");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "virus") {
			Debug.Log ("collided with virus");
			pos = transform.position;
			Destroy(gameObject);
			Instantiate (virus);
			virus.transform.position = pos;
		}
	}
}
