using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(Random.Range(0f, 1f) <= 0.5)
        {
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/GodPopuko");
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/FrogGod");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
