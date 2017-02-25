using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed = 60f;
 	public float damage = 1f;
	public float aoeRadius = 0;
	public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(target == null) {
			Destroy(gameObject);
			return;
		}
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
		if(aoeRadius == 0) {
			target.GetComponent<Enemy>().TakeDamage(damage);
		}
		else {
			Collider[] cols = Physics.OverlapSphere(transform.position, aoeRadius);
			foreach(Collider c in cols) {
				Enemy e = c.GetComponent<Enemy>();
				if(e != null) {
					e.GetComponent<Enemy>().TakeDamage(damage);
				}
			}
		}
		Destroy(this.gameObject);
	}
}
