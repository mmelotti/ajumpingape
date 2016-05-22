using UnityEngine;
using System.Collections;

public class AnimatorSpeed : MonoBehaviour {

	private Animator anim;
	public float animatorSpeed = 1;

	void Start () 
	{
		anim = gameObject.GetComponent<Animator> ();
		anim.speed = animatorSpeed;
	}
		
}
