using UnityEngine;
using System.Collections;

public class TouchMgr : MonoBehaviour
{

    const int PLEAYER_L = 0;
    const int PLEAYER_R = 1;

    //弓の位置
    private Vector2[] BOW_POS = { new Vector2(Screen.width/4f      , Screen.height / 8f * 2f),
                                  new Vector2(Screen.width/4f * 3f , Screen.height / 8f * 2f)
                                };
	private GameObject[] bowGObj = new GameObject[2];

    private float SCREEN_HALF = Screen.width / 2f;

    private bool fMouse;
    private bool[] fTouch = new bool[2]; //タッチされているか
    private Touch[] tou = new Touch[2];
    private Vector2[] touPos = new Vector2[2];

    void Start()
    {
		bowGObj = new GameObject[2];
		bowGObj[PLEAYER_L] = GameObject.Find("BowL");
		bowGObj[PLEAYER_R] = GameObject.Find("BowR");
        Debug.Log("getObjct "+ bowGObj[0].name);
        Debug.Log("getObjct "+ bowGObj[1].name);
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
		
		
		//弓に方向を渡す
		for(int i=0; i < 2; i++) {
			if(!fTouch[i]) continue;
	        //弓の方向ベクトル
	        Vector2 rot = (BOW_POS[i] - touPos[i]).normalized;
            float z = Mathf.Atan2(rot.y, rot.x) * 180f / Mathf.PI - 90f;
			bowGObj[i].transform.transform.rotation = Quaternion.Euler(new Vector3(0,0,z));
		}
		
        //タッチ終了
        //android
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase != TouchPhase.Ended) continue;
            fTouch[i] = false;
            bowGObj[i].GetComponent<Bow>().SendMessage("Shot");
        }

        //pc
        if (Input.GetMouseButtonUp(0))
        {
            if (Input.mousePosition.x < SCREEN_HALF)
            {
                fTouch[PLEAYER_L] = false;
                bowGObj[PLEAYER_L].GetComponent<Bow>().SendMessage("Shot");

            }
            else
            {
                fTouch[PLEAYER_R] = false;
                bowGObj[PLEAYER_R].GetComponent<Bow>().SendMessage("Shot");

            }
        }
		
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
