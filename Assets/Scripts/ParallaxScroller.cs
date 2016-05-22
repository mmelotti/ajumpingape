using UnityEngine;
using System.Collections;

public class ParallaxScroller : MonoBehaviour {

	public float scrollSpeedRatio;
	public float tileSizeZ;

	public GameObject camera;

	private Vector3 startingPosition;

	// Use this for initialization
	void Start () {
		startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		/*
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
		Debug.Log ("new position " + newPosition);
		Vector3 aux = transform.localPosition;
		aux.y = newPosition;
		transform.localPosition = aux; //startingPosition + Vector3.forward * newPosition;*/

		Vector3 aux = Vector3.zero;
		aux.y = -((camera.transform.position.y*scrollSpeedRatio) % (startingPosition.y*2))+startingPosition.y;

		if (aux.y < -startingPosition.y) {
			aux.y = startingPosition.y;
		}

		transform.localPosition = aux;
	}

	/*void OnDisable()
	{
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}*/
}
