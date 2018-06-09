using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleFrog : Frog {
    private MaleFrog partner; 

    private void bang()
    {

    }
    public void setPartner(MaleFrog partner)
    {
        this.partner = partner;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(this.transform.position.x + 0.05f, this.transform.position.y, this.transform.position.z);
	}
}
