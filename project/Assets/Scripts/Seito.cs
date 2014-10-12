using UnityEngine;
using System.Collections;

public class Seito : MonoBehaviour {
	public GameObject seito;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Shake() {
		iTween.ScaleTo (seito, iTween.Hash("x", 1.5, "y", 1.5, "time", 0.4f, "easetype", iTween.EaseType.easeInElastic, "oncomplete", "OnComplete", "oncompletetarget", gameObject));
	}

	void OnComplete() {
		iTween.ScaleTo (seito, iTween.Hash("x", 1.15963, "y", 1.259609, "time", 0.4f, "easetype", iTween.EaseType.easeInElastic));
	}
}
