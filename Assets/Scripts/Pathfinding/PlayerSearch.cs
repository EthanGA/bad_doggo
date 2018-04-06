using UnityEngine;

public class PlayerSearch : MonoBehaviour {

	public bool spotted = false;
	bool potential;
	public GameObject gwyllgi;
	public GameObject player;
	public Ray ray;

	void Update() {
		if (potential) {
			Vector3 direction = (player.transform.position - gwyllgi.transform.position).normalized;
			
			ray = new Ray(gwyllgi.transform.position, direction);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit)) {
				if (hit.collider.gameObject.layer == 9) {
					spotted = true;
				} else {
					spotted = false;
				}
			}
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Player") {
			potential = true;
		} 
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.tag == "Player") {
			spotted = false;
			potential = false;
		}
	}
}
