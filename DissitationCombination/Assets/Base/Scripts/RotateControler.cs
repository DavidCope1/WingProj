using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RotateControler : MonoBehaviour {

    public Slider timeVal;
    public int rotVal;
    public int rotValfrac;

    void Awake()
    {
        rotValfrac = rotVal / 100;
    }

    void Update()
    {
        //transform.LookAt()
    }

}
