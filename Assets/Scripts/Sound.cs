using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

	public bool play = false;
	AudioSource clip;

	void Awake () {
		clip = GetComponent<AudioSource>();
	}

	void Update () {
		if (play) {
			clip.Play();
			play = !play;
		}
	}
}
