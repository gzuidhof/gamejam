using UnityEngine;
using System.Collections;






[System.Serializable]
public class PlayerStats
{
    public float health = 100f;
    public float mana = 100f;

}

[System.Serializable]
public class PlayerAttributes
{
    public float maxHealth = 100f;
    public float maxMana = 100f;
}



public class Player : MonoBehaviour {

    public PlayerStats stats;
    public PlayerAttributes attributes;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
