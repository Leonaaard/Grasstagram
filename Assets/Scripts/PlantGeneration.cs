using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGeneration : MonoBehaviour {

    public GameObject gameManager;

    public GameObject leaf;

    public float plantHeight;


	IEnumerator Start () {

        GameManager gameManagerScript = gameManager.GetComponent<GameManager>();

        for (int i = 0; i < plantHeight; i++)
        {

            GameObject instanceLeaf = Instantiate(leaf, new Vector3(0, 0, 0), Quaternion.Euler(-90,0,0));
            instanceLeaf.transform.SetParent(transform);

            yield return new WaitForSeconds(gameManagerScript.generationSpeed);

        }

	}
	
	void Update () {
		
	}
}
