using UnityEngine;

// Damage event for damage at a specific point
public class PointDamageEvent : DamageEvent
{
    public float damage; // Damage done
    public Vector3 hitDirection; // Direction the shot came from. Should be normalized.

    public PointDamageEvent() {}

    public PointDamageEvent(
        float inDamage,
        Vector3 inHitDirection,
        DamageType inDamageTypeClass)
    {
        damage = inDamage;
        hitDirection = inHitDirection;
        damageTypeClass = inDamageTypeClass;
    }
}
