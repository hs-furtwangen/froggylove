using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toad : FemaleFrog {
    override protected void Bang()
    {
        if (partner != null)
        {
            int totalPoints = (int)(this.size * 1000) + partner.getPoints() + (int)(Random.Range(0.0f, 999.0f));
            GameController.gameControllerInstance.addPoints(totalPoints, pointPotential);
        }
    }
	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
        size = 3;
        speed = 2f * size;
        pointPotential = -1;
    }
	
	// Update is called once per frame
	void Update () {
		if (moveTarget != null)
        {
            move();
        }
	}
}
