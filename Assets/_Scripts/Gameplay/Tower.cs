using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower : MonoBehaviour
{
    float epsilonValue = Mathf.Epsilon;
    Transform turret; 

    [Header("Tower Settings")]
    [SerializeField] string towerType = "Tower";
    [SerializeField] public int buildCost = 50;
    
    [SerializeField] public GameObject projectilePrefab;
    

    [Header("Weapon Settings")]   
    [SerializeField] float fireRange = 15.0f;
    [SerializeField] float cooldownTime = 1.0f;
    [SerializeField] float cooldownRemaining = 0f;
    
    [Header("Projectile Settings")] 
    [SerializeField] float speed = 30.0f;
    [SerializeField] float damage = 1.0f;
    [SerializeField] float radiusAOE = 0.0f;
    [SerializeField] float radiusDamageFactor = 1.0f;


    /// <summary>
    /// OnMouseUp is called when the user has released the mouse button.
    /// </summary>
    void OnMouseUp()
    {
        // Activate tower upgrade panel
    }


    void Start()
    {
        turret = transform.Find("TowerTurret");

    }

    void Update()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        Enemy closestEnemy = null;
        float scannerRange = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (closestEnemy == null || distanceToEnemy < scannerRange)
            {
                closestEnemy = enemy;
                scannerRange = distanceToEnemy;
            }
        }

        // Failure check
        if (closestEnemy == null)
        {
            Debug.Log("No enemies in range!");
            return; // ABORT ABORT ABORT
        }
        else
        {
            //Debug.Log(closestEnemy.transform.position);
        }

        Vector3 targetPos = closestEnemy.transform.position - this.transform.position;

        // Turret Tracking using range value
        // Stretch Goals: add other angles
        if (targetPos.magnitude <= fireRange)
        {
            Quaternion TowerRot = Quaternion.LookRotation(targetPos);

            float x = 0.0f;
            float y = TowerRot.eulerAngles.y;
            float z = 0.0f;

            turret.rotation = Quaternion.Euler(x, y, z);
        }

        FireOnTarget(closestEnemy, targetPos);

    }

    private void FireOnTarget(Enemy closestEnemy, Vector3 targetPos)
    {
        cooldownRemaining -= Time.deltaTime;
        if (cooldownRemaining <= epsilonValue && targetPos.magnitude <= fireRange)
        {
            cooldownRemaining = cooldownTime;
            FireOnTarget(closestEnemy);
        }
    }

    void FireOnTarget(Enemy enemyTarget){
        // Learning: instantiate bullet (Object obj, Vec3 Position, Quat Rotation)
        GameObject ProjectileObject = Instantiate(projectilePrefab, this.transform.position, this.transform.rotation);

        Projectile bullet = ProjectileObject.GetComponent<Projectile>();

        // Pass relevent data to the projectile
        bullet.target = enemyTarget.transform;
        bullet.speed = this.speed;
        bullet.damage = this.damage;
        bullet.radiusAOE = this.radiusAOE;
        bullet.radiusDamageFactor = this.radiusDamageFactor;
    }


}


