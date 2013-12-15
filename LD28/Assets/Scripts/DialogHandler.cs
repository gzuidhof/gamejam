using UnityEngine;
using System.Collections;

public class DialogHandler : MonoBehaviour {

    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;
    public bool forceDialog2;
    public bool forceDialog3;

    public GameObject[] enableOnDialog1;
    public GameObject[] enableOnDialog2;
    public GameObject[] enableOnDialog3;



    public static int roomCount;
    public bool dialogEnabled = true;

    public void StartDialog1()
    {
        foreach (GameObject go in enableOnDialog1)
        {
            go.SetActive(true);
        }
        dialog1.SetActive(true);
    }

    public void StartDialog2()
    {
        foreach (GameObject go in enableOnDialog2)
        {
            go.SetActive(true);
        }
        dialog2.SetActive(true);
    }

    public void StartDialog3()
    {
        foreach(GameObject go in enableOnDialog3) {
            go.SetActive(true);
        }
        dialog3.SetActive(true);
    }

    

	// Use this for initialization
	void Start () {
        if (dialogEnabled)
            OnRoom();
        if (forceDialog2)
            StartDialog2();
        if (forceDialog3)
            StartDialog3();
	}


    void OnRoom()
    {
        roomCount++;
        Debug.Log("This is Room Count" + roomCount);
        if (roomCount == 1)
        {
            StartDialog1();
        }
        else if (roomCount == 2)
        {
            StartDialog2();
        }
        else if (roomCount == 3)
        {
            StartDialog3();
        }
    }
}
