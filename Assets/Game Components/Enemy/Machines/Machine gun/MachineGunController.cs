using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MachineGunController : MachineEnemy
{
    float minRotationX = -50f;
    float maxRotationX = 50f;
    float minRotationY = -50f;
    float maxRotationY = 50f;


    GameObject gun;
    GameObject check;
    float offset = 1f;


    Vector3 currentRotation = Vector3.zero;
    Animator animator;

    

    void Start()
    {
        initializeMachine();

        gun = gameObject.transform.GetChild(0).GetChild(1).gameObject;
        check = gameObject.transform.GetChild(0).GetChild(1).GetChild(1).gameObject;
        animator = GetComponent<Animator>();
    }

    protected override void aim()
    {
        check.transform.LookAt(player.transform);

        currentRotation = check.transform.rotation.eulerAngles;


        if (currentRotation.x > 180) currentRotation.x -= 360;



        if (currentRotation.x >= minRotationX && currentRotation.x <= maxRotationX &&
            currentRotation.y >= minRotationY + 180 && currentRotation.y <= maxRotationY + 180)
        {
            gun.transform.LookAt(player.transform);
        }
    }

    protected override void fire()
    {
        loadBullet(gun.transform.position + gun.transform.forward * offset , gun.transform.forward * bulletSpeed);
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
