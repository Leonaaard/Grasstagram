using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGeneration : MonoBehaviour {

    public GameObject trunkBaseInstantiated;
    public float treeSize;
    public float treeWidthStart = 20f;

    private float startTime;
    private float speed;
    private Vector3 originalScale;
    private Vector3 targetScale;

    IEnumerator Start(){

        for (int i = 0; i<treeSize; i++)
        {

            startTime = Time.time;

            Color colorRandom = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);

            GameObject trunk = Instantiate(trunkBaseInstantiated, new Vector3 (this.transform.position.x, (i + 0.1f), this.transform.position.z), Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0, 360f)));

            targetScale = new Vector3(20f - i / 5f, 20f - i / 5f, 20f - i / 5f);

            Vector3 originalScale = new Vector3(0, 0, 0);
            speed = (Time.time - startTime) * 5f;
            trunk.transform.localScale = Vector3.Lerp(originalScale, targetScale, speed);

            GameObject pixel1 = trunk.transform.GetChild(0).gameObject;
            pixel1.GetComponent<SpriteRenderer>().color = colorRandom;
            GameObject pixel2 = trunk.transform.GetChild(1).gameObject;
            pixel2.GetComponent<SpriteRenderer>().color = colorRandom;
            GameObject pixel3 = trunk.transform.GetChild(2).gameObject;
            pixel3.GetComponent<SpriteRenderer>().color = colorRandom;
            trunk.transform.SetParent(this.transform);

            yield return new WaitForSeconds(0.05f);
        }

	}
	
	void Update () {
        Debug.Log("voxel" + targetScale);
        Debug.Log("speed" + speed);
	}
}
