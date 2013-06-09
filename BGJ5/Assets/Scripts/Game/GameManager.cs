using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float alarmLevel = 0f;
    private GameObject player;
    private Player playerScript;

    public float dmgPerRay = 0.15f;
    
    public static GameManager instance;

    public Light easyLight;
    public GameObject playerLight;
    public Light playerOverheadLight;
    public static Transform playerRespawnDefault;

    private Color baseColor;
    public bool playerInvincible = false;


	// Use this for initialization
	void Start () {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        baseColor = playerOverheadLight.color;
        playerRespawnDefault = GameObject.FindGameObjectWithTag("Respawn").transform;
	}

    public static Vector3 GetDefaultRespawn() {
        if (playerRespawnDefault) return playerRespawnDefault.position;
        else
        {
            playerRespawnDefault = GameObject.FindGameObjectWithTag("Respawn").transform;
                return GetDefaultRespawn();
        }
    }

	
	// Update is called once per frame
	void Update () {
        if (playerScript.GetNegativeButtonDown()) 
            alarmLevel = 1.5f;

        if (playerInvincible) return;
        if (alarmLevel > 0.1f)
        {
            alarmLevel -= 0.1f * Time.deltaTime;
            playerOverheadLight.color = baseColor - new Color(0, alarmLevel, alarmLevel);
        }
        else
            alarmLevel = 0;

        if (alarmLevel > 1f)
        {
            alarmLevel = 0;
            playerOverheadLight.color = baseColor;
            playerScript.Respawn();
        }
	}

    public void EasyMode()
    {
        easyLight.enabled = true;
        playerScript.Respawn();
    }
    public void NormalMode()
    {
        playerScript.Respawn();

    }
    public void HardMode()
    {
        playerLight.SetActive(false);// = false;
        baseColor = baseColor / 3f;
        playerOverheadLight.color = baseColor;
        playerScript.Respawn();
    }


    public void RaiseAlarm()
    {
        alarmLevel += dmgPerRay;
    }


}
