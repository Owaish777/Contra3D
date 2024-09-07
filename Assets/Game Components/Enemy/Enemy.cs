using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Enemy : MonoBehaviour
{
    //Health of enemy
    public int health = 5;
    //Attack Power of enemy
    public int attackPower = 5;
    
    //Reference of the Player object
    protected GameObject player;

    //Attack mode if true -> enemy will attack
    protected bool attackMode = false;


    protected static float bulletSpeed = 20;

    //Reference of the Bullet prefab
    protected GameObject bullet;

    //As start method wont work for abstract class , initializeEnemy is going to be called by its childs
    protected void initializeEnemy()
    {
        //Getting the player object
        Transform[] childTransforms = transform.root.gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform.name == "Player")
            {
                player = childTransform.gameObject;
                break;
            }
        }

        //Getting the bullet's prefab
        string assetPath = "Assets/Game Components/Bullet/Bullet.prefab";
        bullet = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
    }

    //If Player is in range of attack
    private void OnTriggerEnter(Collider other)
    {
        activateMachine();
        attackMode = true;
    }

    //If player if out of range
    private void OnTriggerExit(Collider other)
    {
        deactivateMachine();
        attackMode = false;
    }


    //Handels the death of enemy
    public void handleDeath()
    {
        destroyEffects();
        Destroy(gameObject);
    }

    //position the bullet to the correct position 
    protected void loadBullet(Vector3 pos, Vector3 dir)
    {
        GameObject obj = Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
        obj.transform.position = pos;
        obj.transform.GetChild(0).gameObject.GetComponent<Bullet>().direction = dir;
        //audioSource.Play();
    }

    //Handles damage
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

    //Effect on destruction of enemy , must be overridden by its childs
    protected abstract void destroyEffects();
    //when player enters in the range, must be overridden by its childs
    protected abstract void activateMachine();
    //when player exits the range, must be overridden by its childs
    protected abstract void deactivateMachine();
    //Aims the machine toward the palyer , must be overridden by its childs
    protected abstract void aim();
    //Fires the bullet , must be overridden by its childs
    protected abstract void fire();

}
