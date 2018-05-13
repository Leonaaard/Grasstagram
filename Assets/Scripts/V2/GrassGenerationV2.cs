using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerationV2 : MonoBehaviour {

    public GameObject grass;

    public int grassCount;
    public float grassArea;

	void Start () {
		
        for (int i = 0; i < grassCount; i++)
        {

            // Random Position   
            Vector3 instancePosition = new Vector3(
                transform.position.x + Random.Range(-grassArea, grassArea),
                transform.position.y,
                transform.position.z + Random.Range(-grassArea, grassArea)
            );

            // Création de la plante + parent
            GameObject instanceGrass = Instantiate(grass, instancePosition, Quaternion.identity);
            instanceGrass.transform.SetParent(transform);

            // Random Size
            float instanceSizeX = Random.Range(1, 2);
            Vector3 instanceSize = new Vector3(
                instanceSizeX,
                instanceSizeX,
                1
            );
            instanceGrass.transform.localScale = instanceSize;

            // RandomColor
            Color grassColor = new Color(0f, Random.Range(0.6f, 0.7f), Random.Range(0.2f, 0.3f), 1f);
            instanceGrass.GetComponentInChildren<SpriteRenderer>().color = grassColor;

        }

	}
	
	void Update () {
		
	}
}
