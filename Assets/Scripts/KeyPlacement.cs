using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class KeyPlacement : MonoBehaviour {

	public LvlGen3 gen3;
	bool allDone = false;
	int width;
	bool keyPlaced = false;
	public LayerMask obstacle;
	public LayerMask player;
	public LayerMask gwyllgi;

	void Start () {
		allDone = gen3.GetComponent<LvlGen3>().allDone;
		width = (gen3.GetComponent<LvlGen3>().width / 2);
	}
	
	void Update () {
		if (!allDone) {
			allDone = gen3.GetComponent<LvlGen3>().allDone;
		}

		if (allDone && !keyPlaced) {
			float rndX = Random.Range(-width, width);
			float rndY = Random.Range(-width, width);

			gameObject.transform.position = new Vector3(rndX, 0.35f, rndY);
			keyPlaced = (!Physics.CheckSphere(gameObject.transform.position, 0.1f, obstacle) && !Physics.CheckSphere(gameObject.transform.position, 0.3f, player) && !Physics.CheckSphere(gameObject.transform.position, 0.3f, gwyllgi));
		}
	}
}
