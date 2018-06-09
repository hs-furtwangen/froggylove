using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Frog : MonoBehaviour {
    protected colors colors;
    protected float speed;
    protected float pointPotential;
    protected float size;
    protected GameObject moveTarget;
    private Vector3 currentPos;
    private Vector3 targetPos;
    private float timer;
    Vector3 nextPosition = Vector3.zero;
    protected Animator anim;

    public colors GetColors()
    {
        return this.colors;
    }
    public void moveTo(GameObject target)
    {
        this.moveTarget = target;
        targetPos = target.transform.position;
    }
    protected void move()
    {
        currentPos = this.transform.position;
        if (timer < -2)
        {
            timer = Random.Range(1.5f, 2.5f);
            nextPosition = currentPos + (targetPos - currentPos).normalized * speed;
            anim.SetTrigger("JUMP");
        }
        if (timer > 0)
        {
            this.transform.position += (nextPosition - currentPos) / speed / 3;
            // Debug.Log(nextPosition + " " + currentPos);
        }

        if (this.transform.position == targetPos)
        {
            targetPos = new Vector3(0, 0, 0);
            moveTarget = null;
        }


        timer -= Time.deltaTime;
    }
    protected void initColliders()
    {
        BoxCollider collider = this.gameObject.AddComponent<BoxCollider>();
        GameObject froggy = this.transform.Find("Froggy").gameObject;

        float physicalSize = size * 0.1f;
        Debug.Log("Physical Size: " + physicalSize);
        froggy.transform.localScale = new Vector3(physicalSize, physicalSize, physicalSize);
        Debug.Log("New Size " + froggy.transform.localScale);
        froggy.transform.position = new Vector3(froggy.transform.position.x, (physicalSize / 2), froggy.transform.position.z);

        collider.size = new Vector3(froggy.transform.localScale.x, froggy.transform.localScale.y, froggy.transform.localScale.z);
        collider.center = new Vector3(froggy.transform.position.x, froggy.transform.position.y, froggy.transform.position.z);
    }
    protected void initColor()
    {
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

    protected void OnCollisionEnter(Collision collision)
    {
        
    }

    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
        size = (Random.Range(1f, 2f));
        speed = 2f * size;
        initColor();
        initColliders();
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
