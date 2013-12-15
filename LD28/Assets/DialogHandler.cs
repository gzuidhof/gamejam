using UnityEngine;
using System.Collections;

public class DialogHandler : MonoBehaviour {

    public GameObject dialog1;
    public static int roomCount;
    public bool dialogEnabled = true;

    public void StartDialog1()
    {
        dialog1.SetActive(true);
    }

	// Use this for initialization
	void Start () {
        if (dialogEnabled)
            OnRoom();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnRoom()
    {
        roomCount++;
        Debug.Log("this is roomcount" + roomCount);
        if (roomCount == 1)
        {
            StartDialog1();
        }
    }
}
