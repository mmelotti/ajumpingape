using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour {

	public GameObject lastScoreButton;
	public GameObject bestScoreButton;

	// Use this for initialization
	void Start () {

		ScoreManager sm = ScoreManager.Instance;

		lastScoreButton.GetComponentInChildren<Text>().text = sm.lastScore.ToString();
		bestScoreButton.GetComponentInChildren<Text>().text = sm.bestScore.ToString();
	}
		

}
