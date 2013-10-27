using UnityEngine;
using System.Collections;

public class GUIBinding : MonoBehaviour {

    public Bindings.Key key = Bindings.Key.Menu;

	void Update ()
	{
		if (!UICamera.inputHasFocus)
		{
            if (Bindings.Key.Menu == key) return;
			
			if (Input.GetKeyDown(Bindings.Get(key)))
			{
				SendMessage("OnPress", true, SendMessageOptions.DontRequireReceiver);
                SendMessage("OnHover", true, SendMessageOptions.DontRequireReceiver);
			}

			if (Input.GetKeyUp(Bindings.Get(key)))
			{
				SendMessage("OnPress", false, SendMessageOptions.DontRequireReceiver);
				SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
