using UnityEngine;
using System.Collections;
using UnityEditor;

public class MeshSaver : MonoBehaviour {

    public Mesh inMesh;
    bool doOnce = true;
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.B))

            if (doOnce)
            {
                inMesh = GameObject.Find("wingMesh").GetComponent<MeshFilter>().mesh;
                AssetDatabase.CreateAsset(inMesh, "Assets/MESH.obj");
                AssetDatabase.SaveAssets();

                doOnce = false;
            }
     
	}
}
