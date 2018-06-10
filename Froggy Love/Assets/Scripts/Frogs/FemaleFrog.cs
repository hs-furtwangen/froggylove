using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleFrog : Frog {
    protected MaleFrog partner; 

    virtual protected void Bang()
    {
        if(partner != null)
        {
            int totalPoints = (int)(this.size * 100000) + partner.getPoints() + (int)(Random.Range(0.0f, 999.0f));
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

    override protected void initMaterials()
    {
        greenMat = Resources.Load<Material>("Material/femaleGreen");
        yellowMat = Resources.Load<Material>("Material/femaleYellow");
        blueMat = Resources.Load<Material>("Material/femaleBlue");
        redMat = Resources.Load<Material>("Material/femaleRed");
        gayMat = Resources.Load<Material>("Material/rainbow");
        // Debug.Log("Fuuuuuck");
    }

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
        size = (Random.Range(1.5f, 2f));
        speed = 2f * size;
        initMaterials();
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
