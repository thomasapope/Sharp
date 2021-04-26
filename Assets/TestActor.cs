using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestActor : MortalActor
{
    public override float TakeDamage(
        float damageAmount, 
        DamageEvent damageEvent, 
        Controller instigator, 
        Actor damageCauser) 
    {
        base.TakeDamage(damageAmount, damageEvent, instigator, damageCauser);

        Debug.Log("DamageType Type is: " + damageEvent.damageTypeClass);
        Debug.Log("DamageType caused by world: " + damageEvent.damageTypeClass.causedByWorld);
        return 0;
    }
}
