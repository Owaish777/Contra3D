using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DamageEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public Volume volume;
    float num = 0;
    int dir = 1;
    bool state = false;

    

    // Update is called once per frame
    void Update()
    {
        if (state)
        {
            num += Time.deltaTime * dir;
            if (num > 1)
            {
                num = 1;
                dir = -1;
            }
            if (num < 0)
            {
                state = false;
            }

            volume.weight = num;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            
            state = true;
            num = 0;
            dir = 1;

        }
    }
}
