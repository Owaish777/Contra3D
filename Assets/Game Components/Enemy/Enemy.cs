using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Enemy : MonoBehaviour
{
    public int health = 5;
    public int attackPower = 5;
    

    protected GameObject player;
    protected bool attackMode = false;
    protected static float bulletSpeed = 5;

    protected GameObject bullet;

    protected void initializeEnemy()
    {
        Transform[] childTransforms = transform.root.gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform.name == "Player")
            {
                player = childTransform.gameObject;
                break;
            }
        }

        string assetPath = "Assets/Game Components/Bullet/Bullet.prefab";
        bullet = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
    }


    private void OnTriggerEnter(Collider other)
    {
        activateMachine();
        attackMode = true;
    }
    private void OnTriggerExit(Collider other)
    {
        deactivateMachine();
        attackMode = false;
    }



    public void handleDeath()
    {
        destroyEffects();
        Destroy(gameObject);
    }

    protected abstract void destroyEffects();
    protected abstract void activateMachine();
    protected abstract void deactivateMachine();

}
