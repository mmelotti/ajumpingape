using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DelayedSceneChange : MonoBehaviour {
	public float delayTime = 2;
	public int sceneToLoad = 0;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (delayTime);
		SceneManager.LoadScene (sceneToLoad);
	}
	
}
