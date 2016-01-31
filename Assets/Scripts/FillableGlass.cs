using UnityEngine;

public class FillableGlass : MonoBehaviour
{
	float contents = 0.6f;
	float fillAmount = 1f;

	public GameObject contentObject;
    public bool isEmpty = false;
	public float maxContents = 0.6f;
	public float minContents = -0.6f;

    public delegate void IsFilled();

    public event IsFilled isFilled;

	public void Start() {
		maxContents = contentObject.transform.localPosition.y;
		contents = maxContents;
		minContents = -maxContents;

		fillAmount = maxContents*2;

		Debug.Log("Height: " + maxContents);
		Debug.Log("Min: " + minContents);
	}

	public void Fill() {
		var oldContents = contents;

		if(contents + fillAmount >= maxContents) {
			contents = maxContents;
		} else {
			contents += fillAmount;
		}

		var delta = contents - oldContents;

		Debug.Log("fillAmount, delta: " + fillAmount + ", " + delta);
//		contentObject.transform.Translate(new Vector3(0, delta, 0));
		TranslatePosition(delta);
	    isEmpty = false;
	    if (isFilled != null) isFilled();
	}


	public void Empty(float amount) {
		Debug.Log("Emptying ze glass");
		var oldContents = contents;

		if(contents - amount <= minContents) {
			contents = minContents;
		    isEmpty = true;
		} else {
			contents -= amount;
		}

		var delta = contents - oldContents;

		Debug.Log("amount: " + delta);
		TranslatePosition(delta);
//		contentObject.transform.Translate(new Vector3(0, -delta, 0));
	}

	public void TranslatePosition(float delta) {
		var pos = contentObject.transform.localPosition;
		pos.y = pos.y + delta;

		contentObject.transform.localPosition = pos;
	}
}

