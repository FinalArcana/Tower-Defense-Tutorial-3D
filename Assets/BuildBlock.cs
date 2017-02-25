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
			ScoreBoard sb = GameObject.FindObjectOfType<ScoreBoard>();
			if(sb.money < tm.selectedTower.GetComponent<Tower>().cost) {
				Debug.Log("Not enough money!");
				return;
			}
			sb.money -= tm.selectedTower.GetComponent<Tower>().cost;
			Instantiate(tm.selectedTower, transform.position, transform.parent.rotation);
			Destroy(transform.parent.gameObject);
		}
	}

}
