using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerV2 : MonoBehaviour {

    private GameObject player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	void Update () {
        Vector3 target = new Vector3(
            player.transform.position.x,
            transform.position.y,
            player.transform.position.z
        );
        transform.LookAt(target);
    }
}
