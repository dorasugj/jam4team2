using UnityEngine;
using System.Collections;

public class Teacher : MonoBehaviour {
	public GameObject teacher;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Shake() {
		iTween.ShakePosition(teacher, iTween.Hash("x", -1));
		iTween.ShakeRotation(teacher, iTween.Hash("y", 1));
		iTween.ShakeScale(teacher, iTween.Hash("x", 1.1, "y", 1.1));
	}
}
