using System;
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

        private Transform player;



        
        private void Start()
        {
            player = FindObjectOfType<Player.PlayersMovement>().transform;
            StartCoroutine(Shoot());
        }


        private void LookAtPlayer()
        {
            var direction = player.transform.position - transform.position;
            var rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(rotation);
        }

        private IEnumerator Shoot()
        {

            while (enabled)
            {
                LookAtPlayer();
                Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                yield return new WaitForSeconds(spawnStep);
            }
            yield return null;
        }

    }
}