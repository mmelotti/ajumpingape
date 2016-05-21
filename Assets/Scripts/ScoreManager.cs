using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	private static ScoreManager _instance;

	public int lastScore;
	public int bestScore;

	public static ScoreManager Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject fbm = new GameObject("ScoreManager");
				fbm.AddComponent<ScoreManager>();
			}

			return _instance;
		}
	}


	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		_instance = this;

	}

	//TODO: Save a local score and load on start or awake.
	
}