using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public int sceneToStart = 0;

	public void LoadDelayed()
	{
		//Load the selected scene, by scene index number in build settings
		SceneManager.LoadScene (sceneToStart);
	}
}
