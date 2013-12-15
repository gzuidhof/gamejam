using UnityEngine;
using System.Collections;

public class RocketControl : MonoBehaviour {

    public float thrust = 5f;
    public float side = 12f;
    public float responsiveness;
    public bool launched;
    public AudioClip launchDeniedSound;

    public GameObject gameOver;

	// Update is called once per frame
	void FixedUpdate () {

        Vector2 desiredVelocity = Vector2.zero;

        if (launched)
        {
            desiredVelocity = (transform.up * thrust);

        }
        else
        {
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
           // desiredVelocity += new Vector2(side, rigidbody2D.velocity.y);
            transform.Rotate(transform.forward, -side);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(transform.forward, side);
            //desiredVelocity += new Vector2(-side, rigidbody2D.velocity.y);
        }
        rigidbody2D.angularVelocity = 0f;
        rigidbody2D.velocity =  Vector2.Lerp(rigidbody2D.velocity, desiredVelocity, responsiveness * Time.deltaTime);

	}

    public void Launch()
    {
        if (DecoupleButton.decoupled)
        {
            if (audio) audio.Play();
            launched = true;
        }
        else
        {
            audio.PlayOneShot(launchDeniedSound);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerDeath")) 
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            gameOver.SetActive(true);
            Invoke("RestartLevel", 1.5f);
        }

    }

    void RestartLevel()
    {
        Application.LoadLevel("rocket");
    }


}
