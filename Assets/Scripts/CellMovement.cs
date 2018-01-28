using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMovement : MonoBehaviour {
	
	public Transform teleportLeftDestination;
	public Transform teleportRightDestination;
    
	private Vector3 startPosition;
    private Vector3 endPosition;
    private Rigidbody2D rigidBody;

	void Start () {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
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
