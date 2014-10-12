using UnityEngine;
using System.Collections;

public class Seito : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Shake() {

		iTween.ScaleTo (gameObject, iTween.Hash("x", 1.5, "y", 1,5 "time", 0.4f, "easetype", iTween.EaseType.easeInElastic));
	}
}
