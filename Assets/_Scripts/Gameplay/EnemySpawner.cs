using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float spawnRate = 0.4f;
    float cooldownRemaining = 5.0f;

    [System.Serializable] 
    public class Wave {
        public GameObject enemyPrefab;
        public int num;

        [System.NonSerialized]
        public int spawned;
    }

    public Wave[] wave;

    bool activateWave = false;


    // Update is called once per frame
    void Update()
    {  
        
        // Wave triggered
        if (activateWave == true){
            // TODO: Add a coundown timer to UI
            // start the cooldown
            cooldownRemaining -= Time.deltaTime;

            //check for cooldown complete
            if (cooldownRemaining <= float.Epsilon){

                // set smaller cooldown for per enemy in wave
                spawnRate = Random.Range(0.1f, 2.0f);
                cooldownRemaining = spawnRate;
                
                bool didSpawn = false;

                // let loose the dogs of war
                foreach(Wave w in wave){
                    if (w.spawned < w.num){

                        w.spawned++;

                        // use position and orientation of the spawner 
                        Instantiate(w.enemyPrefab, this.transform.position, this.transform.rotation);
                        didSpawn = true;
                        break;

                    }
                }

                // moving on....
                if(didSpawn == false){
                    // end of wave
                    // start next wave?

                    if(transform.parent.childCount > 1){
                        transform.parent.GetChild(1).gameObject.SetActive(true);

                    }else{
                        //gameover
                    }
                    
                    Destroy(gameObject);
                }
            }
        }
        
    }

    public void SetWaveActive(){
        activateWave = true;
        //return activateWave;
    }

}
