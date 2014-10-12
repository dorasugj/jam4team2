using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Char : MonoBehaviour {
	public GameObject textObj;
	int hitPlayey;
	Vector3 startPos;
	Vector3 endPos;
	RectTransform rectTransform;

	// Use this for initialization
	void Awake() {
		GetComponent<RectTransform>().localPosition = Vector3.zero;
		rectTransform = textObj.GetComponent<RectTransform>();
	}
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetPrevPos(Vector3 prevPos) {
		this.startPos = prevPos;
	}

	public void SetAfterPos(Vector3 afterPos) {
		this.endPos = afterPos;
	}

	public void MoveStart() {
		iTween.MoveTo (textObj, iTween.Hash("x", endPos.x, "y", endPos.y, "z", endPos.z, "time", 3f, "easetype", iTween.EaseType.easeOutCubic, "oncomplete", "OnComplete", "oncompletetarget", gameObject));
	}

	void OnComplete() {
		Destroy (gameObject);
	}

	public void SetInfo(Vector3 startPos, Vector3 endPos, char text) {
		this.startPos = startPos;
		this.endPos = endPos;
		textObj.GetComponent<Text>().text = text.ToString ();
		rectTransform.position = new Vector3 (startPos.x, startPos.y, startPos.z);
	}
}
