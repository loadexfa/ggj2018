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

    public boundLocation screenLocation;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag != "IgnoreBounds") {
            if (screenLocation == boundLocation.left) {
                collision.gameObject.SendMessage("TeleportRight");
            }
            else {
                collision.gameObject.SendMessage("TeleportLeft");
            }
        }
    }
}
