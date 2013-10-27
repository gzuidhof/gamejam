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

    public GameObject selectedSpell;

    private float lastDmgTime = 0f;





	// Use this for initialization
	void Start () {
        UpdateHUD();
	}

    void Update()
    {
        RegenHealth();
        RegenMana();
    }


    public void DealDamage(float dmg)
    {
        stats.health -= dmg;
        lastDmgTime = Time.time;
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

    void RegenHealth()
    {

        if (stats.health == attributes.maxHealth) return;

        float healthGain = (Mathf.Sqrt(Time.time - lastDmgTime)-1.8f) * Time.deltaTime * 4f;

        if (healthGain < 0f) return;
        else if (healthGain + stats.health > attributes.maxHealth) stats.health = attributes.maxHealth;
        else stats.health += healthGain;

        UpdateHUD();
    }

    void RegenMana()
    {
        if (stats.mana == attributes.maxMana) return;
        float manaGain = Time.deltaTime * 5f;

        if (manaGain + stats.mana > attributes.maxMana) stats.mana = attributes.maxMana;
        else stats.mana += manaGain;

        UpdateHUD();
    }


    public void OnNotEnoughMana()
    {
        //TODOO
    }

}
