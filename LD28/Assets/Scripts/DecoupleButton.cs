using UnityEngine;
using System.Collections;

public class DecoupleButton : MonoBehaviour {

    public Decoupler[] decouplers;
    public GameObject toDisablePartEffectOn;
    public static bool decoupled = false;
    public AudioClip decoupleDeniedSound;

    public void Start()
    {
        decoupled = false;
    }

    public void OnButton()
    {
        if (!decoupled)
        {
            decoupled = true;
            foreach (Decoupler d in decouplers)
            {
                d.Decouple();
            }
            toDisablePartEffectOn.GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            audio.PlayOneShot(decoupleDeniedSound);
        }
    }


}
