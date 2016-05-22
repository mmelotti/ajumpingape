using UnityEngine;
using UnityEngine.UI;

public class CounterController : MonoBehaviour {

    public ScoreManager.Items type;
	public GameObject scoreCounterText;


    void OnEnable()
    {
		PlayerController.UpdateScoreEvent += UpdateCounter;
        PlayerController.PlayerDiedEvent += Reset;
    }

    void OnDisable()
    {
		PlayerController.UpdateScoreEvent -= UpdateCounter;
        PlayerController.PlayerDiedEvent -= Reset;
    }

    void UpdateCounter(ScoreManager.Items item)
    {
        Text counterTxt = GetComponentInChildren<Text>();
		Text scoreToUpdateTxt = scoreCounterText.GetComponentInChildren<Text>();
        string text = "0";
        if (type.Equals(ScoreManager.Items.banana))
        {
            text = ScoreManager.Instance.bananaCounter.ToString();
			Debug.Log("scorecounter: "+ScoreManager.Instance.scoreCounter.ToString ());
			scoreToUpdateTxt.text = ""+ScoreManager.Instance.scoreCounter.ToString ();

        } else if (type.Equals(ScoreManager.Items.brain))
        {
            text = ScoreManager.Instance.brainCounter.ToString() + "X";
        }
        counterTxt.text = text;
    }

    void Reset()
    {
        UpdateCounter(type);
    }


}
