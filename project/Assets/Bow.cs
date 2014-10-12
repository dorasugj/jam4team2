using UnityEngine;
using System.Collections;

public class Bow : MonoBehaviour {

    public GameObject arrowOriginal;

	void Start () {
	
	}
	
	void Update () {
	
	}

    void Shot() {
        GameObject.Instantiate(arrowOriginal, transform.position, transform.localRotation);
    }
}
