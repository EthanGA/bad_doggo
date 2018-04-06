using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Movement : MonoBehaviour {

	public float terrainModifier;
	float personalModifier;
	float globalMod;
	public float stamina = 7f;
	public bool exhausted = false;
	public GameObject light;
	public GameObject sightline;
	public GameObject camera;
	public GameObject nightVision;
	public bool darkSky, reset = true;
	public bool lightOff = false;
	public float vision = 0.01f;

	void Start() {
		RenderSettings.ambientLight = new Color(0.39f, 0.39f, 0.39f, 1);
	}

	void FixedUpdate() {
		personalModifier = 1.0f;

		if (Input.GetButton("Run")) {
			if (stamina > 0 && !exhausted) {
				personalModifier = 2f;
				stamina -= 2f * Time.deltaTime;
			} else {
				exhausted = true;
				personalModifier = 1.2f;
			}
		}
		
		if (Input.GetButton("Sneak")) {
			personalModifier = 0.5f;
		}

		if (exhausted && stamina >= 7f) {
			exhausted = false;
		}

		if (!Input.GetButton("Run") && stamina <= 7f) {
			stamina += 1f * Time.deltaTime;
		}
		

		float globalMod = terrainModifier * personalModifier;

		Quaternion targetRotation = transform.rotation;
		Vector3 direction = Vector3.zero;
		direction.x = Input.GetAxis("Horizontal"); 
        direction.z = Input.GetAxis("Vertical");
		direction = direction.normalized * Time.deltaTime * globalMod;;
        transform.Translate(direction);
        
		
		if (Input.GetKey("e")) {
			transform.rotation *=  Quaternion.AngleAxis(3, Vector3.up);
			transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation , 30f * Time.deltaTime);
        }
		
		if (Input.GetKey("q")) {
			transform.rotation *=  Quaternion.AngleAxis(3, Vector3.down);
			transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation , 25f * Time.deltaTime);		
		}
	}

	void Update() {
		if (Input.GetKeyDown("f")) {
			if (light.activeInHierarchy) {
				light.SetActive(false);
				sightline.transform.localScale -= new Vector3(20, 20, 20);
				lightOff = true;
				vision = 0f;
				nightVision.SetActive(true);
				camera.SetActive(false);
// 				var gray = camera.GetComponent<PostProcessingBehaviour>();
//				gray.enabled = true;

			} else {
				light.SetActive(true);
				sightline.transform.localScale += new Vector3(20, 20, 20);
				lightOff = false;
				reset = false;
				camera.SetActive(true);
				nightVision.SetActive(false);
//				var gray = camera.GetComponent<PostProcessingBehaviour>();
//				gray.enabled = false;
			}
		}
		
/*		if (Input.GetKeyDown("p") && Input.GetKeyDown("o")) {
			 
			 if (darkSky) {
				RenderSettings.ambientLight = new Color(0.39f, 0.39f, 0.39f, 1);
				darkSky = false;
			 } else {
				RenderSettings.ambientLight = new Color(0.01f, 0.01f, 0.01f, 1);
				darkSky = true;
			 }
		}
 
		if (lightOff && vision <= 0.03f) {
			
			vision += 0.005f * Time.deltaTime;
			RenderSettings.ambientLight = new Color(vision, vision, vision, 1);
		}

		if (!lightOff && !reset) {
			RenderSettings.ambientLight = new Color(0.01f, 0.01f, 0.01f, 1);
			vision = 0.01f;
			reset = true;
		} */
	}
}