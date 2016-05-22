using UnityEngine;
using System.Collections;

public class DestroyByCollision : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Trigger Enter call");
		if (other.tag == "DestroyerWall" || other.tag == "Player") {
            if (other.CompareTag("Player"))
            {
                AudioSource audioSrc = GetComponent<AudioSource>();
                audioSrc.Play();
                GetComponent<SpriteRenderer>().enabled = false;
                
            }
            Invoke("HideObject", 0.5f);
		}
	}

    void HideObject()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        gameObject.SetActive(false);
    }
}
