using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellFloat : MonoBehaviour {

    public enum direction { up, down };

    public direction currentDirection;
 
    Rigidbody2D m_rigidBody;

    // Use this for initialization
    void Start () {
        float startTime = Random.Range(0, 1f);
        float repeatTime = Random.Range(1, 1.5f);
        m_rigidBody = this.GetComponent<Rigidbody2D>();
        InvokeRepeating("ChangeDirection", startTime, repeatTime);
        
    }	
    void ChangeDirection()
    {
        if (currentDirection == direction.up)
            currentDirection = direction.down;

        else if (currentDirection == direction.down)
            currentDirection = direction.up;
    }

	// Update is called once per frame
	void Update () {

        if (currentDirection == direction.up)
        { 
            m_rigidBody.AddForce(Vector3.up * .497f);
        }
        else
        {
            m_rigidBody.AddForce(Vector3.down * .5f);
        }
           
    }
}
