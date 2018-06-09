using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleFrog : Frog {
    private MaleFrog partner; 

    private void bang()
    {
        if(partner != null)
        {
            int totalPoints = (int)(this.size * 1000) + partner.getPoints();
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
    public void setPartner(MaleFrog partner)
    {
        this.partner = partner;
        
    }

	// Use this for initialization
	void Start () {
        size = (Random.Range(1f, 2f));
        speed = 0.1f * size;
        float randColors = (Random.Range(0.0f, 100.0f));
        if (randColors <= 40f)
        {
            this.colors = colors.GREEN;
            pointPotential = 2.5f;
        }
        else if (randColors <= 65f)
        {
            this.colors = colors.YELLOW;
            pointPotential = 4f;
        }
        else if (randColors <= 82f)
        {
            this.colors = colors.BLUE;
            pointPotential = 6f;
        }
        else if (randColors <= 92f)
        {
            this.colors = colors.RED;
            pointPotential = 10f;
        }
        else if (randColors <= 100f)
        {
            this.colors = colors.RAINBOW;
            pointPotential = 12.5f;
        }
    }
	
	// Update is called once per frame
	void Update () {
		// this.transform.position = new Vector3(this.transform.position.x + 0.05f, this.transform.position.y, this.transform.position.z);
        // this.move();
        if (moveTarget != null)
        {
            move();
        }
	}
}
