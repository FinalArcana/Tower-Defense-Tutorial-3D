using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	Transform turretTransform;
	float range = 25f;
	public float damage = 1f;
	public GameObject bulletPref;
	// Use this for initialization
	float attackSpeed = 0.2f;
	float attackSpeedLeft = 0;
	void Start () {
		
		turretTransform = transform.Find("Turret");
	}
	

	// Update is called once per frame
	void Update () {
		Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

		Enemy nearestEnemy = null;
		float dist = Mathf.Infinity;

		foreach(Enemy e in enemies) {
			float d = Vector3.Distance(this.transform.position, e.transform.position);
			if(nearestEnemy == null || d < dist) {
				nearestEnemy = e;
				dist = d;
			}
		}

		if(nearestEnemy == null) {
			Debug.Log("No enemies detected");
			return;
		}
		Vector3 dir = nearestEnemy.transform.position - this.transform.position;
		Quaternion lookRot = Quaternion.LookRotation(dir);
		turretTransform.rotation = Quaternion.Euler( turretTransform.eulerAngles.x, lookRot.eulerAngles.y, turretTransform.eulerAngles.z);
		
		attackSpeedLeft -= Time.deltaTime;
		if(attackSpeedLeft <= 0 && dir.magnitude <= range) {
			attackSpeedLeft = attackSpeed;
			AttackOn(nearestEnemy);
		}
	}

	void AttackOn(Enemy e) {
		GameObject bulletObj = (GameObject)Instantiate(bulletPref,this.transform.position, this.transform.rotation);
		Bullet b = bulletObj.GetComponent<Bullet>();
		b.target = e.transform;



	}
}
