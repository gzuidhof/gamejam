using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {


    public GameObject prefab;
    public new bool active;
    public float interval;
    private float lastSpawnTime;
    public Transform moveToOnSpawn;

    public int maxAmount;
    public List<GameObject> spawned;

    public AudioClip spawnSound;


    void Start()
    {
        moveToOnSpawn = GameObject.FindGameObjectWithTag("Player").transform;

    }

	void Update () {
        if (active && Time.time - lastSpawnTime > interval && prefab && spawned.Count < maxAmount)
        {
            lastSpawnTime = Time.time;
            GameObject go = (GameObject) Instantiate(prefab, transform.position, new Quaternion());
            spawned.Add(go);

            if (spawnSound)
                audio.PlayOneShot(spawnSound);

            if (moveToOnSpawn  && Vector3.Distance ( moveToOnSpawn.position, transform.position) < 20f)
                go.GetComponent<NavMeshAgent>().destination = moveToOnSpawn.position;
        }

        List<GameObject> toR = new List<GameObject>(); //To be removed
        foreach (GameObject o in spawned)
            if (!o)
                toR.Add(o);

        foreach (GameObject o in toR)
                spawned.Remove(o);


	}
}
