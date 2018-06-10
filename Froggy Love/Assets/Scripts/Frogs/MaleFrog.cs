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
        return (int)(this.size * 100000) +(int)(Random.Range(0.0f, 999.0f));
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
        anim = GetComponentInChildren<Animator>();
        size = (Random.Range(0.5f, 1f));
        speed = 2f * size;
        initMaterials();
        initColor();
        initColliders();
        state = behaviourStates.MOVING;
    }
	
	// Update is called once per frame
	void Update () {
        if(state == behaviourStates.FALLING){
            this.transform.position += Vector3.down * Time.deltaTime;
            float min = size / 10;
            if(this.transform.position.y < min){
                Debug.Log(min);
                this.transform.position = new Vector3(this.transform.position.x, min, this.transform.position.z);
                state = behaviourStates.MOVING;
                moveTo(GameObject.FindGameObjectWithTag("Log").GetComponent<Log>().getFreePosition());
            } 
        }
        if (moveTarget != null && state == behaviourStates.MOVING)
        {
            move();
        
            if(moveTarget.tag == "Log"){
                moveTo(moveTarget.GetComponent<Log>().getFreePosition());
            }

            if(moveTarget.transform.parent.tag == "Log"){
                Log log = moveTarget.transform.parent.GetComponent<Log>();
                if(!log.isPositionStillFree(moveTarget)){
                    moveTo(log.getFreePosition());
                }
                if((transform.position - moveTarget.transform.position).magnitude < 1){
                    if(!log.occupyPosition(moveTarget)){
                        moveTo(log.getFreePosition());
                    } else {
                        state = behaviourStates.SITTING;
                        this.transform.position = new Vector3(moveTarget.transform.position.x,moveTarget.transform.position.y, moveTarget.transform.position.z);
                        moveTo(null);
                    }
                }
            }
        }
	}
}
