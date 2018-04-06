using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour {

	public AudioSource heart;
	public AudioSource breath;
	bool exhausted = false;
	bool heartPlaying = false;
	
	void Update () {
		exhausted = GetComponent<Movement>().exhausted;

		if (exhausted && !heartPlaying) {
			heart.volume = 0.5f;
			heart.Play();
			heartPlaying = true;
		}

		if (!exhausted && heartPlaying) {
			float currentVol = heart.volume;
			heart.volume -= (currentVol/2 - 0.05f) * Time.deltaTime;

			if (heart.volume <= 0) {
				heartPlaying = false;
			}
		} 
		
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			breath.Play();
		}
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			breath.Stop();
		}
	}
}
