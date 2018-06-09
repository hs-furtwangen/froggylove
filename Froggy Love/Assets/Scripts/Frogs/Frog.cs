using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {
    private colors colors;
    private float speed = 3f;
    private float pointPotential;
    private float size;
    protected GameObject moveTarget;
    private Vector3 currentPos;
    private Vector3 targetPos;
    private float timer;
    Vector3 nextPosition = Vector3.zero;

    public void moveTo(GameObject target)
    {
        this.moveTarget = target;
        targetPos = target.transform.position;
    }
    protected void move()
    {
        currentPos = this.transform.position;
        if(timer < -2){
            timer = Random.Range(1.5f,2.5f);
            
            
            nextPosition = currentPos + (targetPos - currentPos).normalized * speed;
            // Debug.Log("Momentum: " + momentum);
        }
        if(timer > 0){
            this.transform.position += (nextPosition - currentPos) / speed / 3;
        }
        
        if (this.transform.position == targetPos)
        {
            targetPos = new Vector3(0, 0, 0);
            moveTarget = null;
        }

        
        timer -= Time.deltaTime;
    }
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveTarget != null)
        {
            move();
        }
    }
}
