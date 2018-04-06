using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour {

	bool lightOn = true;
	public LvlGen3 gen;
	Vector3 spawnLoc1, spawnLoc2, spawnLoc3, spawnLoc4;
	List<float> spawnCosts;
	GameObject player;

	void Start() {
		spawnCosts = new List<float>();

		player = transform.parent.gameObject;
		
		int width = gen.width;
		spawnLoc1 = new Vector3(width/2 - 2, 0.4f, width/2 - 2);
		spawnLoc2 = new Vector3(width/2 - 2, 0.4f, -(width/2) + 2);
		spawnLoc3 = new Vector3(-(width/2) + 2, 0.4f, width/2 - 2);
		spawnLoc4 = new Vector3(-(width/2) + 2, 0.4f, -(width/2) + 2);
	}
	
	void Update () {
		if (Input.GetKeyDown("f")) {
			lightOn = !lightOn;
		}		
	}

	void OnTriggerEnter(Collider gwyllgi) {
		if (lightOn && gwyllgi.tag == "gwyllgi") {
			float spawnCost1 = Vector3.Distance(player.transform.position, spawnLoc1);
			spawnCosts.Add(spawnCost1);
			float spawnCost2 = Vector3.Distance(player.transform.position, spawnLoc2);
			spawnCosts.Add(spawnCost2);
			float spawnCost3 = Vector3.Distance(player.transform.position, spawnLoc3);
			spawnCosts.Add(spawnCost3);
			float spawnCost4 = Vector3.Distance(player.transform.position, spawnLoc4);
			spawnCosts.Add(spawnCost4);
			
			float maxCost = spawnCosts.Max();

			if (maxCost == spawnCost1) {
				gwyllgi.transform.position = spawnLoc1;	
			}
			if (maxCost == spawnCost2) {
				gwyllgi.transform.position = spawnLoc2;	
			}
			if (maxCost == spawnCost3) {
				gwyllgi.transform.position = spawnLoc3;	
			}
			if (maxCost == spawnCost4) {
				gwyllgi.transform.position = spawnLoc4;	
			}

			gwyllgi.GetComponent<Unit>().somethingWeird = true;
		}
	}
}
