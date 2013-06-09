using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float alarmLevel = 0f;
    private GameObject player;
    private Player playerScript;

    public float dmgPerRay = 0.15f;
    
    public static GameManager instance;



	// Use this for initialization
	void Start () {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (alarmLevel > 0.1f)
            alarmLevel -= 0.1f * Time.deltaTime;
        else 
            alarmLevel = 0;

        if (alarmLevel > 1f)
        {
            alarmLevel = 0;
            playerScript.Respawn();
        }
	}

    public void RaiseAlarm()
    {
        alarmLevel += dmgPerRay;
    }


}
