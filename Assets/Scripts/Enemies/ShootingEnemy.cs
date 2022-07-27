using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Enemies
{
    public class ShootingEnemy : Enemy
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnStep = 1f;
        [SerializeField] private float angularSpeed = .5f;

        private float nextSpawnTime;
        private Transform player;
        private float lookLength = 5f;
        private float lifeTime = 100f;

        void Start()
        {
            player = FindObjectOfType<Player.PlayersMovement>().transform;
        }

        void Update()
        {
            //LookAtPlayer();
            //transform.LookAt(player.position);
           // transform.Rotate(0, 0, 0);
            transform.right = player.position - transform.position;
            Shoot();
        }

        private void LookAtPlayer()
        {
            var direction = player.transform.position - transform.position;
            var rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(rotation);

        }


        private void Shoot()
        {

            if (nextSpawnTime < Time.time)
            {
                var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                nextSpawnTime++;

                Destroy(bullet, lifeTime * Time.deltaTime);
            }
        }


    }
}