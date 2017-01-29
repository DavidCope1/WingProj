using UnityEngine;
using System.Collections;

public class simpleRoter1 : MonoBehaviour {

    private Transform pairent;
    public Transform extraRotation;
    public bool dir;
    // Use this for initialization
    void Awake () {
        pairent = gameObject.transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
        if (dir)
        {
            transform.rotation = pairent.rotation * extraRotation.rotation;
        }
        else
        {
            transform.rotation = Quaternion.Inverse(pairent.rotation) * extraRotation.rotation;
        }

    }
}
