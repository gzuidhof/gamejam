using UnityEngine;
using System.Collections;

public class LanderControl : MonoBehaviour {


    public float thrust = 8f;
    public float side = 3f;
    public float responsiveness = 5f;
    public GameObject gameOver;
    public ParticleSystem[] effects;
    private bool dead;

    void FixedUpdate()
    {

        Vector2 desiredVelocity = Vector2.zero;
        if (dead) return;
        if (Input.GetKey(KeyCode.UpArrow))
        {
           // desiredVelocity = (transform.up * thrust);
            rigidbody2D.AddForce(transform.up* thrust);
            foreach (var es in effects)
                es.Play();
            audio.volume = 0.8f;
        }
        else
        {
            foreach (var es in effects)
                es.Stop();
            audio.volume = 0f;
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
        //rigidbody2D.angularVelocity = 0f;

        if (desiredVelocity != Vector2.zero)
            rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, desiredVelocity, responsiveness * Time.deltaTime);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerDeath"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            dead = true;
            gameOver.SetActive(true);
            rigidbody2D.velocity = Vector3.zero;
            rigidbody2D.gravityScale = 0f;
            thrust = 0f;
            Invoke("RestartLevel", 1.5f);
        }

    }




    void RestartLevel()
    {
        Application.LoadLevel("lanarlunder");
    }

}
