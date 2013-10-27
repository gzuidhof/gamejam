using UnityEngine;
using System.Collections;

public class GUIFeedback : MonoBehaviour {

    public static GUIFeedback instance;

    public UITweener alpha;
    public UILabel label;

	// Use this for initialization
	void Start () {
        instance = this;
        label = this.GetComponent<UILabel>();

	}

    public void ShowText(string s)
    {
        Debug.Log("Showing text");
        alpha.Play(true);
        label.text = s;
        Invoke("HideText", 5f);
    }

    public void HideText()
    {
        alpha.Play(false);
    }

	
}
