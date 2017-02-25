using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed = 60f;
 	public float damage = 1f;

	public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = target.position - this.transform.localPosition;
		float distThisFrame = speed * Time.deltaTime;
		if(dir.magnitude <= distThisFrame) {
			BulletHit();
		}
		else {
			transform.Translate(dir.normalized * distThisFrame, Space.World);
			Quaternion targetRotation = Quaternion.LookRotation(dir);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, distThisFrame);
			
		}


	}
	void BulletHit() {
		gameObject.GetComponent<Enemy>().health -= 1;
		Destroy(this.gameObject);
	}
}
