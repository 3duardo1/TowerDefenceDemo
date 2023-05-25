using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthAmount = 100;

    public void IncreaseHealth(float healthToAdd){
        healthAmount += healthToAdd;
    }

    public void DealDamage(float healthToSubtract){
        healthAmount -= healthToSubtract;
        print("Damage dealt, current is: " + healthAmount);

        if (healthAmount <= 0){
            Die();
        }
    }

    public void Die(){
        Destroy(gameObject);
    }
}
