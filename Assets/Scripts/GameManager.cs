using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    public float PlayerHorizontalSpeed = 10;
    public float BrainSpawDeltaY = 5;
    public float BananaSpawDeltaY = 20;
    public float JumpForce = 15;
    public float StartJumpForce = 15;
    private bool updated = false;
    private string HOST_URL = "http://104.236.107.223:8181/";
    private bool loading = false;


    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("GameManager");
                obj.AddComponent<GameManager>();
            }

            return _instance;
        }
    }


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _instance = this;
    }

    [System.Serializable]
    public class BalanceInfo
    {
        public float playerHorizontalSpeed;
        public float brainSpawDeltaY;
        public float bananaSpawDeltaY;
        public float jumpForce;
        public float startJumpForce;

        public static BalanceInfo CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<BalanceInfo>(jsonString);
        }

    }

    void Start()
    {
        UpdateBalance();
    }
    
    public void UpdateBalance()
    {
        loading = true;
        StartCoroutine(LoadBalanceValues());
    }

    /// <summary>
    /// Faz a leitura do ranking do webservice
    /// </summary>
    /// <returns></returns>
    public IEnumerator LoadBalanceValues()
    {
        WWW www = new WWW(HOST_URL + "api/gamebalance?format=json");
        yield return www;

        if (www.error != null)
        {
            Debug.LogWarning(www.error);
            Debug.LogWarning(www.text);
            updated = false;
        }
        else
        {
            BalanceInfo info = BalanceInfo.CreateFromJSON(www.text);
            Debug.Log("BalanceInfo:" + info);
            PlayerHorizontalSpeed = info.playerHorizontalSpeed;
            BrainSpawDeltaY = info.brainSpawDeltaY;
            BananaSpawDeltaY = info.bananaSpawDeltaY;
            JumpForce = info.jumpForce;
            StartJumpForce = info.startJumpForce;
            loading = false;
            updated = true;
        }
    }
}
