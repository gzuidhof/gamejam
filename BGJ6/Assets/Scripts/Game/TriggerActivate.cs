using UnityEngine;
using System.Collections;

public class TriggerActivate : MonoBehaviour {

    public GameObject target;
    public string feedback;

    public bool theEnd;


    void OnTriggerEnter(Collider c)
    {
        if (!gameObject) return;
        //if (c.rigidbody)
        //{
        if (c.transform.root.tag == "Player")
        {
            if (!target.activeSelf)
            {
                target.SetActive(true);

                if (target.GetComponent<UIButton>()) {
                target.GetComponent<UIButton>().SendMessage("OnHover", true, SendMessageOptions.DontRequireReceiver);
                target.GetComponent<UIButton>().SendMessage("OnPress", true, SendMessageOptions.DontRequireReceiver);

                }
                if (!string.IsNullOrEmpty(feedback))
                {
                    Debug.Log("Sending user feedback");
                    
                    GUIFeedback.instance.ShowText(feedback, theEnd ? 20f: 5f);
                }

                Destroy(gameObject);
            }
        }
        //}

    }
}
