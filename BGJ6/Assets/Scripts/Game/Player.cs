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

    public UISlider healthSlider;
    public UISlider manaSlider;



	// Use this for initialization
	void Start () {
        UpdateHUD();
	}

    void Update()
    {

    }


    public void DealDamage(float dmg)
    {
        stats.health -= dmg;
        UpdateHUD();
    }

    public void DrainMana(float m)
    {
        stats.mana -= m;
        UpdateHUD();
    }

    void UpdateHUD()
    {
        healthSlider.value = stats.health / attributes.maxHealth;
        manaSlider.value = stats.mana / attributes.maxMana;
    }

}
