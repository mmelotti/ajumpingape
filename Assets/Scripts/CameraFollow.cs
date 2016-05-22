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

	float velocity = 0;
	float lastYPos = 0;

    void FixedUpdate () {

		//Calculating velocity to make a smooth cameraOffset change
		velocity = (player.transform.position.y -  lastYPos)/ Time.deltaTime;

		// Maybe camera offset should change when velocity is between 0-15... so camera offset can change between 2 - 3.5 ?
		if(velocity<0) velocity = 0;
		if(velocity>15) velocity = 15;

		velocity = velocity / 10;

		cameraOffset = 3.5F - velocity;

		//Debug.Log( "lastYPos: " +lastYPos+ " Velocity:" + velocity);
			
		//Debug.Log ( "player position y : " + player.transform.position.y + " camera position y: " + transform.position.y);

		if (player.transform.position.y > transform.position.y - cameraOffset)
        {
			Vector3 positionToGo;
			positionToGo.y = player.transform.position.y + cameraOffset;
			positionToGo.x = transform.position.x;
			positionToGo.z = transform.position.z;

            //transform.Translate(Vector2.up * Time.deltaTime * characterGameSpeed);
			transform.position = positionToGo;
        }

		lastYPos = player.transform.position.y;
	}

    public void Reset()
    {
        transform.position = initPosition;
    }
}
