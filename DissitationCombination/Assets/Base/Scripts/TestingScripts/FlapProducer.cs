using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlapProducer : MonoBehaviour {

    public GameObject capsuleOne;
    public GameObject moverOne;


    public GameObject capsuleTwo;
    public GameObject moverTwo;


    // Use this for initialization
    void Start () {
	
	}
	
    public void bindControl()
    {
        print("Tock");
        capsuleTwo.transform.SetParent(capsuleOne.transform);
        moverTwo.transform.SetParent(capsuleOne.transform);
       

    }
}
