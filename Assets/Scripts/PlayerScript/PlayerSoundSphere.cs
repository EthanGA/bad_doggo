using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundSphere : MonoBehaviour {

	public AudioClip grassNormal;
	public AudioClip grassSlow;
	public AudioClip grassFast;
	public AudioClip waterNormal;
	public AudioClip waterSlow;
	public AudioClip waterFast;

	public AudioSource movement;

	bool playingWater = false;
	bool playingGrass = false;

	void Update() {
		
		RaycastHit hit;
		Vector3 origin = gameObject.transform.position;
		
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) {
			if (Physics.Raycast(origin, Vector3.down, out hit)) {
				if (hit.collider.tag == "Grass") {
					if (!playingGrass && Input.GetKey(KeyCode.LeftShift)) {
						movement.clip = grassFast;
						movement.Play();
						playingGrass = true;
						playingWater = false;
						
					} else if (!playingGrass && Input.GetKey(KeyCode.LeftControl)) {
						movement.clip = grassSlow;
						movement.Play();
						playingGrass = true;
						playingWater = false;
						
					} else {
						movement.clip = grassNormal;
						movement.Play();
						playingGrass = true;
						playingWater = false;
					}
				}

				if (hit.collider.tag == "Water") {
					if (!playingWater && Input.GetKey(KeyCode.LeftShift)) {
						movement.clip = waterFast;
						movement.Play();
						playingWater = true;
						playingGrass = false;
			
					} else if (!playingWater && Input.GetKey(KeyCode.LeftControl)) {
						movement.clip = waterSlow;
						movement.Play();
						playingWater = true;
						playingGrass = false;
		
					} else {
						movement.clip = waterNormal;
						movement.Play();
						playingWater = true;
						playingGrass = false;
					}
				}
			}
		} else {
			movement.Stop();
			playingGrass = false;
			playingWater = true;
		}
	}
}
