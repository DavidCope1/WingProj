using UnityEngine;
using System.Collections;

public class MeshManipulator : MonoBehaviour {

    public Camera cameraIn;

    public GameObject camPosOneTesting;
    public GameObject camPosTwoTesting;
    public GameObject camPosThreeTesting;

    bool updated = false;
    bool selected = false;
    private GameObject currentSelect;
    public Material setCol;
    Material matHold;

    public bool getUpdated()
    {
        return updated;
    }

    void Update()
    {

        RaycastHit hit;
        Ray ray = cameraIn.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(ray.origin, ray.direction);

            if (Input.GetMouseButtonDown(0) && (hit.transform.tag == "MOVABLE"))
            {
                if (!selected)
                {
                    currentSelect = hit.transform.gameObject;
                    matHold = currentSelect.GetComponent<Renderer>().material;
                    currentSelect.GetComponent<Renderer>().material = setCol;
                    selected = true;

                }
                else
                {
                    currentSelect.GetComponent<Renderer>().material = matHold;
                    currentSelect = null;
                    selected = false;
                    updated = true;

                }


            }
            if (Input.GetKey(KeyCode.U))
            {
                cameraIn.transform.position = camPosOneTesting.transform.position;
                cameraIn.transform.rotation = camPosOneTesting.transform.rotation;
            }
            if (Input.GetKey(KeyCode.I))
            {
                cameraIn.transform.position = camPosTwoTesting.transform.position;
                cameraIn.transform.rotation = camPosTwoTesting.transform.rotation;
            }
            if (Input.GetKey(KeyCode.O))
            {
                cameraIn.transform.position = camPosThreeTesting.transform.position;
                cameraIn.transform.rotation = camPosThreeTesting.transform.rotation;
            }


            if (selected)
            {
                currentSelect.transform.position = new Vector3(hit.point.x, 0, hit.point.z);

            }



        }



    }
}
