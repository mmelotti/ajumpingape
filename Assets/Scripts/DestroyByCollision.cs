using UnityEngine;
using System.Collections;

public class DestroyByCollision : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Trigger Enter call");
		if (other.tag == "DestroyerWall") {
			//gameObject.GetComponent<SimpleMove> ().setToBounce ();
			//Debug.Log ("Trigger Enter collide with obstacle");
			gameObject.SetActive(false);
		}
	}
}
