using UnityEngine;


public class playerController : MonoBehaviour {

    public float jumpForce = 15f;
    private Vector2 initPosition;

	void Start () {
        initPosition = transform.position;
	}

    void Reset()
    {
        transform.position = initPosition;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("banana"))
        {
            Rigidbody2D rg = GetComponent<Rigidbody2D>();
            rg.velocity = Vector2.zero;
            rg.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        } else if (other.tag.Equals("dead zone"))
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("YOU LOSE");
        Reset();
        // TODO: Exibir tela de derrota
        CameraFollow cam = FindObjectOfType<CameraFollow>();
        cam.Reset(); 
    }
}
