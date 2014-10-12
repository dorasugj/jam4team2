using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

   public float speed = 0.5f;

	void Start () {
	    Destroy(gameObject, 4f);
	}
	
	void Update () {
	    transform.position += transform.up * speed;
	}
}
