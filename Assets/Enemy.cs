using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float speed = 15f;
	public float health = 10f;
	GameObject path;
	Transform targetPathNode;
	int pathNodeIndex = 0;

	public int moneyValue = 1;
	// Use this for initialization
	void Start () {
		path = GameObject.Find("Path");
	}
	void GetNextPathNode() {
		if(pathNodeIndex < path.transform.childCount) {
			targetPathNode = path.transform.GetChild(pathNodeIndex);
			pathNodeIndex++;
		}
		else {
			ReachedFinalNode();
			targetPathNode = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(targetPathNode == null) {
			GetNextPathNode();
			if(targetPathNode == null) {
				return;
			}
		}
		Vector3 dir = targetPathNode.position - this.transform.localPosition;
		float distThisFrame = speed * Time.deltaTime;
		if(dir.magnitude <= distThisFrame) {
			targetPathNode = null;
		}
		else {
			transform.Translate(dir.normalized * distThisFrame, Space.World);
			Quaternion targetRotation = Quaternion.LookRotation(dir);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, distThisFrame);
		}

	}
	void ReachedFinalNode() {
		GameObject.FindObjectOfType<ScoreBoard>().LoseLife();
		Destroy(this.gameObject);
	}

	public void TakeDamage(float damage) {
		health -= damage;
		if(health <= 0) {
			Die();
		}
	}
	public void Die() {
		GameObject.FindObjectOfType<ScoreBoard>().money += moneyValue;
		Destroy(gameObject);
	}
}
