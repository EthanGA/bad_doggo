using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour {
/* 
	public float startLocation;
	public GameObject Player;
	Vector3 spawn;
	float xAxis;
	float yAxis;
	bool start = false;
	
	void Update () {
		if (Input.anyKeyDown) {
			start = true;
		}
		
		if (start) {		

			bool complete = gameObject.GetComponent<LvlGen3>().complete;

			if (complete) { //this makes sure tile generator is done

				GameObject[] tiles = gameObject.GetComponent<LvlGen3>().tiles;

				if (startLocation == 0) { //used in case start location isn't preset
					xAxis = gameObject.GetComponent<TileGenerator>().xAxis;
					yAxis = gameObject.GetComponent<TileGenerator>().yAxis;
					float roundme = xAxis * yAxis / 2;
					float startLocation = Mathf.Ceil(roundme); 
				}
		
				foreach (GameObject tile in tiles) {
					if (tile.GetComponent<MyNumber>().imnumber == startLocation) {
						spawn = tile.transform.position + Vector3.up;
					}
				}

				Instantiate(Player, spawn, Quaternion.identity);
			}
		}

		start = false;
	}*/
}
