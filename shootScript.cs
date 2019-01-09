using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour {
	// カメラトラッキングオブジェクト保持用変数
	private Rigidbody tracking;
	// カメラトラッキング対象にする3Dオブジェクトの名前リスト
	private List<string> trackNameList = new List<string>(){"Sphere1", "Sphere2", "Sphere3"};
	// Use this for initialization
	void Start () {
		tracking = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit rayhit;
			Vector3 mpos = Input.mousePosition;
			mpos.z = 0;
			Ray ray = Camera.main.ScreenPointToRay (mpos);
			if (Physics.Raycast (ray, out rayhit, 1000f)) {
				Rigidbody s = rayhit.transform.GetComponent<Rigidbody> ();
				// 床や坂にカメラをトラックさせないように，ついでに力を加えないようにする
				if (trackNameList.Exists (p => p == s.name)) {
					tracking = s;
					// クリックした方向に力を加える（ray.directionは正規化されている）
					tracking.AddForce (ray.direction * 100f);
				}
			}
		}
		if (tracking != null) {
			Vector3 tp = tracking.transform.position;
			//カメラにオブジェクトが映るように位置調整
			Vector3 cplacexz = Vector3.Scale(Camera.main.transform.forward, new Vector3(1f, 0f, 1f)).normalized;
			tp.y += 1f;
			tp -= cplacexz * 10f;
			Camera.main.transform.position = tp;
		}
	}
}
