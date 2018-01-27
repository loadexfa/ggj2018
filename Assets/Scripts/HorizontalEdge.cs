using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HorizontalEdge : MonoBehaviour {

    /**
     * todo: the left and right bounding triggers need to be located slightly off-screen on both sides. 
     * Make sure this happens with various screen sizes.
     * Really, everything needs to scale/locate properly...
     **/

    public enum boundLocation { left, right };
    public GameObject playerCharacter;

    public boundLocation screenLocation;

	void Start () {
        if (playerCharacter == null) {
            playerCharacter = GameObject.FindWithTag(("Player"));
        }
	}

    /*private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Hey there...");
    }*/

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Hey there...");

        if (screenLocation == boundLocation.left) {
            playerCharacter.SendMessage("TeleportRight");
        }
        else {
            playerCharacter.SendMessage("TeleportLeft");
        }
    }
}
