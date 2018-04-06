using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour {

	public bool gotKey = false;
	public GameObject key;
	public Image image;
	public Text text;
	public AudioClip keyJangle;
	
	GameObject wall;
	bool play = false;

	void Start() {
		text.GetComponent<CanvasRenderer>().SetAlpha(0f);
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "key") {
			gotKey = true;
			key.SetActive(false);
			AudioSource Source = GetComponent<AudioSource>();
			Source.clip = keyJangle;
			Source.Play();
		}

		if (collider.gameObject.tag == "door" && gotKey) {
			wall = collider.gameObject;
			wall.GetComponent<Sound>().play = true;
			GetComponentInParent<Movement>().enabled = false;
			image.CrossFadeAlpha(1f, 3, false);
			text.CrossFadeAlpha(1f, 5, false);
		} 
	}
}
