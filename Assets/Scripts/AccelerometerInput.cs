using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour 
{

	public float characterGameSpeed = 10.0F;
	public float screenLimitsAxisX = 2.5F;

	void Start(){
		//TODO: Get Speed from GameManager
	}

	void Update() {
        
        Vector3 dir = Vector3.zero;        
        dir.x = Input.acceleration.normalized.x;
        dir *= Time.deltaTime * characterGameSpeed;
		transform.Translate(dir);

		//Debug.Log ("transform.localPosition.x: " + transform.localPosition.x);
		if (transform.localPosition.x > screenLimitsAxisX) {			
			transform.Translate(-(transform.localPosition.x-screenLimitsAxisX), 0, 0);
		}

		if (transform.localPosition.x < -screenLimitsAxisX) {

			transform.Translate(-transform.localPosition.x-screenLimitsAxisX, 0, 0) ;
		}
    }
}