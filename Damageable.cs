using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    public float health = 10f;
    public float armor = 0f;

    public bool isDead = false;

    public Corpse corpse;
    public Sprite sp;

    // Main damage method.
    // Handles the bulk of damage operations, including deciding how to apply damage based on the damage type.
    public virtual void TakeDamage(float damageAmount, DamageType damageType = DamageType.Standard)
    {
        switch (damageType)
        {
            case DamageType.Standard:
                TakeStandardDamage(damageAmount);
                break;
            default:
                TakeStandardDamage(damageAmount);
                break;
        }
    }

    private void TakeStandardDamage(float damageAmount)
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
            DamageHealth(damageAmount);
        }
    }

    protected virtual void DamageHealth(float damageAmount)
    {
        if (isDead) return;

        health -= damageAmount;
        Debug.Log("Health damaged for " + damageAmount + " points." + GetStats());

        if(health < 1)
        {
            // We're dead, basically

            // We don't want to call OnHealthDepleted more than once, which
            // could occur if the damageable object is hit while the death animation
            // is playing.
            OnHealthDepleted();
        }
        else
        {
            OnDamageTaken();
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

    // Abstract method to describe what is done when this Damageable is hit
    protected abstract void OnDamageTaken();


    protected virtual void OnHealthDepleted()
    {
        Debug.Log("Health depleted.");
        Die(); // Call default die method
    }

    /* Method that handles logic when the actor finally dies
     * Best called at the end of animations
     */
    public virtual void Die()
    {
        Destroy(gameObject);

        if (corpse)
        {
            SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>(); // Get the sprite renderer

            Corpse c = Instantiate(corpse, transform.position, transform.rotation); // Instantiate the corpse
            c.spriteRenderer.sprite = spriteRenderer.sprite; // Change the corpse sprite to the current sprite
            c.spriteRenderer.flipX = spriteRenderer.flipX; // Make sure the sprite is correctly flipped
            c.transform.localScale = transform.localScale; // Make sure the sprite scale is correct
            Destroy(gameObject);
        }
    }
}
