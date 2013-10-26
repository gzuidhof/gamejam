using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBrain : MonoBehaviour {

    GameObject target;
    NavMeshAgent agent;
    public float aggroDistance = 8f;


	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (target && Vector3.Distance(target.transform.position, transform.position) < aggroDistance) 
            MoveToTarget();
	}

    void MoveToTarget()
    {
        if (target != null)
        {
            if (Vector3.Distance(target.transform.position, transform.position) > 1.5f)
            {
                agent.enabled = true;
                agent.SetDestination(target.transform.position);
            }
            else if (Vector3.Distance(target.transform.position, transform.position) < 1.25f)
                agent.enabled = false;
        }

    }

}
