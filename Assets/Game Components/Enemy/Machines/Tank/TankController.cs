using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MachineEnemy
{

    public AudioSource audioSource;


    GameObject check;
    GameObject upperPart;
    GameObject muzzleL, muzzleR;
    GameObject gunL, gunR;


    void Start()
    {
        initializeMachine();
        check = gameObject.transform.GetChild(1).gameObject;
        upperPart = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        muzzleL = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(5).GetChild(1).GetChild(0).gameObject;
        muzzleR = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(5).GetChild(0).GetChild(0).gameObject;

        gunL = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(5).GetChild(1).gameObject;
        gunR = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(5).GetChild(0).gameObject;


    }

  

    protected override void aim()
    {
        check.transform.LookAt(player.transform);

        //currentRotation = check.transform.rotation.eulerAngles;


        //if (currentRotation.x > 180) currentRotation.x -= 360;



        //if (currentRotation.x >= minRotationX && currentRotation.x <= maxRotationX &&
        //    currentRotation.y >= minRotationY + 180 && currentRotation.y <= maxRotationY + 180)
        //{
            upperPart.transform.LookAt(player.transform);
        //}
    }

    protected override void fire()
    {
        loadBullet(muzzleL.transform.position, gunL.transform.forward * bulletSpeed);
        loadBullet(muzzleR.transform.position, gunR.transform.forward * bulletSpeed);
    }

    protected override void extraEffects()
    {

    }

    protected override void activateMachine()
    {
        ////animator.SetTrigger("Out");
    }
    protected override void deactivateMachine()
    {
        //animator.SetTrigger("In");
    }
}
