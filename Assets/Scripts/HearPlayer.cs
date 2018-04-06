using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearPlayer : MonoBehaviour {

	public AudioClip growl;
	public AudioSource source;
	public bool heardPlayer;
	public bool isGrowling = false;
	public Vector3 colPoint;
	bool didGrowl = false;
	public GameObject otherDoggo1;
	public GameObject otherDoggo2;

	void OnTriggerEnter (Collider collision) {
		if (collision.gameObject.tag == "sound") {
			colPoint = new Vector3(collision.transform.position.x, 0.4f, collision.transform.position.z);
			heardPlayer = true;
			if (!didGrowl){
				isGrowling = true;
				source.clip = growl;
				source.Play();
				didGrowl = true;
			}
		}
	}

	void Update() {
//		bool seePlayer = GetComponent<Unit>().seePlayer;
//		bool giveUp = GetComponent<Unit>().giveUp;

		if (heardPlayer) {
			if (transform.position == colPoint) {
				heardPlayer = false;
			}
		}

		if (isGrowling) {
			if (source.clip == growl || !source.isPlaying) {
				isGrowling = false;
			}
		}

/*		if (otherDoggo1.GetComponent<HearPlayer>().heardPlayer == true && !heardPlayer && !seePlayer && giveUp) {
			colPoint = otherDoggo1.transform.position;
		}

		if (otherDoggo2.GetComponent<HearPlayer>().heardPlayer == true && !heardPlayer && !seePlayer && giveUp) {
			colPoint = otherDoggo2.transform.position;
		}*/
	}
}
