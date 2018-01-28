using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject whiteCellPrefab;
    public GameObject redCellPrefab;
    public Transform[] spawnPoints;

    public Transform leftBoundary;
    public Transform rightBoundary;

	// Use this for initialization
	void Start () {
        InvokeRepeating(("SpawnWhiteCell"), 4, 10);
        InvokeRepeating(("SpawnRedCell"), 4, 1.5f);
	}
	
    void SpawnWhiteCell() {
        if (!DetectGameEnd()) {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            GameObject cell = Instantiate(whiteCellPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            cell.GetComponent<CellMovement>().teleportLeftDestination = leftBoundary;
            cell.GetComponent<CellMovement>().teleportRightDestination = rightBoundary;
        }
    }

    void SpawnRedCell() {
        if (!DetectGameEnd()) {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            GameObject cell = Instantiate(redCellPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            cell.GetComponent<CellMovement>().teleportLeftDestination = leftBoundary;
            cell.GetComponent<CellMovement>().teleportRightDestination = rightBoundary;
        }
    }

    bool DetectGameEnd() {
        GameObject red = GameObject.FindWithTag("red blood cell");
        GameObject white = GameObject.FindWithTag("white blood cell");
        GameObject virus = GameObject.FindWithTag("virus");

        if (red == null && white == null) {
            Debug.Log("you win!");
            return true;
        }

        if (virus == null) {
            Debug.Log("You lose!");
            return true;
        }

        return false;

    }
}
