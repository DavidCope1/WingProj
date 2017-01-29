using UnityEngine;
using System.Collections;

public class VertexColour : MonoBehaviour {

	// Use this for initialization
	public void MakeColour(Mesh _in)
    {

     
        Vector3[] verts = _in.vertices;
        // create new colors array where the colors will be created.
        Color[] colors = new Color[verts.Length];

        for (int i = 0; i < verts.Length; i++)
            colors[i] = Color.Lerp(Color.red, Color.green, verts[i].y);

        // assign the array of colors to the Mesh.
        _in.colors = colors;
    }
	

}
