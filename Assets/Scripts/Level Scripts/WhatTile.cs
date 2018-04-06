using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatTile : MonoBehaviour {
	Vector3 origin;
	public GameObject SoundSphere;
	
	void Update () {
		RaycastHit hit;
		origin = gameObject.transform.position;
		
		
		if (Physics.Raycast(origin, Vector3.down, out hit)) {
			if (hit.collider.tag == "Grass") {
				gameObject.GetComponent<Movement>().terrainModifier = 2.0f;
				
				if (Input.GetKey(KeyCode.LeftShift)) {
					SoundSphere.transform.localScale = new Vector3(45, 45, 45);
				} else if (Input.GetKey(KeyCode.LeftControl)) {
					SoundSphere.transform.localScale = new Vector3(10, 10, 10);
				} else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
					SoundSphere.transform.localScale = new Vector3(30, 30, 30);
				} else {
					SoundSphere.transform.localScale = new Vector3(5, 5, 5);
				}
			}

			if (hit.collider.tag == "Water") {
				gameObject.GetComponent<Movement>().terrainModifier = 0.5f;

				if (Input.GetKey(KeyCode.LeftShift)) {
					SoundSphere.transform.localScale = new Vector3(65, 65, 65);
				} else if (Input.GetKey(KeyCode.LeftControl)) {
					SoundSphere.transform.localScale = new Vector3(20, 20, 20);
				} else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
					SoundSphere.transform.localScale = new Vector3(40, 40, 40);
				} else {
					SoundSphere.transform.localScale = new Vector3(5, 5, 5);
				}

			}

			if (hit.collider.tag == "Stone") {
				gameObject.GetComponent<Movement>().terrainModifier = 3.0f;
			}

			if (hit.collider.tag == "Obstacle") {
				gameObject.GetComponent<Movement>().terrainModifier = 0f;
			}
		}
	}
}
