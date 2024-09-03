using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MachineGunController : MachineEnemy
{
    //To bound the gun's view
    [SerializeField] float minRotationX = -50f;
    [SerializeField] float maxRotationX = 50f;
    [SerializeField] float minRotationY = -50f;
    [SerializeField] float maxRotationY = 50f;


    GameObject gun , muzzle;

    GameObject check;


    Vector3 currentRotation = Vector3.zero;
    Animator animator;

    bool inView = false;
    

    void Start()
    {
        //Initializes its parent
        initializeMachine();

        
        muzzle = gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject;
        gun = gameObject.transform.GetChild(0).GetChild(1).gameObject;
        check = gameObject.transform.GetChild(0).GetChild(1).GetChild(1).gameObject;
        animator = GetComponent<Animator>();
    }

    protected override void aim()
    {
        check.transform.LookAt(player.transform);

        currentRotation = check.transform.rotation.eulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;


        //If player is in view
        if (currentRotation.x >= minRotationX && currentRotation.x <= maxRotationX &&
            currentRotation.y >= minRotationY + 180 && currentRotation.y <= maxRotationY + 180)
        {
            inView = true;
        }
        else inView = false;


        if(inView) gun.transform.LookAt(player.transform);
    }

    protected override void fire()
    {
        if (inView) loadBullet(muzzle.transform.position, gun.transform.forward * bulletSpeed);
    }

    protected override void extraEffects()
    {

    }

    protected override void activateMachine()
    {
        animator.SetTrigger("Out");
    }
    protected override void deactivateMachine()
    {
        animator.SetTrigger("In");
    }
}
