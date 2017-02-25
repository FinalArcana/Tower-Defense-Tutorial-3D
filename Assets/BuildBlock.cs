using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBlock : MonoBehaviour {

	/// <summary>
	/// OnMouseUp is called when the user has released the mouse button.
	/// </summary>
	void OnMouseUp() {
		Debug.Log("Build!");
		TowerManager tm = GameObject.FindObjectOfType<TowerManager>();
		if(tm.selectedTower != null) {
			Instantiate(tm.selectedTower, transform.position, transform.parent.rotation);
			Destroy(transform.parent.gameObject);
		}
	}

}
