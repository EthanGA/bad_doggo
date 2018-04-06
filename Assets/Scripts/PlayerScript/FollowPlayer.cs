using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;
	public Rigidbody rb;
	Vector3 offset;
	Vector3 sky;
	bool odd = false;
	bool lightOff;
	bool reset;
//	float vision;

	void Start () {
		offset.Set(0,20,0);
	}

	void Update () {
		lightOff = player.GetComponent<Movement>().lightOff;
		reset = player.GetComponent<Movement>().reset;
//		vision = player.GetComponent<Movement>().vision;


		rb.transform.position = player.transform.position + offset + sky;

		if (Input.GetKeyDown("k")) {
			odd = !odd;
			if (odd) {
				sky = new Vector3(0, 50, 0);
			} else {
				sky = Vector3.zero;
			}
		}

/*		if (lightOff && vision <= 0.03f) {
			
			vision += 0.005f * Time.deltaTime;
			RenderSettings.ambientLight = new Color(vision, vision, vision, 1);
		}

		if (!lightOff && !reset) {
			RenderSettings.ambientLight = new Color(0.01f, 0.01f, 0.01f, 1);
			vision = 0.01f;
			reset = true;
		}*/
	}
}
