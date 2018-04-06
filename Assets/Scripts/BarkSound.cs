using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BarkSound : MonoBehaviour {

	public AudioClip[] barks;
	public AudioClip panting;
	public AudioClip howl;
	public AudioSource source;
	public GameObject player;

	bool seePlayer, giveUp;
	bool isPanting = false;
	bool isBarking = false;
	bool hasHowled = true;
	bool caught = false;

	void Update () {
		caught = player.GetComponent<Caught>().caught;
		
		if(!source.isPlaying) {
			isPanting = false;
			isBarking = false;
		}
		
		seePlayer = GetComponentInParent<Unit>().seePlayer;
		giveUp = GetComponentInParent<Unit>().giveUp;

		if(!seePlayer && giveUp) {
			if(!hasHowled) {
				source.clip = howl;
				source.Play();
				hasHowled = true;
			}
			if (!isPanting) {
				source.clip = panting;
				source.Play();
				isPanting = true;
			}
		}

		if(!giveUp) {
			if(!isBarking) {
				int rnd = Random.Range(0, 10);
				source.clip = barks[rnd];
				source.Play();
				isBarking = true;
			}
		}

		if (caught) {
			source.volume -= 0.5f * Time.deltaTime;
		}
	}
}