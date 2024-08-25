using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovementScript : MonoBehaviour
{
    float x, z;
    Vector3 move,velocityY;
    Vector2 velocity;
    bool isGrounded = false;
    int setJump;
    
    
    public float steadySpeed = 12f;
    public float accleration = 5f;
    public float deccleration = 2f;
    public float gravity = -9.8f;
    public float radius;
    public LayerMask layerMask;
    public int jumpCount = 2;
    public int dash = 5;
    public int dashTime = 1;

    public AudioSource audioSource;

    CharacterController controler;

    private void Start()
    {
        setJump = jumpCount;
        audioSource.Play();
        controler = GetComponent<CharacterController>();    
    }

    void Update()
    {
        

        //xz movement
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");


        isGrounded = controler.isGrounded;
        if(isGrounded)
        {
            setJump = jumpCount;
            velocityY.y = -0.1f;
        }


        if (!isGrounded)
        {
            velocityY.y += gravity * Time.deltaTime;
        }
        else
        {
            if (x != 0 || z != 0)
            {
                if (x * velocity.x >= 0 && x!=0)
                {
                    velocity.x += x * accleration * Time.deltaTime;
                    velocity.x = Mathf.Clamp(velocity.x, -steadySpeed, steadySpeed);
                }
                else
                {
                    velocity.x = Mathf.Sign(velocity.x) * (Mathf.Clamp((Mathf.Abs(velocity.x) - deccleration * Time.deltaTime), 0, steadySpeed));

                }
                if (z * velocity.y >= 0 && z!=0)
                {
                    velocity.y += z * accleration * Time.deltaTime;
                    velocity.y = Mathf.Clamp(velocity.y, -steadySpeed, steadySpeed);
                }
                else
                {
                   velocity.y = Mathf.Sign(velocity.y) * (Mathf.Clamp((Mathf.Abs(velocity.y) - deccleration * Time.deltaTime), 0, steadySpeed));

                }
            }
        
            else
            {
                velocity.x = Mathf.Sign(velocity.x)*(Mathf.Clamp((Mathf.Abs(velocity.x) - deccleration*Time.deltaTime),0,steadySpeed));
                velocity.y = Mathf.Sign(velocity.y) * (Mathf.Clamp((Mathf.Abs(velocity.y) - deccleration * Time.deltaTime), 0, steadySpeed));
            }
        }
        


        
        
        move = transform.right*velocity.x + transform.forward*velocity.y;

  


        
        controler.Move(move*Time.deltaTime);
        //

        
        //jump code
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (setJump > 0)
            {
                velocityY.y = 10;
                isGrounded = false;
                setJump--;
            }
        }
        //

        //y movement
        controler.Move(velocityY * Time.deltaTime);
        //
    }


}
