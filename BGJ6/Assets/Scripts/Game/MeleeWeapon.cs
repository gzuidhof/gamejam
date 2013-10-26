using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(TweenRotation))]
public class MeleeWeapon : MonoBehaviour {


    private bool swinging = false;

    public bool playerWeapon;

    private Transform player;

    private TweenRotation tween;

    public float angle = 90f;
    public float range = 1.75f;
    public float dmg = 5f;

    public void Swing()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (swinging) return;
        swinging = true;
        SwingForward();

    }

    void SwingForward()
    {
        if (!gameObject) return;
         tween.Play(true);
    }

    void SwingBack()
    {
        if (!gameObject) return;
            tween.Play(false);
    }




	// Use this for initialization
	void Start () {
        tween = GetComponent<TweenRotation>();
	}
	
	// Update is called once per frame
	void Update () {

        if (playerWeapon && Input.GetKey(Bindings.Get(Bindings.Key.Fire)))
            Swing();
	}


    void TryDealDamagePlayer()
    {
        if (Vector3.Distance(player.position, transform.position) < range)
            player.GetComponent<Player>().DealDamage(dmg);

    }

    void TryDealDamageEnemies()
    {
        List<Enemy> toBeRemoved = new List<Enemy>();
        foreach (Enemy enemy in Enemy.enemies)
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) < range
                && Vector3.Angle(transform.root.forward, enemy.transform.position - transform.root.position) < angle / 1.9f)
                enemy.DealDamage(dmg);
            if (!enemy.alive) toBeRemoved.Add(enemy);
        }

        foreach (Enemy enemy in toBeRemoved)
        {
            Enemy.enemies.Remove(enemy);

        }
    }

    public void OnSwingFinish()
    {
        if (!gameObject) return;
        if (tween.direction == AnimationOrTween.Direction.Forward)
        {
            if (!playerWeapon)
                TryDealDamagePlayer();
            else
            {
                TryDealDamageEnemies();
            }
            SwingBack();
        }
        else
        {
            swinging = false;
        }

    }


}
