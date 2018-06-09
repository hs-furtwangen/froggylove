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
    protected Material greenMat ;
    protected Material yellowMat;
    protected Material blueMat;
    protected Material redMat;
    protected Material gayMat;

    public colors GetColors()
    {
        return this.colors;
    }
    public void moveTo(GameObject target)
    {
        this.moveTarget = target;
        if(target != null){
            targetPos = target.transform.position;
            this.transform.LookAt(moveTarget.transform);
        } else {
            targetPos = Vector3.zero;
        }
        // this.transform.rotation = Quaternion.Euler(0, this.transform.rotation.y + 90 ,0);
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
        // Debug.Log("Physical Size: " + physicalSize);
        froggy.transform.localScale = new Vector3(physicalSize, physicalSize, physicalSize);
        // Debug.Log("New Size " + froggy.transform.localScale);
        froggy.transform.position = new Vector3(froggy.transform.position.x, (physicalSize / 2), froggy.transform.position.z);

        collider.size = new Vector3(froggy.transform.localScale.x, froggy.transform.localScale.y, froggy.transform.localScale.z);
        collider.center = new Vector3(froggy.transform.position.x, froggy.transform.position.y, froggy.transform.position.z);
    }
    protected virtual void initMaterials()
    {
        greenMat = Resources.Load<Material>("Material/green");
        yellowMat = Resources.Load<Material>("Material/yellow");
        blueMat = Resources.Load<Material>("Material/blue");
        redMat = Resources.Load<Material>("Material/red");
        gayMat = Resources.Load<Material>("Material/rainbow");
        Debug.Log(gayMat);
    }
    protected void initColor()
    {
        GameObject froggy = this.transform.Find("Froggy").transform.Find("Frogbody").gameObject ;
        Renderer frogRenderer = froggy.GetComponent<Renderer>();

        float randColors = (Random.Range(0.0f, 100.0f));
        if (randColors <= 40f)
        {
            this.colors = colors.GREEN;
            pointPotential = 2.5f;
            frogRenderer.material = greenMat;
        }
        else if (randColors <= 65f)
        {
            this.colors = colors.YELLOW;
            pointPotential = 4f;
            frogRenderer.material = yellowMat;
        }
        else if (randColors <= 82f)
        {
            this.colors = colors.BLUE;
            pointPotential = 6f;
            frogRenderer.material = blueMat;
        }
        else if (randColors <= 92f)
        {
            this.colors = colors.RED;
            pointPotential = 10f;
            frogRenderer.material = redMat;
        }
        else if (randColors <= 100f)
        {
            this.colors = colors.RAINBOW;
            pointPotential = 12.5f;
            frogRenderer.material = gayMat;
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
        this.initMaterials();
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
