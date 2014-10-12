using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Teacher>().Shake();
	}
	
	// Update is called once per frame
	void Update () {
		//mouse
		if (Input.GetMouseButtonDown(0))
		{
			Application.LoadLevel("Main");
		}
	}
}
