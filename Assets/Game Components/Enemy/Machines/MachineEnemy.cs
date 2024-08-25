using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class MachineEnemy : Enemy
{
    public float fireRate = 3f;
    public float reloadTime = 2f;
    public int bulletCount = 5;
    public ParticleSystem[] particles;
    //public AudioSource audioSource;

    



    float timePassed = 0f;
    float time = 0f;
    int count;


    protected void initializeMachine()
    {
        initializeEnemy();
        count = bulletCount;
    }


    private void Update()
    {
        if (attackMode)
        {
            aim();
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




    protected override void destroyEffects()
    {
        for(int i=0;i < particles.Length;i++)
        {
            particles[i].Emit(1);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            if (health < 0)
            {
                handleDeath();
            }

        }
    }

    protected void loadBullet(Vector3 pos , Vector3 dir)
    {
        GameObject obj = Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
        obj.transform.position = pos;
        obj.transform.GetChild(0).gameObject.GetComponent<Bullet>().direction = dir;
        //audioSource.Play();
    }


    protected abstract void extraEffects();
    protected abstract void aim();
    protected abstract void fire();
}
