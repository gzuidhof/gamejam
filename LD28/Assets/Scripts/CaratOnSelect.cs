using UnityEngine;
using System.Collections;

public class CaratOnSelect : MonoBehaviour {

    private UIButton button;
    private UILabel label;

	// Use this for initialization
	void Start () {
        button = GetComponent<UIButton>();
        label = GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
        if (UICamera.selectedObject == gameObject || UICamera.selectedObject == label)
        {
            if (!label.text.StartsWith(">"))
            {
                label.text = ">" + label.text;
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
