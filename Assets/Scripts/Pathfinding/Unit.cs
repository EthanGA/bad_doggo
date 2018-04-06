using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    public Transform target;
    public GameObject player;
    Vector3 oldTargetPosition, colPoint;
    public float speed;
    Vector3[] path;
    int targetIndex;

    public bool draw, seePlayer, giveUp, heardPlayer, somethingWeird; 

    void Start() {
        seePlayer = false;
        giveUp = true;
        oldTargetPosition = target.position;
        somethingWeird = false;
    }

    void Update() {
        RaycastHit hit;
		Vector3 origin = gameObject.transform.position;
        heardPlayer = gameObject.GetComponent<HearPlayer>().heardPlayer;
		
		if (Physics.Raycast(origin, Vector3.down, out hit)) {
			if (hit.collider.tag == "Grass") {
				speed = 3f;
			}

			if (hit.collider.tag == "Water") {
				speed = 1f;
			}

			if (hit.collider.tag == "Stone") {
				speed = 5f;
			}
		}
	

        if (gameObject.GetComponentInChildren<PlayerSearch>().spotted == true) {
            seePlayer = true;
            giveUp = false;
        }

        if (gameObject.GetComponentInChildren<PlayerSearch>().spotted == false) {
            seePlayer = false;
        }

        if (heardPlayer && !seePlayer && giveUp) {
		    colPoint = gameObject.GetComponent<HearPlayer>().colPoint;
            PathRequestManager.RequestPath(transform.position, colPoint, OnPathFound);
            if (transform.position == colPoint) {
                heardPlayer = false;
                gameObject.GetComponent<HearPlayer>().heardPlayer = false;
            }
        }

        if (seePlayer && !giveUp) {
            Vector3 newTarget = player.transform.position;
            if (oldTargetPosition != target.position) {
                PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
                oldTargetPosition = target.position;
            }
        }

        if (!seePlayer && !giveUp) {
            
            float xOffset = target.position.x + 0.5f;
            float zOffset = target.position.z + 0.5f;

            if ((transform.position.x <= xOffset && transform.position.x >= -xOffset) && (transform.position.z <= zOffset && transform.position.z >= -zOffset)) {
                StopCoroutine("FollowPath");
                giveUp = true;
            }
        }

        if (transform.position == target.position) {   //add offset? when things work again
            giveUp = true;
            if (seePlayer) {
                Debug.Log("caught the bastard");
            }
        }

  /*      if (somethingWeird) {
            Debug.Log("Somein feel weird going on");
            seePlayer = false;
            giveUp = true;
            heardPlayer = false;
            gameObject.GetComponent<HearPlayer>().heardPlayer = false;
            StopCoroutine("FollowPath");
            somethingWeird = false;
        } */
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
        if (pathSuccessful) {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath() {
        Vector3 currentWaypoint = path[0];

        while (true) {
            if (transform.position == currentWaypoint) {
                targetIndex++;
                if (targetIndex >= path.Length) {
                    yield break;
                }
                currentWaypoint = path[targetIndex]; 
            }

            transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,speed * Time.deltaTime);
            yield return null;
        }
    }

    public void OnDrawGizmos() {
        if (path != null) {
            for (int i = targetIndex; i < path.Length; i++) {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);
                
                if (i == targetIndex) {
                    Gizmos.DrawLine(transform.position, path[i]);
                } else {
                    Gizmos.DrawLine(path[i-1],path[i]);
                }
            }
        }
    }
}