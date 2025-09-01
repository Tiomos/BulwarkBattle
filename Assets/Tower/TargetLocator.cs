using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
   [SerializeField] Transform weapon;
   [SerializeField] ParticleSystem projectileParticle;
   [SerializeField] float range = 15f;
    Transform target;

    void Update()
    {
        FindClosetsTarget();
        AimWeapon();
    }

    void FindClosetsTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closetsTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            
            if(targetDistance < maxDistance)
            {
                closetsTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closetsTarget;
    }

    void AimWeapon()
    {
        float targetDistance= Vector3.Distance(transform.position,target.position);
        
        weapon.LookAt(target);
        
        if(range >= targetDistance)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }

    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
