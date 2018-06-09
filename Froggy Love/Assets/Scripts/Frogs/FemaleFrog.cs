using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleFrog : Frog {
    protected MaleFrog partner; 

    virtual protected void Bang()
    {
        if(partner != null)
        {
            int totalPoints = (int)(this.size * 1000) + partner.getPoints() + (int)(Random.Range(0.0f, 999.0f));
            if(this.colors == partner.GetColors())
            {
                GameController.gameControllerInstance.addPoints(totalPoints, this.pointPotential);
            }
            else
            {
                GameController.gameControllerInstance.addPoints(totalPoints, 1);
            }
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {

    }

    public void setPartner(MaleFrog partner)
    {
        this.partner = partner;
        
    }

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
        size = (Random.Range(1f, 2f));
        speed = 2f * size;
        initColor();
        initColliders();
    }
	
	// Update is called once per frame
	void Update () {
        if (moveTarget != null)
        {
            move();
        }
	}
}
