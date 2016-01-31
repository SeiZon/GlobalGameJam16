using UnityEngine;
using System.Collections;

public class ButtonNextLevel : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField]
    GameObject playButton;
    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
		Application.LoadLevel(1);
	}
    
    
    public void NextLevelButton(int index)
    {
        audio.Play();
        playButton.SetActive(false);
        StartCoroutine(WaitAndPrint(23.0f));
    }
}