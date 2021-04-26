// Base damage type. Should not be used directly.
public class DamageType
{
    public bool causedByWorld; // True if damage is caused by world
    public bool radialDamageVelChange; // When applying radial impulses, whether to treat them as impulse or velocity change
    public float damageFalloff; // Damage falloff for radial damage; 1.0 = linear; 2.0 = square of distance
    public float damageImpulse; // The magnitude of impulse to apply to the Actors damaged by this type
}
