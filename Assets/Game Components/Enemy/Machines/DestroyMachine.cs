using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class DestroyMachine : MonoBehaviour
{
    public ParticleSystem[] particles;
    public float delay = 0.5f;

    float timePassed;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > delay)
        {
            if(counter < particles.Length)
            {
                particles[counter].Play();
                counter++;
                timePassed = 0;

                if (counter==2)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                }

            }
            else
            {
                if (particles[counter - 1].isStopped) Destroy(gameObject);
            }

            
        }
    }
}
