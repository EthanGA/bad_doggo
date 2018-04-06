using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Wander : MonoBehaviour {

	bool seen, gaveUp, needNewTarget, heardPlayer;
	int[] rnd;
	int count = 0;
	float speed;
	int newX, newY;
	Vector3 colPoint;
	
	void Start () {
		needNewTarget = true;
		rnd = new int[1000];
		for (int i = 1; i < 1000; i++) {
			int newNumber = Random.Range(-3, 4);
			rnd[i] = newNumber;
		}
	}
	
	void Update () {
		if (count >= 1000) {
			count = 1;
		}

		seen = gameObject.GetComponent<Unit>().seePlayer;
		gaveUp = gameObject.GetComponent<Unit>().giveUp;
		speed = gameObject.GetComponent<Unit>().speed;
		heardPlayer = gameObject.GetComponent<HearPlayer>().heardPlayer;		

		if (!seen && gaveUp && !heardPlayer) {
			if (needNewTarget) {
				newX = rnd[count];
				count++;
				newY = rnd[count];
				count++;

				needNewTarget = false;
			}

			if (!needNewTarget) {
				float timer = 0;
				Vector3 target = transform.position + new Vector3(Mathf.Round(newX), 0, Mathf.Round(newY));
			
				if (!Physics.Raycast(target, Vector3.down, 100f)) {
					needNewTarget = true;
					timer = 0;
				} else {

					transform.position = Vector3.MoveTowards(transform.position, target, (speed/2) * Time.deltaTime);
					
					timer += 1f * Time.deltaTime;

					if (transform.position == target || timer >= 10) {
						needNewTarget = true;
					}
				}
			}
		}
	}
}