using UnityEngine;
using System.Collections;

public class SimpleLookAt : MonoBehaviour {

    public Transform objToObserve;
    


	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(objToObserve);
	}
}
