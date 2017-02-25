using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	float spawnCD = 0.75f;
	float spawnCDremaining = 0;
	[System.Serializable]
	public class WaveComponent {
		public GameObject enemyPref;
		public int num;
		[System.NonSerialized]
		public int spawned = 0;
	}
	public WaveComponent[] waves;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool didSpawn = false;
		spawnCDremaining -= Time.deltaTime;
		if(spawnCDremaining < 0) {
			spawnCDremaining = spawnCD;
			foreach(WaveComponent wc in waves) {
				if(wc.spawned < wc.num) {
					Instantiate(wc.enemyPref, this.transform.position, this.transform.rotation);
					wc.spawned++;
					didSpawn = true;
					break;
				}
			}

			if(didSpawn == false) {
				Destroy(gameObject);
			}
		}
		
	}
}
