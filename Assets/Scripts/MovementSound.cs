using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSound : MonoBehaviour {

	public AudioClip grassSlow;
	public AudioClip grassFast;
	public AudioClip waterSlow;
	public AudioClip waterFast;
	public AudioSource movement;
	public GameObject player;

	bool playingWater = false;
	bool playingGrass = false;
	bool seePlayer, giveUp;
	bool caught = false;
	bool isGrowling = false;

	void Update () {
		caught = player.GetComponent<Caught>().caught;
		isGrowling = GetComponent<HearPlayer>().isGrowling;

		if (caught) {
			movement.volume -= 0.5f * Time.deltaTime;
		}

		if (!movement.isPlaying) {
			playingWater = false;
			playingGrass = false;
		}

		seePlayer = GetComponent<Unit>().seePlayer;
		giveUp = GetComponent<Unit>().giveUp;

		RaycastHit hit;
		Vector3 origin = gameObject.transform.position;
		
		if (!isGrowling) {
			if (Physics.Raycast(origin, Vector3.down, out hit)) {
				if (hit.collider.tag == "Grass") {
					if (!playingGrass && (!giveUp || seePlayer)) {
						movement.clip = grassFast;
						movement.Play();
						playingGrass = true;
						playingWater = false;
					}
					
					if (!playingGrass && !seePlayer && giveUp) {
						movement.clip = grassSlow;
						movement.Play();
						playingGrass = true;
						playingWater = false;
					}
				}

				if (hit.collider.tag == "Water") {
					if (!playingWater && (!giveUp || seePlayer)) {
						movement.clip = waterFast;
						movement.Play();
						playingWater = true;
						playingGrass = false;
					}
					
					if (!playingWater && !seePlayer && giveUp) {
						movement.clip = waterSlow;
						movement.Play();
						playingWater = true;
						playingGrass = false;
					}
				}
			}
		}
	}
}
