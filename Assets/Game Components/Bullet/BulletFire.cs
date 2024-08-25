using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public float offset;
    public float delay = 0.2f;
    public float bulletSpeed =1;
    public AudioSource audioSource;

    float timePassed = 0;
    Animator animator;


    private void Start()
    {
        timePassed = delay;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            timePassed += Time.deltaTime;
            if (timePassed > delay)
            {
                timePassed = 0;
                fire();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            timePassed = delay;
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("In");
        }
        if (Input.GetMouseButtonUp(1))
        {
            animator.SetTrigger("Out");
        }

    }

    void fire()
    {
        GameObject obj = Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
        obj.transform.position = transform.position + transform.forward*offset;
        obj.transform.GetChild(0).gameObject.GetComponent<Bullet>().direction = transform.forward * bulletSpeed;
        audioSource.Play();
    }
    
}


