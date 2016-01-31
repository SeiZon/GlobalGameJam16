using UnityEngine;
using System.Collections;

public class CollisionSound : MonoBehaviour {
	AudioSource audioSource;
	public bool playOnce = false;

	private bool hasPlayed = false;

	void Start() {
		audioSource = GetComponentInParent<AudioSource>();
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.relativeVelocity.magnitude > 2) {
			if(audioSource && !hasPlayed) {
				audioSource.Play();

				if(playOnce) {
					hasPlayed = true;
				}
			}
		}
	}
}
