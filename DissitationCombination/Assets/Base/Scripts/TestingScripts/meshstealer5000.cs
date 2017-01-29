using UnityEngine;
using System.Collections;
using System.Linq;

public class meshstealer5000 : MonoBehaviour {


    public BoneExample BE; 
    public MeshMaker ME;
    //private Vector3[] verts;
	// Use this for initialization
	void Start () {
        gameObject.AddComponent<MeshFilter>();
        //gameObject.AddComponent<MeshRenderer>();

        //GetComponent<MeshRenderer>().material = ME._inMat;

	}
	


    public Mesh getMesh()
    {
       
        return GetComponent<MeshFilter>().mesh;
    }
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.K))
        {
            Mesh mesh = ME.getModel();
            mesh.triangles = mesh.triangles.Reverse().ToArray();

            GetComponent<MeshFilter>().mesh = mesh;

            GetComponent<SkinnedMeshRenderer>().sharedMesh = mesh;
            //BE.makeBonesGO();
        }

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    verts = GetComponent<MeshFilter>().mesh.vertices;
        //}


    }
}
