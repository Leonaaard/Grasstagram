using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGeneration : MonoBehaviour {

    public GameObject leaf;

	void Start () {

        // Référence au script Parent
        GrassGeneration parent = transform.GetComponentInParent<GrassGeneration>();

        // Orientation de la plante
        float plantOrientation = Random.Range(0f, 180f);

        // Taille de la plante aléatoire
        float plantRandomHeight = parent.plantHeight + Random.Range(0, parent.plantHeightRandomisation);

        // Couleur de la plante aléatoire
        Color leafColor = new Color(0f, Random.Range(0.6f, 0.7f), Random.Range(0.2f, 0.3f), 1f);

        for (int i = 0; i < plantRandomHeight; i++)
        {

            // Décalage vertical entre chaque feuille
            Vector3 instancePosition = new Vector3(
                transform.position.x,
                transform.position.y + (i*  0.05f) + 0.01f,
                transform.position.z
                );

            // Réduction de la taille à chaque feuille
            Vector3 instanceSize = new Vector3(
				parent.plantWidth,
                parent.plantWidth,
                1f
                );

            // Création de la feuille
            GameObject instanceLeaf = Instantiate(leaf, instancePosition, Quaternion.Euler(90,plantOrientation,0));
            instanceLeaf.transform.SetParent(transform);

            // Taille de la feuille
            instanceLeaf.transform.localScale = instanceSize;

            // Colorisation de la feuille
            instanceLeaf.GetComponent<SpriteRenderer>().color = leafColor;

        }

	}
	
	void Update () {
		
	}
}
