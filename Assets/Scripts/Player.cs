using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	Camera mainCamera;

	public CameraController cameraController;
	private GameObject activeObject;

	private float defaultForce = 100f;
	private float forceCounter = 100f;
	private float maximumForce = 4000f;

	void Start () {
		mainCamera = Camera.main;
		cameraController.Init(transform, mainCamera.transform);
	}

	void Update () {
		cameraController.RotateCamera(transform, mainCamera.transform);

		// If Right mouse button
		if(Input.GetMouseButtonDown(1)) {
			if (!activeObject) {
				activeObject = GetFocusedObject();
				InteractWithObject(activeObject);
			}
			else {
				activeObject = null;
			}
		}
		if(Input.GetMouseButton(0)) {
			if(activeObject) {
				if(forceCounter < maximumForce) {
					forceCounter += 100f;
				}
			}
		}

		if(Input.GetMouseButtonUp(0)) {
			if(activeObject && activeObject.tag == "Throwable") {
				FireObject(activeObject, forceCounter);
				forceCounter = defaultForce;
			}
		}

		HoldObject();
	}

	public void InteractWithObject(GameObject gameObject) {
		if(gameObject) {
			switch (gameObject.tag) {
			case "Fillable":
				var fillable = gameObject.GetComponent<FillableGlass>();
				fillable.Fill();
				// No further actions on this, so no need to keep it active
				activeObject = null;
				break;
			default:
				break;
			}
		}
	}

	public void HoldObject() {
		if(activeObject != null && activeObject.tag == "Throwable") {
			activeObject.transform.position = cameraController.GetCenterRay().GetPoint(2.5f);
		}
	}

	public void FireObject(GameObject objectToFire, float forceMultiplier) {
		Ray centerRay = cameraController.GetCenterRay();
		var rb = objectToFire.GetComponent<Rigidbody>();

		rb.AddRelativeForce(centerRay.direction * forceMultiplier);
		activeObject = null;
	}

	public GameObject GetFocusedObject() {
		List<RaycastHit> hits = new List<RaycastHit>();
		GameObject closestObject = null;
		float closestDistance = Mathf.Infinity;

		Ray ray = cameraController.GetCenterRay();

		hits.AddRange(Physics.RaycastAll(ray.origin, ray.direction));

		foreach(RaycastHit hit in hits) {
			GameObject go = hit.collider.gameObject;

			if(hit.distance < closestDistance) {
				switch(go.tag) {
				case "Throwable":
				case "Fillable":
					closestObject = go;
					closestDistance = hit.distance;
					break;
				default:
					break;
				}
			}
		}

		return closestObject;
	}
}
