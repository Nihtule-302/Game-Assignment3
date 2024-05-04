using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    public float maxDistance;
    public float currentDistance;

    public HealthBar healthBar;
    public DestinationBar destinationBar;
    public Transform destination;

    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        maxDistance = destination.position.z;
        destinationBar.setMaxDistance(maxDistance);
    }

    void Update()
    {
        currentDistance = destination.position.z;
        destinationBar.setDistance(currentDistance);

        if (currentHealth <= 0)
        {
            SceneChanger.changeToGameOverScene();
        }
    }


    public void takeDamage(float damage) 
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
