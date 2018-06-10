using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	bool holdingFrog = false;
	GameObject frog = null;
	public GameObject hitboxPlane;

	// Use this for initialization
	void Start () {
		hitboxPlane.GetComponent<MeshCollider>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(holdingFrog){
			hitboxPlane.GetComponent<MeshCollider>().enabled = true;
		} else {
			hitboxPlane.GetComponent<MeshCollider>().enabled = false;
		}
		if(Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);
			Ray touchRay = Camera.main.ScreenPointToRay(touch.position);
			RaycastHit hit;
			if(Physics.Raycast(touchRay.origin, touchRay.direction * 30, out hit)){
				// Debug.Log(hit.collider.gameObject.name);
				if(hit.collider.gameObject.GetComponentInParent<MaleFrog>() != null && !(hit.collider.gameObject.GetComponentInParent<MaleFrog>().state == behaviourStates.PIGGYBACKING)){
					holdingFrog = true;
					frog = hit.collider.gameObject;
					frog.GetComponent<MaleFrog>().pickUp();
				} else if(hit.collider.gameObject == hitboxPlane){
					frog.transform.position = hit.point;
				}
			}
		} else if(holdingFrog){
			frog.GetComponent<MaleFrog>().putDown();
			// frog.transform.position = new Vector3(frog.transform.position.x, 0, frog.transform.position.z);
			frog = null;
			holdingFrog = false;
			// Debug.Log("Stop holding Frog");
		}
	}
}
