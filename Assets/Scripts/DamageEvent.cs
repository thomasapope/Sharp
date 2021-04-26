// Base damage event
public class DamageEvent
{
    public DamageType damageTypeClass;

    public DamageEvent() {}

    public DamageEvent(DamageType inDamageTypeClass) 
    {
        damageTypeClass = inDamageTypeClass;
    }

    public DamageEvent(System.Type inDamageType) {}
}
