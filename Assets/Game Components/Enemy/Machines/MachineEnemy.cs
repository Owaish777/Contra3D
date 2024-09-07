using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class MachineEnemy : Enemy
{
    //Fire rate of the gun
    public float fireRate = 3f;
    //Reload time of the gun
    public float reloadTime = 2f;
    //Total bullets in a set
    public int bulletCount = 5;
    //Reference to the particles
    public ParticleSystem[] particles;
    //public AudioSource audioSource;

    


    
    float timePassed = 0f;
    float time = 0f;
    int count;

    //As the class is abstract , the start fucntion will not work
    //initializeMachine() which initializes the machineEnemy and its parent enemy
    protected void initializeMachine()
    {
        //Parent initialization
        initializeEnemy();
        count = bulletCount;
    }


    private void Update()
    {
        //if attack mode is true
        if (attackMode)
        {
            //take aim
            aim();

            //Mechanism for calling the fire()
            timePassed += Time.deltaTime;

            if (timePassed > reloadTime)
            {
                time += Time.deltaTime;
                if (time > 1/fireRate)
                {
                    time = 0;

                    fire();

                    count--;

                    if (count == 0)
                    {
                        count = bulletCount;
                        timePassed = 0;
                    }

                }
            }

        }
    }



    //At the time of death emit the particles
    protected override void destroyEffects()
    {
        for(int i=0;i < particles.Length;i++)
        {
            particles[i].Emit(1);
        }
    }


    //If a enemy needs its own special effect , must be overridden by its childs
    protected abstract void extraEffects();

}


