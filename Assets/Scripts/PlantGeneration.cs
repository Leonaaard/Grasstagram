using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGeneration : MonoBehaviour {

    public GameObject gameManager;

    public GameObject leaf;

    public float plantHeight;


	IEnumerator Start () {

        // Référence au script GameManager
        GameManager gameManagerScript = gameManager.GetComponent<GameManager>();

        // Taille de la plante aléatoire
        float plantRandomHeight = plantHeight + Random.Range(0, 60);

        // Couleur de la plante aléatoire
        Color leafColor = new Color(0f, Random.Range(0.4f, 0.7f), Random.Range(0f, 0.3f), 1f);

        for (int i = 0; i < plantRandomHeight; i++)
        {

            // Décalage vertical entre chaque feuille
            Vector3 instancePosition = new Vector3(
                transform.position.x,
                transform.position.y + (i/10),
                transform.position.z
                );

            // Création de la feuille
            GameObject instanceLeaf = Instantiate(leaf, instancePosition, Quaternion.Euler(-90,0,0));
            instanceLeaf.transform.SetParent(transform);

            // Colorisation de la feuille
            instanceLeaf.GetComponent<SpriteRenderer>().color = leafColor;

            // Délai d'apparition entre chaque feuille
            yield return new WaitForSeconds(gameManagerScript.leafGenerationSpeed);

        }

	}
	
	void Update () {
		
	}
}
