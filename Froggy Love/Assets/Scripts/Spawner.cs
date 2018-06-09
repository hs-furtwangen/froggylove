﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Transform pos1;
	public Transform pos2;
	public float speed;
	public GameObject spawnable;
	public GameObject target;
	float timeLeft = 0;
	const float minTimeOut = 1.5f;
	const float maxTimeOut = 3f;
	int toSpawn = 5;
	bool direction = false;

	void Start () {
		
	}
	
	void Update () {
		//move spawner position
		if(direction){
			//move from pos1 to pos2
			this.transform.position += (pos2.position - this.transform.position).normalized * speed;
			if ((this.transform.position - pos2.position).magnitude < 0.1){
				direction = false;
			}
		} else {
			//move from pos2 to pos1
			this.transform.position += (pos1.position - this.transform.position).normalized * speed;
			if ((this.transform.position - pos1.position).magnitude < 0.1){
				direction = true;
			}
		}

		//spawn new frogs when the timeout is down
		if(timeLeft > 0){
			timeLeft -= Time.deltaTime;
		} else if (toSpawn > 0){
			//create new GO here
			GameObject f = Instantiate(spawnable);
			f.transform.position = this.transform.position;
			f.GetComponent<Frog>().moveTo(target);
			timeLeft = Random.Range(minTimeOut, maxTimeOut);
			toSpawn--;
		}
	}

	void spawnNew(int amount = 1){
		toSpawn += amount;
	}
}
