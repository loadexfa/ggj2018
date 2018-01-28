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
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject cell = Instantiate(whiteCellPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        cell.GetComponent<CellMovement>().teleportLeftDestination = leftBoundary;
        cell.GetComponent<CellMovement>().teleportRightDestination = rightBoundary;
    }

    void SpawnRedCell() {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject cell = Instantiate(redCellPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        cell.GetComponent<CellMovement>().teleportLeftDestination = leftBoundary;
        cell.GetComponent<CellMovement>().teleportRightDestination = rightBoundary;
    }
}
