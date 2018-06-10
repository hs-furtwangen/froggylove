using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassArray : MonoBehaviour {

    public int CountX;

    public int CountZ;

    public GameObject GrassObject;

    void OnValidate () {

        Apply();
	}

    private void Apply()
    {
        if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
            return;

        if (GrassObject == null)
            return;

        Renderer renderer = GrassObject.GetComponent<Renderer>();

        if(renderer != null)
        {
                foreach(Transform t in transform)
            {
                UnityEditor.EditorApplication.delayCall += () =>
                {
                    DestroyImmediate(t.gameObject);
                };
            }

        }
        float lastX = 0;
        float lastZ = 0;

        for (int i=0; i < CountX; i++ )
        {
                for (int j = 0; j < CountZ; j++)
                {
                    Vector3 pos = new Vector3(lastX + transform.localPosition.x, lastZ + transform.localPosition.z, transform.localPosition.y);
                    GameObject go = Instantiate(GrassObject, pos, Quaternion.identity, transform) as GameObject;
                    go.name = GrassObject.name + "_" + i + "_" + j;
                    lastX -= renderer.bounds.size.x;
                }
                lastX = transform.localPosition.x;

                lastZ -= renderer.bounds.size.z;
            
        }
    }
  
}
