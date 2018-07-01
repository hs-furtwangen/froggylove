using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toad : FemaleFrog {


    override protected void Bang()
    {
        if (partner != null)
        {
            int totalPoints = (int)(this.size * 1000) + partner.getPoints() + (int)(Random.Range(0.0f, 999.0f));
            GameController.gameControllerInstance.addPoints(totalPoints, pointPotential);
        }
        Destroy(this.gameObject);
    }
    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
        size = 3;
        speed = 3f * size;
        pointPotential = -1;
        GameObject froggy = this.transform.Find("Froggy").transform.Find("Frogbody").gameObject;
        Renderer frogRenderer = froggy.GetComponent<Renderer>();
        Material toadMat;
        toadMat = Resources.Load<Material>("Material/brown");
        frogRenderer.material = toadMat;
    }
    public void setPartner(MaleFrog partner)
    {
        base.setPartner(partner);

    }
    // Update is called once per frame
    void Update () {
        if (moveTarget != null)
        {
            move();
            if ((this.transform.position - moveTarget.transform.position).magnitude < 2)
            {
                Bang();
            }
        }
    }
}
