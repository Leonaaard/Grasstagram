using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerationV3 : MonoBehaviour {

    public GameObject layer;
    public int plantMaxHeight;
    public float instanceSize;

    void Start () {
		
        for(int i = 0; i < plantMaxHeight; i++)
        {

            // Random Position   
            Vector3 instancePosition = new Vector3(
                transform.position.x,
                transform.position.y + i/30f,
                transform.position.z
            );

            // Création de la couche
            GameObject instanceLayer = Instantiate(layer, instancePosition, Quaternion.identity);
            instanceLayer.transform.SetParent(transform);

            // Size
            instanceLayer.transform.localScale = new Vector3 (instanceSize, 1, instanceSize);

            // Changer le Cutout
            //float cutoutValue = 0.8f + (i / 100f);
            float divider = i / 128f;
            float cutoutValue = Mathf.Lerp(0.85f, 1f, divider);
            instanceLayer.GetComponent<Renderer>().material.SetFloat("_Cutoff", cutoutValue);

        }

	}
	
	void Update () {
        
	}
}
