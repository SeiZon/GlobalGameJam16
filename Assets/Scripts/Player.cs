using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	Camera mainCamera;

	public CameraController cameraController;
	private GameObject activeObject;

	void Start () {
		mainCamera = Camera.main;
		cameraController.Init(this, mainCamera);
	}

	void Update () {
		cameraController.RotateCamera(transform, mainCamera.transform);

		if(Input.GetMouseButtonDown(1)) {
			if (!activeObject) {
				activeObject = GetFocusedObject();
				InteractWithObject(activeObject);
			}
			else {
				activeObject = null;
			}
		}

		if(Input.GetMouseButtonUp(0)) {
			if(activeObject && activeObject.tag == "Throwable") {
				FireObject(activeObject); 
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
			activeObject.transform.position = cameraController.GetCenterRay().GetPoint(1f);
			activeObject.transform.rotation = mainCamera.transform.rotation;
		}
	}

	public void FireObject(GameObject objectToFire) {
		var rb = objectToFire.GetComponent<Rigidbody>();

		var direction = objectToFire.transform.forward;

		var forceVector = direction * 2000f;
		Debug.DrawRay(mainCamera.transform.position, forceVector, Color.blue, 10f);
		rb.AddForce(forceVector, ForceMode.Force);

		var soundScript = activeObject.GetComponent<CollisionSound>();
		if(soundScript) {
			soundScript.enabled = true;
		}

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
				default:
					closestObject = go;
					closestDistance = hit.distance;
					break;
				}
			}
		}

		return closestObject;
	}
}
