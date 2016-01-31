using UnityEngine;
using System.Collections;

public class CollisionSound : MonoBehaviour {
	AudioSource audioSource;

	void Start() {
		audioSource = GetComponentInParent<AudioSource>();
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.relativeVelocity.magnitude > 2) {
			if(audioSource) {
				audioSource.Play();
			}
		}
	}
}
