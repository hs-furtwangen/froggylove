using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {
    protected colors colors;
    protected float speed;
    protected float pointPotential;
    protected float size;
    private GameObject moveTarget;
    private Vector3 currentPos;
    private Vector3 targetPos;


    public colors GetColors()
    {
        return this.colors;
    }

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
    void Update()
    {
        if (moveTarget != null)
        {
            move();
        }
    }
}
