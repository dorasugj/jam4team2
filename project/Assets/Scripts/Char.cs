using UnityEngine;
using System.Collections;

public class Char : MonoBehaviour {
	private int hitPlayey;
	private Vector3 prevPos;
	private Vector3 afterPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetPrevPos(Vector3 prevPos) {
		this.prevPos = prevPos;
	}

	public void SetAfterPos(Vector3 afterPos) {
		this.afterPos = afterPos;
	}

	public void MoveStart() {

	}
}
