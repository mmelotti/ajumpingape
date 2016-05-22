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
    private string HOST_URL = " http://104.236.107.223:8181/";
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

    class BalanceInfo
    {
        public float PlayerHorizontalSpeed;
        public float BrainSpawDeltaY;
        public float BananaSpawDeltaY;
        public float JumpForce;
        public float StartJumpForce;
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
        WWW www = new WWW(HOST_URL + "balance/?format=json");
        yield return www;

        if (www.error != null)
        {
            Debug.LogWarning(www.error);
            Debug.LogWarning(www.text);
            updated = false;
        }
        else
        {
            BalanceInfo info = JsonUtility.FromJson<BalanceInfo>(www.text);
            PlayerHorizontalSpeed = info.PlayerHorizontalSpeed;
            BrainSpawDeltaY = info.BrainSpawDeltaY;
            BananaSpawDeltaY = info.BananaSpawDeltaY;
            JumpForce = info.JumpForce;
            StartJumpForce = info.StartJumpForce;
            loading = false;
            updated = true;
        }
    }
}
