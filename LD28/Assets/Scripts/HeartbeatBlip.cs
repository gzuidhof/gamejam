using UnityEngine;
using System.Collections;

public class HeartbeatBlip : MonoBehaviour {


    public float leftBound;
    public float rightBound;

    public float upperBound;
    public float beatInterval;
    private float lastBeat;
    public GameObject deadLine;

    public float horizontalSpeed;

    public bool die;
    public bool alive = true;
    public int lastBeats = 8;


    public float power;
    private float baseY;

    public enum BeatState {
        Flat,
        Up,
        Down
    }

    public BeatState state;


    void Start()
    {
        baseY = transform.localPosition.y;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (alive)
        {

            if (state == BeatState.Up)
            {
                //rigidbody2D.velocity  = (Vector2.up * power);
                rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, (Vector2.up * power), 2f * Time.deltaTime);
                if (transform.localPosition.y > upperBound * 0.85f)
                {
                    audio.Play();
                    state = BeatState.Down;
                }
            }
            if (state == BeatState.Down)
            {
                rigidbody2D.velocity = (-Vector2.up * power * 0.5f);
                if (transform.localPosition.y < -upperBound * 0.2f)
                    state = BeatState.Flat;
            }

            if (state == BeatState.Flat)
            {
                rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, new Vector2(0, baseY - transform.localPosition.y * 6f), 6f * Time.deltaTime);
                if (Time.time - lastBeat > beatInterval)
                {
                    lastBeat = Time.time;
                    state = BeatState.Up;
                    if (die)
                    {
                        beatInterval -= 0.15f;
                        upperBound *= 0.85f;
                        lastBeats--;
                        if (lastBeats <= 4)
                        {
                            audio.pitch = 1.3f;
                            beatInterval = 0.15f;
                            upperBound = 5f;
                            power = 100f;
                        }
                        if (lastBeats <= 0)
                        {
                            OnDeath();

                        }
                    }

                }
            }


            rigidbody2D.velocity = new Vector2(horizontalSpeed, rigidbody2D.velocity.y);

        }
        else
        {
            rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, new Vector2(0, baseY - transform.localPosition.y * 2f), 1.35f * Time.deltaTime);
            rigidbody2D.velocity = new Vector2(horizontalSpeed, rigidbody2D.velocity.y);
        }

        if (transform.localPosition.x > rightBound)
        {
            transform.localPosition = new Vector3(leftBound, transform.localPosition.y, transform.localPosition.z);
        }


	}

    public void OnDeath()
    {
        alive = false;
        deadLine.SetActive(true);
       // transform.localPosition = new Vector3(transform.position.x, 0f, 0f);
        
    }
}
