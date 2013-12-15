using UnityEngine;
using System.Collections;

public class HeartbeatCraft : MonoBehaviour {

    public float upperBound;
    public float beatInterval;
    private float lastBeat;
    public GameObject deadLine;
    public KeyCode beatKey;

    public float horizontalSpeed;

    public bool beatNow;
    public float power;
    private float baseY;
    private HeartbeatGame game;

    public enum BeatState
    {
        Flat,
        Up,
        Down
    }

    public BeatState state;


    void Start()
    {
        baseY = transform.localPosition.y;
        game = GetComponent<HeartbeatGame>();
    }

    void Update()
    {
        if (Input.GetKeyDown(beatKey))
            beatNow = true;
    }

    // Update is called once per frame
    void FixedUpdate()
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
                //rigidbody2D.velocity = (-Vector2.up * power * 0.5f);
                rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, (-Vector2.up * power * 0.75f), 4f * Time.deltaTime);

                if (transform.localPosition.y < -upperBound * 0.2f)
                    state = BeatState.Flat;
            }

            if (state == BeatState.Flat)
            {
                rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, new Vector2(0, baseY - transform.localPosition.y * 6f), 6f * Time.deltaTime);
                if (Time.time - lastBeat > beatInterval)
                {
                    lastBeat = Time.time;
                    if (beatNow /*!game.ended*/)
                    {
                        lastBeat = Time.time;
                        state = BeatState.Up;
                        game.Beat();
                    }
                    beatNow = false;

                }
            }


            rigidbody2D.velocity = new Vector2(horizontalSpeed, rigidbody2D.velocity.y);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerDeath"))
            game.Hit();
    }


}
