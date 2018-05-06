using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
        transform.Rotate(Vector3.right * Time.deltaTime*-5);
    }
}
