using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    
    public Transform target;


    // Projectile settings will likely be controlled by the tower in future
    // SerializedField is for prototyping
    [Header("PROTOTYPING Settings")]
    [SerializeField] public float speed = 10.0f;
    [SerializeField] public float damage = 1.0f;
    [SerializeField] public float radiusAOE = 0.0f;
    [SerializeField] public float radiusDamageFactor = 1.0f;
    void Update()
    {
        if (target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - this.transform.localPosition;

        float distanceTravelled = speed * Time.deltaTime; // how far this frame?
        
        // Add rotation if projectile is a missile or laser round maybe
        if (direction.magnitude <= distanceTravelled){
            ProjectileHitTarget();
        }else{
            transform.Translate(direction.normalized * distanceTravelled, Space.World);
            /*
            // Rotation code
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
            */
        }        
    }

    void ProjectileHitTarget(){
        if(radiusAOE == 0){
            target.GetComponent<Enemy>().TakeDamage(damage);
            //Add collision/Hit VFX and Audio here 
        }else{
            Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, radiusAOE);

            foreach (Collider colTarget in enemiesInRange){ 
                Enemy enemy = colTarget.GetComponentInParent<Enemy>();
                if(enemy != null){ 
                    enemy.GetComponent<Enemy>().TakeDamage(damage*radiusDamageFactor);
                    // add explosion VFX and Audio
                } 
            }
        }
        
        Destroy(gameObject);
    }

}















