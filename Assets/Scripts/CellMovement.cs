using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMovement : MonoBehaviour {

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Rigidbody2D rigidBody;
//	private CircleCollider2D detectionCircle;

    public Transform teleportLeftDestination;
    public Transform teleportRightDestination;

	// Use this for initialization
	void Start () {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
//		if (this.tag == "white blood cell") {
//			detectionCircle = gameObject.AddComponent<CircleCollider2D>();
//			detectionCircle.radius = 2.0f;
//			detectionCircle.isTrigger = true;
//		}
	}
	
    void OnMouseDown() {
        if (gameObject.tag == "virus") {
            startPosition = Input.mousePosition;
        }
    }

    private void OnMouseUp() {
        if (gameObject.tag == "virus") {
            endPosition = Input.mousePosition;
            Vector3 displacement = endPosition - startPosition;
            rigidBody.AddForce(new Vector2(displacement.x, displacement.y));
        }
    }

    public void TeleportLeft() {
        Vector3 newPosition = new Vector3(teleportLeftDestination.position.x, rigidBody.transform.position.y, 0);
        rigidBody.transform.position = newPosition;
    }

    public void TeleportRight() {
        Vector3 newPositionRight = new Vector3(teleportRightDestination.position.x, rigidBody.transform.position.y, 0);
        rigidBody.transform.position = newPositionRight;
    }
}
