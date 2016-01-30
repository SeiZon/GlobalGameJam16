using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	Camera mainCamera;

	public CameraController cameraController;
	public GameObject activeObject;


	void Start () {
		mainCamera = Camera.main;
		cameraController.Init(transform, mainCamera.transform);
	}

	void Update () {
		cameraController.RotateCamera(transform, mainCamera.transform);

		// If Right mouse button
		if(Input.GetMouseButtonDown(1)) {
			activeObject = GetFocusedObject();

			//TODO: Do something about grasping and centering the object on screen.

			if(activeObject != null) {
				Debug.Log("HAS OBJECT: " + activeObject);
			} else {
				Debug.Log("No cigar");
			}
		}
		if(Input.GetMouseButtonDown(0)) {
			if(activeObject) {
				FireObject(activeObject);
			}
		}
	}

	public void FireObject(GameObject objectToFire) {
		Ray centerRay = cameraController.GetCenterRay();
		var rb = objectToFire.GetComponent<Rigidbody>();

		rb.AddForce(centerRay.direction);
	}

	public GameObject GetFocusedObject() {
		List<RaycastHit> hits = new List<RaycastHit>();
		GameObject closestObject = null;
		float closestDistance = Mathf.Infinity;

		Ray ray = cameraController.GetCenterRay();

		hits.AddRange(Physics.RaycastAll(ray.origin, ray.direction));

		foreach(RaycastHit hit in hits) {
			GameObject go = hit.collider.gameObject;
			//			Debug.Log("HIT SOMETHING?:\n "+ go);

			// Only add if throwable for now
			if(go.tag == "Throwable" && hit.distance < closestDistance) {
				Debug.Log("Aww yiss");
				closestObject = go;
				closestDistance = hit.distance;
			}
		}

		return closestObject;
	}
}
