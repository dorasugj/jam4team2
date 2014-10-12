using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour
{
	
	const int PLEAYER_L = 0;
	const int PLEAYER_R = 1;
	
	//弓の位置
	private Vector2[] BOW_POS = { new Vector2(Screen.width/4f      , Screen.height / 8f * 2f),
		new Vector2(Screen.width/4f * 3f , Screen.height / 8f * 2f)
	};
	
	private float SCREEN_HALF = Screen.width / 2f;
	
	private bool fMouse;
	private bool[] fTouch = new bool[2]; //タッチされているか
	private Touch[] tou;
	private Vector2[] touPos = new Vector2[2];
	
	void Start()
	{
		
	}
	
	void Update()
	{
		//タッチされたか
		//android
		for (int i = 0; i < Input.touchCount; i++)
		{
			if (Input.GetTouch(i).phase != TouchPhase.Began) continue;
			fMouse = false;
			if (Input.GetTouch(i).position.x < SCREEN_HALF)
			{
				tou[PLEAYER_L] = Input.GetTouch(i);
				fTouch[PLEAYER_L] = true;
			}
			else
			{
				tou[PLEAYER_R] = Input.GetTouch(i);
				fTouch[PLEAYER_R] = true;
			}
		}
		
		//mouse
		if (Input.GetMouseButtonDown(0))
		{
			fMouse = true;
			
			if (Input.mousePosition.x < SCREEN_HALF)
			{
				fTouch[PLEAYER_L] = true;
			}
			else
			{
				fTouch[PLEAYER_R] = true;
			}
			
		}
		
		//タッチ中
		for (int i = 0; i < 2; i++)
		{
			if (!fTouch[i]) continue;
			
			if (fMouse)
			{
				touPos[i] = Input.mousePosition;
			}
			else
			{
				touPos[i] = tou[i].position;
			}
		}
		
		//タッチ終了
		//android
		for (int i = 0; i < Input.touchCount; i++)
		{
			if (Input.GetTouch(i).phase != TouchPhase.Ended) continue;
			fTouch[i] = false;
		}
		
		//pc
		if (Input.GetMouseButtonUp(0))
		{
			if (Input.mousePosition.x < SCREEN_HALF)
			{
				fTouch[PLEAYER_L] = false;
			}
			else
			{
				fTouch[PLEAYER_R] = false;
			}
		}
		
		//弓の方向ベクトル
		Vector2 bowLRot = (touPos[PLEAYER_L] - BOW_POS[PLEAYER_L]).normalized;
		Vector2 bowRRot = (touPos[PLEAYER_R] - BOW_POS[PLEAYER_R]).normalized;
		
	}
	
	
	void OnDrawGizmos()
	{
		Color[] c = new Color[] { Color.red, Color.blue };
		//タッチ中
		for (int i = 0; i < 2; i++)
		{
			if (!fTouch[i]) continue;
			
			Gizmos.color = c[i];
			Gizmos.DrawLine(BOW_POS[i], touPos[i]);
			
			Gizmos.DrawLine(Vector2.zero, (touPos[i] - BOW_POS[i]).normalized);
		}
		
	}
	
}
