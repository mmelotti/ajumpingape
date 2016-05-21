using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour 
{
	/*void Update () 
	{
		transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
	}*/

	public float characterGameSpeed = 10.0F;
	public float screenLimitsAxisX = 2.5F;

	void Start(){
		//TODO: Get Speed from GameManager
	}

	void Update() {
		Vector3 dir = Vector3.zero;
		//Debug.Log ("Input Acceleration x: " + Input.acceleration.x);
		//Debug.Log ("Input Acceleration z: " + Input.acceleration.z);
		dir.x = Input.acceleration.x;
		/*dir.z = Input.acceleration.z;*/
		if (dir.sqrMagnitude > 1)
			dir.Normalize();

		dir *= Time.deltaTime;
		transform.Translate(dir.x * characterGameSpeed,0,0);

		//Debug.Log ("transform.localPosition.x: " + transform.localPosition.x);
		if (transform.localPosition.x > screenLimitsAxisX) {
			
			transform.Translate(-(transform.localPosition.x-screenLimitsAxisX),0,0);
		}

		if (transform.localPosition.x < -screenLimitsAxisX) {

			transform.Translate(-transform.localPosition.x-screenLimitsAxisX,0,0) ;
		}

		
	}
}