using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlashlightBehaviour : MonoBehaviour {

    private Light light;

    public static List<Light> lights = new List<Light>();


	// Use this for initialization
	void Start () {
        light = (Light) GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.DrawRay(transform.position, (transform.forward + new Vector3(0,Mathf.PI,0))* light.range);
        //Debug.Log(Vector3.Angle(transform.forward, target.transform.position - transform.position));

        for(int i = 0; i < BadGuy.badGuys.Count; i++ )//BadGuy b in BadGuy.badGuys)
        {
            BadGuy b = BadGuy.badGuys[i];
            float dmg = GetDamage(b);

                if (((BadGuy)b.GetComponent<BadGuy>()).damage(dmg)) //If died b/c of dmg
                {
                    BadGuy.badGuys.Remove(b);
                    i--;
                }

        }
      


	}

    public float GetDamage(BadGuy b)
    {
        if (Vector3.Angle(transform.forward, b.transform.position - transform.position) < light.spotAngle)
        {
            float dist =  Vector3.Distance(light.transform.position, b.transform.position);
            if (dist > light.range) return 0f;

            return light.intensity * Time.deltaTime * ((light.range - dist) / light.range) * 5f;
            
        }
        return 0f;

    }

}
