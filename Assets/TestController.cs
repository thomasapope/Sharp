using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : Controller
{
    public Camera cam;
    public float damage;
    public Actor actor;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            //Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("Clicked on " + hit.transform.name);
                
                TestActor ta = hit.transform.GetComponent<TestActor>();
                if (ta != null)
                {
                    ApplyDamage(ta, damage, this, this.actor, typeof(DamageType));
                }
            }
            else
            {
                Debug.Log("Nothing hit");
            }
        }
    }

    public static float ApplyDamage(
        Actor damagedActor, 
        float baseDamage, 
        Controller instigator, 
        Actor damageCauser, 
        System.Type damageTypeClass)
    {
        DamageEvent damageEvent = new DamageEvent(damageTypeClass);
        damagedActor.TakeDamage(baseDamage, damageEvent, instigator, damageCauser);
        return 0;
    }
}
