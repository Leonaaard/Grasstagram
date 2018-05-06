using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGeneration : MonoBehaviour {

    public GameObject leaf;

    void Start()
    {

        // Référence au script GameManager
        GameObject gameManager = GameObject.FindWithTag("GameManager");
        GameManager gameManagerScript = gameManager.GetComponent<GameManager>();

        // Référence au script Parent
        GrassGeneration parent = transform.GetComponentInParent<GrassGeneration>();

        // Orientation de la plante
        float plantOrientation = Random.Range(0f, 180f);

        // Taille de la plante aléatoire
        float plantRandomHeight = parent.plantHeight + Random.Range(0, parent.plantHeightRandomisation);

        // Couleur de la plante aléatoire
        Color leafColor = new Color(0f, Random.Range(0.55f, 0.65f), Random.Range(0.15f, 0.25f), 1f);
        Color petalsColor = new Color(Random.Range(0.8f, 1f), Random.Range(0.8f, 1f), 0f, 1f);

        for (int i = 0; i < plantRandomHeight; i++)
        {

            if (i < (plantRandomHeight / 6)*5)
            {

                // Décalage vertical entre chaque feuille
                Vector3 instancePosition = new Vector3(
                    transform.position.x,
                    transform.position.y + (i * 0.07f) + 0.01f,
                    transform.position.z
                    );

                // Réduction de la taille à chaque feuille
                Vector3 instanceSize = new Vector3(
                    parent.plantWidth,
                    parent.plantWidth,
                    1f
                    );

                // Création de la feuille
                GameObject instanceLeaf = Instantiate(leaf, instancePosition, Quaternion.Euler(90, plantOrientation, 0));
                instanceLeaf.transform.SetParent(transform);

                // Taille de la feuille
                instanceLeaf.transform.localScale = instanceSize;

                // Colorisation de la feuille
                instanceLeaf.GetComponent<SpriteRenderer>().color = leafColor;

            }
            else
            {

                // Décalage vertical entre chaque feuille
                Vector3 instancePosition = new Vector3(
                    transform.position.x,
                    transform.position.y + (i * 0.07f) + 0.01f,
                    transform.position.z
                    );

                // Réduction de la taille à chaque feuille
                Vector3 instanceSize = new Vector3(
                    parent.plantWidth*1.2f,
                    parent.plantWidth*1.2f,
                    1f
                    );

                // Création de la feuille
                GameObject instanceLeaf = Instantiate(leaf, instancePosition, Quaternion.Euler(90, plantOrientation, 0));
                instanceLeaf.transform.SetParent(transform);

                // Taille de la feuille
                instanceLeaf.transform.localScale = instanceSize;

                // Colorisation de la feuille
                instanceLeaf.GetComponent<SpriteRenderer>().color = petalsColor;

            }

        }

    }

    void Update()
    {

    }
}
