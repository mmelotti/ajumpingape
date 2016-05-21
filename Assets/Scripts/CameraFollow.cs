using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    public float cameraOffset = 5f;
    public float characterGameSpeed = 10.0F;
    private Vector3 initPosition;

    void Start()
    {
        initPosition = transform.position;
        // TODO: Get game speed from balanceManager
    }

    void Update () {
        if (player.transform.position.y > transform.position.y + cameraOffset)
        {
            transform.Translate(Vector2.up * Time.deltaTime * characterGameSpeed);
        }
	}

    public void Reset()
    {
        transform.position = initPosition;
    }
}
