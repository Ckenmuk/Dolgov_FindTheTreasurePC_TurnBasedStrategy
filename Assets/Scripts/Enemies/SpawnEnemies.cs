using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Enemies
{

    public class SpawnEnemies : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private float spawnStep = 1f;
        
        private float nextSpawnTime;


        private void Update()
        {
            if (Time.time > nextSpawnTime)
            {
                //gameObject.GetComponent<Transform>().localPosition;                 
                var enemy = Instantiate(enemyPrefab, transform);
                nextSpawnTime = Time.time + spawnStep;
            }

        }
    }

}
