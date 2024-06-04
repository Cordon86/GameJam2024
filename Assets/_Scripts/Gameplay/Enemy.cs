using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
#region Variables
    // per enemy variation settings 
    [Header("Enemy Type")]  // TODO: use this for the stats generation page
    [SerializeField] string enemyType = "Enemy";
    
    [Header("Enemy Settings")]
    [SerializeField] int rewardValue = 1; 
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float health = 5.0f;
    [SerializeField] float damageReduction = 0.0f;  // 0.0 = full damage; 1.0 = no damage

    // Class variables
    
    [SerializeField] GameObject PathObject;
    Transform targetNode;
    int nodeIndex = 0;
#endregion

    //**************************************************

    /*    Node Functions    */
    void GetNextNode(){
        if(nodeIndex < PathObject.transform.childCount) {
            targetNode = PathObject.transform.GetChild(nodeIndex);
        nodeIndex += 1;
        }else{
            Debug.LogWarning("You have attempted to access node "+nodeIndex+" of "+PathObject.transform.childCount+" Nodes!!");    
            return;
        }    
    }

    //***** GamePlay Functions
    void ObjectiveReached(){
        // Process player punishment
        //GameObject.FindObjectOfType<ScoreManger>().ReduceLife(1);
        Destroy(gameObject);
    }

    public void TakeDamage(float damage){        
        health -= damage;
        Debug.Log("Ive taken "+damage+" damage, my health is now:- " + health);
        if (health <= float.Epsilon){
            ProcessDeath();
        }
    }

    void ProcessDeath(){
        // TODO Audio needed here
        
        // TODO create score manager 
        // Add reward to player
        //GameObject.FindObjectOfType<ScoreManger>().gold += rewardValue;
        Destroy(gameObject);
    }

    //**************************************************
    void Start()
    {
        PathObject = GameObject.Find("PrototypePath");
        GetNextNode();
        /*
        if(targetNode == null){
            GetNextNode();
        }
        */
    }// end Start()

    void Update()
    {
        if(targetNode == null){
            GetNextNode();
            if(targetNode == null){     
                // End of path reached; 
                // Cleanup objects and Process scores/lives etc
                ObjectiveReached();
                return;
            }
        }
        
        // Move Enemy towards node
        float distanceTravelled = moveSpeed * Time.deltaTime; // how far this frame?
        Vector3 direction = targetNode.position - this.transform.localPosition;

        // If distance to waypoint is less than travel distance this frame then waypoint reached
        // TODO: Seems this should really be placed elsewhere and/or have better mechanics
        if (direction.magnitude <= distanceTravelled){
            targetNode = null;
        }else{
            transform.Translate(direction.normalized * distanceTravelled, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
        }        
    }// end Update()

}// Class End

