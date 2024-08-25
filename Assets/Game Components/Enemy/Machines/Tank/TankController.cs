using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public float offset1;
    public float delay = 0.2f;
    public float timeGap = 2;
    public float bulletSpeed = 15;
    public int bulletCount = 3;
    public GameObject gun;
    public GameObject gun2;
    public AudioSource audioSource;


    float timePassed = 0;
    float time = 0;
    float count;


    GameObject check;
    GameObject upperPart;
    Vector3 currentRotation = Vector3.zero;


    public float minRotationX = -50f;
    public float maxRotationX = 50f;

    // Start is called before the first frame update
    void Start()
    {
        check = gameObject.transform.GetChild(1).gameObject;
        upperPart = gameObject.transform.GetChild(0).GetChild(0).gameObject;


        count = bulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        check.transform.LookAt(player.transform);       

        currentRotation = check.transform.rotation.eulerAngles;


        if (currentRotation.x > 180) currentRotation.x -= 360;



        if (currentRotation.x >= minRotationX && currentRotation.x <= maxRotationX)
        {
            upperPart.transform.eulerAngles = new Vector3(upperPart.transform.eulerAngles.x, check.transform.eulerAngles.y, upperPart.transform.eulerAngles.x);

            timePassed += Time.deltaTime;

            if (timePassed > timeGap)
            {
                time += Time.deltaTime;
                if (time > delay)
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

    public void setTimePassed()
    {
        timePassed = 0;
    }

    void fire()
    {
        GameObject obj = Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
        obj.transform.position = gun.transform.position + offset1*gun.transform.forward;
        obj.transform.GetChild(0).gameObject.GetComponent<Bullet>().direction = gun.transform.forward * bulletSpeed;

        GameObject obj2 = Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
        obj2.transform.position = gun2.transform.position + offset1 * gun.transform.forward;
        obj2.transform.GetChild(0).gameObject.GetComponent<Bullet>().direction = gun.transform.forward * bulletSpeed;
        audioSource.Play();
    }
}
