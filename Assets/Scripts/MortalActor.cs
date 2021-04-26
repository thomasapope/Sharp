using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortalActor : Actor
{
    public float health = 10f;
    public float armor = 0f;

    public bool isDead = false;


    public override float TakeDamage(
        float damageAmount, 
        DamageEvent damageEvent, 
        Controller instigator, 
        Actor damageCauser) 
    {
        if (armor > damageAmount)
        {
            // Armor is greater than damage. Take all damage in armor
            DamageArmor(damageAmount);
        }
        else
        {
            // Damage is greater than (or equal to) armor. Reduce armor to 0, then apply rest of damage to health.
            if (armor != 0)
            {
                // Don't trigger damage armor unless we actually did damage the armor
                damageAmount -= armor;
                DamageArmor(armor); // Reduces armor by armor, effectively setting it to 0
            }
            DamageHealth(damageAmount, instigator, damageCauser);
        }
        return 0;
    }


    protected virtual void DamageHealth(float damageAmount, Controller instigator, Actor damageCauser)
    {
        if (isDead) return;

        health -= damageAmount;
        Debug.Log("Health damaged for " + damageAmount + " points." + GetStats());

        if(health < 1)
        {
            Die(instigator, damageCauser);
        }
    }


    protected virtual void DamageArmor(float damageAmount)
    {
        armor -= damageAmount;
        Debug.Log("Armor damaged for " + damageAmount + " points." + GetStats());
    }


    public string GetStats()
    {
        return "(" + health + ", " + armor + ")";
    }


    /* Method that handles logic when the actor finally dies
     * Best called at the end of animations
     */
    public virtual void Die(Controller instigator, Actor damageCauser)
    {
        isDead = true;
        Debug.Log(gameObject.name + " was killed by " + instigator.gameObject.name + " with a " + damageCauser.gameObject.name + ".");
        Destroy(gameObject);
    }
}
