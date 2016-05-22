using UnityEngine;

public class PlaySoundFX : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource audioSrc = GetComponent<AudioSource>();
            audioSrc.Play();
        }
    }
	
}
