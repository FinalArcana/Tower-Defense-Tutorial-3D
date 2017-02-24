using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	float speed = 15f;
	GameObject path;
	Transform targetPathNode;
	int pathNodeIndex = 0;
	// Use this for initialization
	void Start () {
		path = GameObject.Find("Path");
	}
	void GetNextPathNode() {
		targetPathNode = path.transform.GetChild(pathNodeIndex);
		pathNodeIndex++;
	}
	
	// Update is called once per frame
	void Update () {
		if(targetPathNode == null) {
			GetNextPathNode();
			if(targetPathNode == null) {
				ReachedFinalNode();
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
		Destroy(this.gameObject);
	}
}
