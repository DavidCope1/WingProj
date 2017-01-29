using UnityEngine;
using System.Collections;

public class simpleRoter : MonoBehaviour {

    private Transform pairent;
    public Transform extraRotation;
    // Use this for initialization
    void Awake () {
        pairent = gameObject.transform.parent;
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = pairent.rotation * extraRotation.rotation;


    }
}
