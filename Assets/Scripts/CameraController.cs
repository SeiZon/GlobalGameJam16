using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class CameraController {

	Camera camera;
	private Quaternion cameraRotation;
	private Quaternion playerRotation;
	private Vector2 cursorHotspot;

	public float XSensitivity = 2.0f;
	public float YSensitivity = 2.0f;
	public Texture2D cursorTexture;

	public void Init(Transform player, Transform camera) {
		cameraRotation = camera.localRotation;
		playerRotation = player.localRotation;

		InitCursor();
	}

	public void InitCursor() {
		Cursor.lockState = CursorLockMode.Locked;
		cursorHotspot = new Vector2 (cursorTexture.width / 2, cursorTexture.height / 2);
		Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
	}

	public void RotateCamera(Transform player, Transform camera)
	{
		Cursor.lockState = CursorLockMode.Locked;

		float yRot = Input.GetAxis("Mouse X") * XSensitivity;
		float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

		cameraRotation *= Quaternion.Euler (-xRot, 0f, 0f);
		cameraRotation = LimitVerticalRotation (cameraRotation);

		playerRotation *= Quaternion.Euler (0f, yRot, 0f);

		camera.localRotation = cameraRotation;
		player.localRotation = playerRotation;

		RayCastCursorPosition();
		Cursor.visible = true;
	}

	Quaternion LimitVerticalRotation(Quaternion q)
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1.0f;

		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

		angleX = Mathf.Clamp (angleX, -90f, 90f);

		q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

		return q;
	}

	public void RayCastCursorPosition() {
		Ray ray = GetCenterRay(); 
		Debug.DrawRay (ray.origin, ray.direction, Color.red);
	}

	public Ray GetCenterRay() {
		Vector3 currentMouse = Input.mousePosition;
		Ray ray = Camera.main.ScreenPointToRay (currentMouse);
		return ray;
	}
}
