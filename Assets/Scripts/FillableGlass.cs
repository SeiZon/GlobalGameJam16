using UnityEngine;

public class FillableGlass : MonoBehaviour
{
	float maxContents = 0.6f;
	float minContents = -0.6f;

	public float contents = 0.6f;
	public GameObject contentObject;
	public float fillAmount = 1f;

	public void Fill() {
		var oldContents = contents;

		if(contents + fillAmount >= maxContents) {
			contents = maxContents;
		} else {
			contents += fillAmount;
		}
		var delta = contents - oldContents;
		Debug.Log("fillAmount, delta: " + fillAmount + ", " + delta);
		contentObject.transform.Translate(new Vector3(0, delta, 0));
	}


	public void Empty(float amount) {
		Debug.Log("Emptying ze glass");
		var oldContents = contents;

		if(contents - amount <= minContents) {
			contents = minContents;
		} else {
			contents -= amount;
		}

		var delta = oldContents - contents;

		Debug.Log("amount: " + delta);
		contentObject.transform.Translate(new Vector3(0, -delta, 0));
	}
}

