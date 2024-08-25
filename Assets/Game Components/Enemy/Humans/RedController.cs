using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedController : MonoBehaviour
{
    public int health = 5;
    public GameObject player;
    Animator animator;

    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;

    public float speed = 5;
    float distanceTravelled=0;
    [SerializeField] bool state = false;
    [SerializeField] bool playerOut = true;


    public bool isPlayerOut()
    {
        return playerOut;
    }
    public void setState(bool set)
    {
        state = set;
    }


    private void Start()
    {
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }


    private void Update()
    {
        if(!state)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }
        else
        {
            transform.LookAt(player.transform);
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            if (health < 0)
            {
                Destroy(transform.parent.gameObject);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("attack", true);
        playerOut = false;
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("attack", false);
        playerOut = true;
    }

    
}
