using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flashlight : MonoBehaviour {

    private Light light;
    private GameObject player;

    public static List<Flashlight> lights = new List<Flashlight>();



    public bool on = true;

    public AudioClip alarmSound;

    public bool spin = false;
    public Vector3 spinAxis = new Vector3(0, 1, 0);
    public float spinSpeed = 5f;
    public float spinAngle = 45f;
    private float currentSpin = 0f;
    private bool spinDir = true;



	// Use this for initialization
	void Start () {
        light = (Light) GetComponentInChildren<Light>();
        player = GameObject.FindGameObjectWithTag("Player");
        lights.Add(this);
        if (!on) light.enabled = false;
	}

    public void Toggle(bool set)
    {

        if (set)
        {
            light.enabled = true;
            on = true;
        }
        else
        {
            light.enabled = false;
            on = false;
        }
    }


    public void ToggleLight()
    {
        if (on)
        {
            Toggle(false);
        }
        else
        {
            Toggle(true);
        }
    }


    

    void SpinFlashlight()
    {
        
        if (spinDir && currentSpin > spinAngle) {
            spinDir = false;
        }
        else if (!spinDir && currentSpin < -spinAngle) {
            spinDir = true;
        }

        if (spinDir)
        {
            transform.Rotate(spinAxis * Time.deltaTime * spinSpeed);
            currentSpin += Time.deltaTime * spinSpeed;
        }
        else
        {
            transform.Rotate(-spinAxis * Time.deltaTime * spinSpeed);
            currentSpin -= Time.deltaTime * spinSpeed;
        }
        
    }



    public static float alarmAmount;
	// Update is called once per frame
	void Update () {
        if (on) CheckForPlayer();
        if (spin && on) SpinFlashlight();

	}

    private float checkTime = 0f;

    //Checks for player with a ton of raycasts and plays a sound when in alarm light.
    //also increases alarm level.
    public void CheckForPlayer()
    {
        alarmAmount = 0;
        checkTime += Time.deltaTime;

        if (checkTime > 0.13f) //Checking at max every 0.18 sec
        {
            checkTime = 0f;
        }
        else
            return;

        //Is within a reasonable angle with the light and within range, else return.
        if ( ! (Vector3.Angle(transform.forward, player.transform.position - transform.position) < light.spotAngle / 1.5f 
            && Vector3.Distance(light.transform.position, player.transform.position) < light.range))
        {
            return;
        }


        for (float f = 0.15f; f <= 0.85f; f += 0.05f) //horizontal
        {
            for (float f2 = 0.15f; f2 <= 0.85f; f2 += 0.05f) //vertical
            {
                Vector3 dir = (light.transform.forward + GetHorizontalSliceVector(light.spotAngle, f) + GetVerticalSliceVector(light.spotAngle, f2)) * light.range * 0.8f;

                if (Vector3.Angle(light.transform.forward, dir) < light.spotAngle / 2f)
                {
                   // Debug.DrawRay(light.transform.position, dir);
                    Ray r = new Ray(light.transform.position, dir);
                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(r, out hit))
                    {
                        if (hit.rigidbody && hit.transform.tag == "Player")
                        {
                            alarmAmount++;
                            if (alarmAmount < 2) //Only 1 hit per light allowed, why didn't I use a boolean? :/
                            {
                                AudioSource.PlayClipAtPoint(alarmSound, transform.position);
                                GameManager.instance.RaiseAlarm();
                            }
                            //Debug.Log(hit.rigidbody.name);
                        }
                    }
                }

            }
        }
    }










        /* LEGACY code, to hurt bad guys.
    for(int i = 0; i < BadGuy.badGuys.Count; i++ )//BadGuy b in BadGuy.badGuys)
    {
        BadGuy b = BadGuy.badGuys[i];
        float dmg = GetAngleDamage(b);

            if (((BadGuy)b.GetComponent<BadGuy>()).damage(dmg)) //If died b/c of dmg
            {
                BadGuy.badGuys.Remove(b);
                i--;
            }

    }*/



   
    //Note, should be called between 0.1 and 0.9 if not a HUGE light
    public Vector3 GetHorizontalSliceVector(float totalwidth, float portion)
    {
       // return //portion*-transform.right + portion * (1f-portion)*transform.right;
        return (portion * 2f - 1f) * (light.transform.right).normalized * (totalwidth / 90f);
    }

    public Vector3 GetVerticalSliceVector(float totalwidth, float portion)
    {
        // return //portion*-transform.right + portion * (1f-portion)*transform.right;
        return (portion * 2f - 1f) * (light.transform.up).normalized * (totalwidth / 90f);
    }


    public float GetAngleDamage(BadGuy b) //Angle Damage
    {
        if (Vector3.Angle(transform.forward, b.transform.position - transform.position) < light.spotAngle/2f)
        {
            float dist =  Vector3.Distance(light.transform.position, b.transform.position);
            if (dist > light.range) return 0f;

            return light.intensity * Time.deltaTime * ((light.range - dist) / light.range) * 5f;
            
        }
        return 0f;

    }

}
