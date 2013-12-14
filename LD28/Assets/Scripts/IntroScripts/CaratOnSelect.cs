using UnityEngine;
using System.Collections;

public class CaratOnSelect : MonoBehaviour {

    private UILabel label;
    public AudioClip sound;

	// Use this for initialization
	void Start () {
        label = GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
        if (UICamera.selectedObject == gameObject)
        {
            if (!label.text.StartsWith(">"))
            {
                label.text = ">" + label.text;
                audio.PlayOneShot(sound);
            }
        }
        else
        {
            if (label.text.StartsWith(">"))
            {
                label.text = label.text.Substring(1);
            }
        }
	}
}
