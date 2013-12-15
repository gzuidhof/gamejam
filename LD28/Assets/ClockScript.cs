using UnityEngine;
using System.Collections;

public class ClockScript : MonoBehaviour {

    private float lastTick;


    public Transform[] arms;

    void Start()
    {
        foreach (Transform t in arms)
        {
            t.eulerAngles = new Vector3(t.rotation.eulerAngles.x, t.rotation.eulerAngles.y, Random.Range(0f, 360f));
        }
    }

    void Tick()
    {
        if (audio)
            audio.Play();
        transform.Rotate(transform.forward, -1f);
    }

	// Update is called once per frame
	void Update () {
        if (Time.time - lastTick >= 1)
        {
            lastTick = Time.time;
            Tick();
        }
        

	}
}
