using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleFrog : Frog{

    private behaviourStates state;

    public void setBehaviourState(behaviourStates state)
    {
        this.state = state;
    }

    public void attachTo(GameObject target)
    {
        if (target.GetComponent<FemaleFrog>() != null)
        {
            Vector3 attachTarget = target.transform.Find("Marker").transform.position;
            this.transform.position = attachTarget;
            setBehaviourState(behaviourStates.PIGGYBACKING);
            FemaleFrog partner = target.GetComponent<FemaleFrog>();
            partner.setPartner(this);
            target.transform.SetParent(this.transform);
        }
    }
    public int getPoints()
    {
        return (int)(this.size * 1000);
    }
    public void pickUp()
    {

    }

    public void putDown()
    {

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
