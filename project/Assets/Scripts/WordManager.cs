using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordManager : MonoBehaviour {
	public GameObject charObject;
	private List<List<CharInfo>> CharMovePosList;
	private float timer = 0;
	private float wordPopInterval = 2;

	private int nextWordIndex;

	// Use this for initialization
	void Start () {
		CharMovePosList = new List<List<CharInfo>> ();
		CharMovePosList.Add(CreateWord1 ());
	}

	void Update () {
		timer += Time.deltaTime;

		if (timer < wordPopInterval) {
			return;
		}
		timer = 0;

		// nextWordIndexを元にワードを生成していく
		switch (nextWordIndex) {
		case 0:
			GetComponent<Teacher>().Shake();
			PopWord(CharMovePosList[nextWordIndex]);
			break;
		case 1:
			break;
		}
	}

	private void PopWord(List<CharInfo> charInfos) {
		foreach (var charInfo in charInfos) {
			GameObject chObject = (GameObject) Instantiate (charObject);
			Char charController = chObject.GetComponent<Char>();
			charController.SetInfo(charInfo.GetStartPos(), charInfo.GetEndPos(), charInfo.GetChar());
			charController.MoveStart();
		}
	}
	
	List<CharInfo> CreateWord1() {
		List<CharInfo> wordPosition = new List<CharInfo>();
		string word = "コラ！！！";
		int fontSize = 90;
		int charCnt = 0;
		int half = (word.Length - 1) * fontSize / 2;

		foreach (var chr in word) {
			Debug.Log (charCnt * fontSize);
			int x = charCnt * fontSize + 70;
			wordPosition.Add (new CharInfo(new Vector3((x - half) + 250, 500, 0), new Vector3(-(x - half) + 250, 100, 0), word[charCnt]));
			charCnt++;
		}

		return wordPosition;
	}
	
	public class CharInfo {
		private Vector3 startPos;
		private Vector3 endPos;
		private char text;
		
		public CharInfo(Vector3 startPos, Vector3 endPos, char text) {
			this.startPos = startPos;
			this.endPos = endPos;
			this.text = text;
		}
		
		public Vector3 GetStartPos() {
			return startPos;
		}
		
		public Vector3 GetEndPos() {
			return endPos;
		}

		public char GetChar() {
			return text;
		}
	}
}
