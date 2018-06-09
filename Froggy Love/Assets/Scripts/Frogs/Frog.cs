using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {
    private colors colors;
    private float speed;
    private float pointPotential;
    private float size;
    private GameObject moveTarget;
    private Vector3 currentPos;
    private Vector3 targetPos;

    public void moveTo(GameObject target)
    {
        this.moveTarget = target;
        currentPos = this.transform.position;
        targetPos = target.transform.position;
    }
    private void move()
    {
        
        Vector3 momentum = Vector3.Lerp(currentPos, targetPos, 0.1f * speed);
        Debug.Log("Momentum: " + momentum);
        this.transform.position += momentum;
        if (this.transform.position == targetPos)
        {
            targetPos = new Vector3(0, 0, 0);
            moveTarget = null;
        }
    }
    // Use this for initialization
    void Start () {
        speed = 0.1f;
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
