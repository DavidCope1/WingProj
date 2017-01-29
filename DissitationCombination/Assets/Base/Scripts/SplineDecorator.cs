using UnityEngine;
using System.Collections.Generic;

public class SplineDecorator : MonoBehaviour
{
    public float testVal;


    public BezierSpline spline;
    private Vector3[] splinePoints;
    public int frequency;
    public bool lookForward;
    public GameObject[] items;
    GameObject item;
    private List<GameObject> vertexPoints = null;
    private List<GameObject> controlPoints;
    MeshManipulator meshMap;

    public List<Transform> controlNodes;
    


    private MeshMaker shapeHold;

    void Awake()
    {

        spline = GetComponent<BezierSpline>();
        controlPoints = new List<GameObject>();
        shapeHold = GameObject.Find("ScriptHolder").GetComponent<MeshMaker>();
        shapeHold.Begin();
        items[0] = shapeHold.pointPrefab;


        vertexPoints = new List<GameObject>();
        splinePoints = new Vector3[spline.points.Length];
        meshMap = GetComponent<MeshManipulator>();
        identPos();
         runCreation();
        setControlObje();
    }

    void setControlObje()
    {
        int counter = 0;
        int nodeCounter = 0;
        foreach (Vector3 Vec in spline.points)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.tag = "MOVABLE";
            go.transform.position = Vec;
            controlPoints.Add(go);
            go.transform.parent = controlNodes[nodeCounter];
            go.GetComponent<Renderer>().material.color = Color.green;

            counter++;
            if ((counter == 3)&&(nodeCounter != 2))
            {
                counter = 0;
                nodeCounter++;
            }
            
        }
    }


    void identPos()
    {
        int cout = 0;
        foreach (Vector3 vec in spline.points)
        {
            splinePoints[cout++] = vec;
        }
    }

    bool testChange()
    {

        if (testIdet() == true || testShape() == true)
        {
            return true;
        }
        return false;
    }

    bool testIdet()
    {

        for (int i = 0; i < spline.points.Length; i++)
        {
            if (spline.points[i] != splinePoints[i])
            {
                identPos();
                vertexPoints.Clear();
                vertexPoints.TrimExcess();
                return true;
            }
        }
        return false;
    }

    bool testShape()
    {
        print(meshMap.getUpdated());
        return meshMap.getUpdated();

    }

    void movNode()
    {
        for (int i = 0; i < spline.points.Length; i++)
        {
            spline.points[i] = controlPoints[i].transform.position;
        }
    }

    private void Update()
    {
        movNode();
        if (testIdet())
        {
            runCreation();

        }

    }

    void runCreation()
    {
        if (frequency <= 0 || items == null || items.Length == 0)
        {
            return;
        }
        float testValForEnd = 0;
        float stepSize = 1f / (frequency * items.Length);
        for (int p = 0, f = 0; f < frequency; f++)
        {
            for (int i = 0; i < items.Length; i++, p++)
            {

               item = Instantiate(items[0]) as GameObject;

                

                vertexPoints.Add(item);
                vertexPoints[i].transform.localScale += new Vector3(testVal, 0, 0);

                if (f == frequency - 2)
                {
                    testValForEnd = 1.5f;
                }
                else if (f == frequency - 1)
                {
                    testValForEnd = testValForEnd * 2;
                }

                    Transform tr = item.transform.GetChild(3).transform;

                tr.position = tr.localPosition = new Vector3((testVal + (p / 10) - testValForEnd), (tr.position.y), (tr.position.z));

                tr = item.transform.GetChild(4).transform;



               tr.position = tr.localPosition = new Vector3((testVal+(p/10)- testValForEnd), (tr.position.y),(tr.position.z ));
                Destroy(item);



                Vector3 position = spline.GetPoint(p * stepSize);
                item.transform.localPosition = position;
                if (lookForward)
                {
                    item.transform.LookAt(position + spline.GetDirection(p * stepSize));
                }
                item.transform.parent = transform;
            }
            foreach (Transform child in item.transform)
            {
                // child.transform.position += new Vector3(5.0f, 0f, 0f);


                vertexPoints.Add(child.gameObject);
                 Destroy(child.gameObject);
            }




        }

        shapeHold.createMesh();
      //  flapHold.bindControl();
    }





    public List<GameObject> getPointList()
    {
        return vertexPoints;
    }


}


/*
	public BezierSpline spline;

	public int frequency;

	public bool lookForward;

	public Transform[] items;

	private void Awake () {
		if (frequency <= 0 || items == null || items.Length == 0) {
			return;
		}
		float stepSize = frequency * items.Length;
		if (spline.Loop || stepSize == 1) {
			stepSize = 1f / stepSize;
		}
		else {
			stepSize = 1f / (stepSize - 1);
		}
		for (int p = 0, f = 0; f < frequency; f++) {
			for (int i = 0; i < items.Length; i++, p++) {
				Transform item = Instantiate(items[i]) as Transform;
				Vector3 position = spline.GetPoint(p * stepSize);
				item.transform.localPosition = position;
				if (lookForward) {
					item.transform.LookAt(position + spline.GetDirection(p * stepSize));
				}
				item.transform.parent = transform;
			}
		}
	}*/
