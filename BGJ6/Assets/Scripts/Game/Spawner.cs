using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


    public GameObject prefab;
    public new bool active;
    public float interval;
    private float lastSpawnTime;
    public Transform moveToOnSpawn;

	void Update () {
        if (active && Time.time - lastSpawnTime > interval && prefab)
        {
            lastSpawnTime = Time.time;
            GameObject go = (GameObject) Instantiate(prefab, transform.position, new Quaternion());
            if (moveToOnSpawn)
                go.GetComponent<NavMeshAgent>().destination = moveToOnSpawn.position;
        }
	}
}
