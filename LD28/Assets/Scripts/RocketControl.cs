using UnityEngine;
using System.Collections;

public class RocketControl : MonoBehaviour {

    public float thrust = 8f;
    public float side = 3f;
    public float responsiveness = 5f;
    public bool launched;
    public AudioClip launchDeniedSound;

    public GameObject launchEffect;


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
            launchEffect.SetActive(true);
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
            rigidbody2D.velocity = Vector3.zero;
            thrust = 0f;
            Invoke("RestartLevel", 1.5f);
        }

    }

    void RestartLevel()
    {
        Application.LoadLevel("rocket");
    }


}
