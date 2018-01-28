using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodAi : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (this.tag == "IgnoreBounds" && other.gameObject.tag == "virus") {
            Debug.Log("White blood cell has detected virus");
        }
    }
}
