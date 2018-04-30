using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGeneration : MonoBehaviour {

    public GameObject gameManager;

    public GameObject plant;

    public float plantQuantity;

	IEnumerator Start () {

        // Référence au script GameManager
        GameManager gameManagerScript = gameManager.GetComponent<GameManager>();

        for (int i = 0; i < plantQuantity; i++)
        {

            // Position de la plante
            Vector3 instancePosition = new Vector3(
                transform.position.x + i,
                transform.position.y,
                transform.position.z
                );

            // Création de la plante
            GameObject instancePlant = Instantiate(plant, transform.position, Quaternion.identity);
            instancePlant.transform.SetParent(transform);


            // Délai d'apparition entre chaque feuille
            yield return new WaitForSeconds(gameManagerScript.plantGenerationSpeed);
        }

    }

    void Update () {
		
	}
}
