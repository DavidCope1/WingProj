using UnityEngine;
using System.Collections;

public class ClothInteraction5000 : MonoBehaviour {

    public GameObject ClothObj;
    Cloth clothItem;
    ClothSkinningCoefficient[] newConstraints;
    bool invert = false;

    // Update is called once per frame
    void Awake ()
    {
        clothItem = ClothObj.GetComponent<Cloth>();
 	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            if (invert)
            {
                Testing(0);
            }
            else
            {
                Testing(500);
            }
        }
    }

    void Testing(int _in)
    {
       
        newConstraints = clothItem.coefficients;
        newConstraints[5].maxDistance = _in;
        clothItem.coefficients = newConstraints;
        invert = !invert;

    }
    
}
