using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerationV2 : MonoBehaviour {

    [Header("Général")]
    public float fieldArea;

    [Header("Grass")]
    public GameObject grass;
    public int grassCount;

    [Header("Bush")]
    public GameObject bush;
    public int bushCount;

    [Header("Wheat")]
    public GameObject wheat;
    public int wheatCount;

    void Start () {

        GrassGeneration();
        BushGeneration();
        WheatGeneration();

	}
	
	void GrassGeneration () {
        for (int i = 0; i < grassCount; i++)
        {

            // Random Position   
            Vector3 instancePosition = new Vector3(
                transform.position.x + Random.Range(-fieldArea, fieldArea),
                transform.position.y,
                transform.position.z + Random.Range(-fieldArea, fieldArea)
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

    void BushGeneration()
    {
        for (int i = 0; i < bushCount; i++)
        {

            // Random Position   
            Vector3 instancePosition = new Vector3(
                transform.position.x + Random.Range(-fieldArea, fieldArea),
                transform.position.y,
                transform.position.z + Random.Range(-fieldArea, fieldArea)
            );

            // Création de la plante + parent
            GameObject instanceBush = Instantiate(bush, instancePosition, Quaternion.identity);
            instanceBush.transform.SetParent(transform);

            // Random Size
            float instanceSizeX = Random.Range(0.5f, 1.2f);
            Vector3 instanceSize = new Vector3(
                instanceSizeX,
                instanceSizeX,
                instanceSizeX
            );
            instanceBush.transform.localScale = instanceSize;

            // RandomColor
            SpriteRenderer[] sprites = instanceBush.GetComponentsInChildren<SpriteRenderer>();

            for (int j = 0; j < sprites.Length; j++)
            {
                Color bushColor = new Color(0f, Random.Range(0.55f, 0.6f), 0.1f, 1f);
                sprites[j].color = bushColor;
            }

        }
    }

    void WheatGeneration()
    {
        for (int i = 0; i < wheatCount; i++)
        {

            // Random Position + Size
            Vector3 instancePosition = new Vector3(
                transform.position.x + Random.Range(-fieldArea, fieldArea),
                transform.position.y + Random.Range(-1,1),
                transform.position.z + Random.Range(-fieldArea, fieldArea)
            );

            // Création de la plante + parent
            GameObject instanceWheat = Instantiate(wheat, instancePosition, Quaternion.identity);
            instanceWheat.transform.SetParent(transform);

            // RandomColor
            Color wheatColor = new Color(Random.Range(0.9f, 1f), Random.Range(0.9f, 1f), Random.Range(0.9f, 1f), 1f);
            instanceWheat.GetComponentInChildren<SpriteRenderer>().color = wheatColor;

        }
    }

}
