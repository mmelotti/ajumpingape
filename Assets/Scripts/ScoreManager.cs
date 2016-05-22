using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	private static ScoreManager _instance;

	public int lastScore;
	public int bestScore;
    [HideInInspector]
    public int bananaCounter = 0;
    [HideInInspector]
    public int brainCounter = 1;

	[HideInInspector]
	public int scoreCounter = 0;

    public enum Items { banana, brain, score };

	public static ScoreManager Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject obj = new GameObject("ScoreManager");
				obj.AddComponent<ScoreManager>();
				obj.GetComponent<ScoreManager>().bestScore = PlayerPrefs.GetInt ("bestScore");
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

    void OnEnable()
    {
        PlayerController.ItemCollectedEvent += OnItemCollected;
        PlayerController.PlayerDiedEvent += Reset;
    }

    void OnDisable()
    {
        PlayerController.ItemCollectedEvent -= OnItemCollected;
        PlayerController.PlayerDiedEvent -= Reset;
    }

    void OnItemCollected(Items item)
    {
        switch(item)
        {
			case Items.banana:
				scoreCounter += brainCounter;
				bananaCounter++;
                break;
            case Items.brain:
                brainCounter++;
                break;
        }
    }

    void Reset()
    {
        bananaCounter = 0;
        brainCounter = 1;
		scoreCounter = 0;
    }

	public void updateScore()
	{
		if (scoreCounter > bestScore) {
			bestScore = scoreCounter;
		}

		lastScore = scoreCounter;

		PlayerPrefs.SetInt("bestScore", bestScore);
	}
	
}