using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class MoreGwyllgi : MonoBehaviour {

	bool seePlayer1, seePlayer2, spawned = false;
	public GameObject gwyllgi1, gwyllgi2;
	public GameObject newGwyllgi;
	public GameObject player;
	public LvlGen3 gen;
	Vector3 spawnLoc1, spawnLoc2, spawnLoc3, spawnLoc4;
	List<float> spawnCosts;

	void Start() {
		spawnCosts = new List<float>();

		int width = gen.width;
		spawnLoc1 = new Vector3(width/2 - 1, 0.4f, width/2 - 1);
		spawnLoc2 = new Vector3(width/2 - 1, 0.4f, -(width/2) + 1);
		spawnLoc3 = new Vector3(-(width/2) + 1, 0.4f, width/2 - 1);
		spawnLoc4 = new Vector3(-(width/2) + 1, 0.4f, -(width/2) + 1);
	}

	void Update () {
		seePlayer1 = gwyllgi1.GetComponent<Unit>().seePlayer;
		seePlayer2 = gwyllgi2.GetComponent<Unit>().seePlayer;

		if (!spawned) {
			if (seePlayer1 || seePlayer2) {
				float spawnCost1 = Vector3.Distance(player.transform.position, spawnLoc1);
				spawnCosts.Add(spawnCost1);
				float spawnCost2 = Vector3.Distance(player.transform.position, spawnLoc2);
				spawnCosts.Add(spawnCost2);
				float spawnCost3 = Vector3.Distance(player.transform.position, spawnLoc3);
				spawnCosts.Add(spawnCost3);
				float spawnCost4 = Vector3.Distance(player.transform.position, spawnLoc4);
				spawnCosts.Add(spawnCost4);

				float minCost = spawnCosts.Min();

				if (minCost == spawnCost1) {
					newGwyllgi.transform.position = spawnLoc1;
					newGwyllgi.SetActive(true);
					spawned = true;
				}
				if (minCost == spawnCost2) {
					newGwyllgi.transform.position = spawnLoc2;
					newGwyllgi.SetActive(true);
					spawned = true;
				}
				if (minCost == spawnCost3) {
					newGwyllgi.transform.position = spawnLoc3;
					newGwyllgi.SetActive(true);
					spawned = true;
				}
				if (minCost == spawnCost4) {
					newGwyllgi.transform.position = spawnLoc4;
					newGwyllgi.SetActive(true);
					spawned = true;
				}
			}
		}
	}
}
