using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    ParticleSystem particles;

    // Update is called once per frame
    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        transform.position += direction*Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        particles.Play();
        direction = Vector3.zero;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        Destroy(gameObject.transform.parent.gameObject, 1);
    }
    
    
}
