using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMachine : MonoBehaviour
{

    public int health = 5;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            if (health < 0)
            {
                gameObject.GetComponent<DestroyMachine>().enabled = true;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "tank")
        {
            gameObject.GetComponent<TankController>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<MachineGunController>().enabled = true;
            animator.SetTrigger("Out");
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(gameObject.tag == "tank")
        {
            gameObject.GetComponent<TankController>().enabled = false;
            gameObject.GetComponent<TankController>().setTimePassed();
        }
        else
        {
            //gameObject./GetComponent<MachineGunController>().setTimePassed();
            gameObject.GetComponent<MachineGunController>().enabled = false;
            animator.SetTrigger("In");
        }
        
    }
}
