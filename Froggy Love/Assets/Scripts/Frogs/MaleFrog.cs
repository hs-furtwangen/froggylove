﻿using System.Collections;
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
        return (int)(this.size * 1000) +(int)(Random.Range(0.0f, 999.0f));
    }
    public void pickUp()
    {
        state = behaviourStates.FLOATING;
    }

    public void putDown()
    {
        state = behaviourStates.FALLING;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if(state == behaviourStates.FALLING)
        {
            if (collision.gameObject.GetComponent<FemaleFrog>() != null)
            {
                attachTo(collision.gameObject);
            }
        }
    }

    // Use this for initialization
    void Start () {
        size = (Random.Range(1f, 2f));
        speed = 0.1f * size;
        initColor();
        initColliders();
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
