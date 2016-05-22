using UnityEngine;

public class AccelerometerInput : MonoBehaviour 
{
    [HideInInspector]
	public float characterGameSpeed = 10.0F;
	public float screenLimitsAxisX = 2.5F;

	void Start(){
        characterGameSpeed = GameManager.Instance.PlayerHorizontalSpeed;
	}

	void Update() {
        
        Vector3 dir = Vector3.zero;        
        dir.x = Input.acceleration.normalized.x;
        dir *= Time.deltaTime * characterGameSpeed;
		transform.Translate(dir);
        
		if (transform.localPosition.x > screenLimitsAxisX) {			
			transform.Translate(-(transform.localPosition.x-screenLimitsAxisX), 0, 0);
		}

		if (transform.localPosition.x < -screenLimitsAxisX) {

			transform.Translate(-transform.localPosition.x-screenLimitsAxisX, 0, 0) ;
		}
    }
}