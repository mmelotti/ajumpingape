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

    public enum Items { banana, brain};

	public static ScoreManager Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject obj = new GameObject("ScoreManager");
				obj.AddComponent<ScoreManager>();
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
                bananaCounter+= (1 * brainCounter);
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
    }
	
}