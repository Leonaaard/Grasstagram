﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGeneration : MonoBehaviour {

    public GameObject plant;

    public float plantHeight;
    public float plantHeightRandomisation;
	public float plantWidth;

    public float grassArea;
	public float grassDensity;

	void Start () {

		for (int i = 0; i < grassArea*grassDensity; i++)
        {

            // Position de la plante + surface de l'herbe
            Vector3 instancePosition = new Vector3(
				transform.position.x + Random.Range(-grassArea, grassArea),
                transform.position.y,
				transform.position.x + Random.Range(-grassArea, grassArea)
            );

            // Création de la plante
            GameObject instancePlant = Instantiate(plant, instancePosition, Quaternion.identity);
            instancePlant.transform.SetParent(transform);
            
        }

    }

    void Update () {
		
	}
}
