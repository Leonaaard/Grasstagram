using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGeneration : MonoBehaviour {

    public GameObject plant;

    public float plantHeight;
    public float plantHeightRandomisation;

    public float plantQuantity;
    public float grassSize;

	void Start () {

        // Référence au script GameManager
        GameObject gameManager = GameObject.FindWithTag("GameManager");
        GameManager gameManagerScript = gameManager.GetComponent<GameManager>();

        for (int i = 0; i < plantQuantity; i++)
        {

            // Position de la plante + surface de l'herbe
            Vector3 instancePosition = new Vector3(
                transform.position.x + Random.Range(-grassSize, grassSize),
                transform.position.y,
                transform.position.x + Random.Range(-grassSize, grassSize)
            );

            // Création de la plante
            GameObject instancePlant = Instantiate(plant, instancePosition, Quaternion.identity);
            instancePlant.transform.SetParent(transform);


            // Délai d'apparition entre chaque feuille
            //yield return new WaitForSeconds(gameManagerScript.plantGenerationSpeed);
        }

    }

    void Update () {
		
	}
}
