using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHorizontal : MonoBehaviour {

    public enum direction { right, left };

    public direction currentDirection;

    Rigidbody2D m_rigidBody;

    // Use this for initialization
    void Start () {
        m_rigidBody = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (currentDirection == direction.right)
        {
            m_rigidBody.AddForce(Vector3.right * .15f);
        }
		
	}
}
