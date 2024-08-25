using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedStateChange : MonoBehaviour
{

    public GameObject player;
    public GameObject bullet;
    public GameObject gun;
    public GameObject direction;
    public float  offset;

    public float bulletSpeed = 15;
    public AudioSource audioSource;

    public GameObject controller;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void startShooting()
    {
        
        controller.GetComponent<RedController>().setState(true);
        
    }
    public void startRunning()
    {
        if(controller.GetComponent<RedController>().isPlayerOut()) controller.GetComponent<RedController>().setState(false);
    }

    public void fire()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Transition")) return;

        GameObject obj = Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
        obj.transform.position = direction.transform.position;
        //obj.transform.GetChild(0).gameObject.GetComponent<Bullet>().direction = direction.transform.forward * bulletSpeed;
        obj.transform.GetChild(0).gameObject.GetComponent<Bullet>().direction = direction.transform.forward * bulletSpeed;

        audioSource.Play();
    }
}
