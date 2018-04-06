using UnityEngine.UI;
using UnityEngine;

public class Caught : MonoBehaviour {

	public Canvas canvas;
	public Image image;
	public Text text;
	public bool caught = false;

	void Start() {
		image.GetComponent<CanvasRenderer>().SetAlpha(0.05f);
		text.GetComponent<CanvasRenderer>().SetAlpha(0f);
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "gwyllgi") {
			caught = true;
			GetComponentInParent<Movement>().enabled = false;
			image.CrossFadeAlpha(1f, 3, false);
			text.CrossFadeAlpha(1f, 5, false);
		} 
	} 
}