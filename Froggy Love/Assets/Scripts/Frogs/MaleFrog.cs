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
        // Debug.Log("Hit");
        if (target.GetComponent<FemaleFrog>() != null)
        {
            Vector3 attachTarget = target.transform.Find("Marker").transform.position;
            this.transform.position = attachTarget;
            setBehaviourState(behaviourStates.PIGGYBACKING);
            FemaleFrog partner = target.GetComponent<FemaleFrog>();
            partner.setPartner(this);
            this.transform.SetParent(target.transform);
            this.tag = "Tag";
        }
    }
    public int getPoints()
    {
        return (int)(this.size * 10) +(int)(Random.Range(0.0f, 9.0f));
    }
    public void pickUp()
    {
        state = behaviourStates.FLOATING;
        GameObject.FindGameObjectWithTag("Log").GetComponent<Log>().freePosition(moveTarget);
    }

    public void putDown()
    {
        state = behaviourStates.FALLING;
        moveTo(null);
    }

    void OnTriggerEnter(Collider collision)
    {
        // Debug.Log("hit1");
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
            // this.transform.position += Vector3.down * Time.deltaTime * 3;
            GetComponent<Rigidbody>().MovePosition(this.transform.position + Vector3.down * Time.deltaTime * 3);
            float min = size / 2;
            if(this.transform.position.y < min){
                // Debug.Log(min);
                 GetComponent<Rigidbody>().MovePosition(new Vector3(this.transform.position.x, min, this.transform.position.z));
                state = behaviourStates.MOVING;
                moveTo(GameObject.FindGameObjectWithTag("Log").GetComponent<Log>().getFreePosition());
                // Debug.Log(moveTarget.name + ", " + this.transform.position);
                timer = 0;
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
                        // Debug.Log(this.transform.position + ", " + moveTarget.transform.position);
                        state = behaviourStates.SITTING;
                        this.transform.position = new Vector3(moveTarget.transform.position.x,moveTarget.transform.position.y + 1.7f, moveTarget.transform.position.z);
                        // moveTo(null);
                    }
                }
            }
        }
	}
}
