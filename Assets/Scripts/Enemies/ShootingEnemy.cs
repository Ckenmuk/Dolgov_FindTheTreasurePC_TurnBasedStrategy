using System.Collections;
using UnityEngine;

namespace Quest.Enemies
{
    public class ShootingEnemy : Enemy
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnStep = 1f;
        [SerializeField] private float angularSpeed = 1f;
        [SerializeField] private float shootDistance = 500f;


        private Transform player;
        private int playerLayerMask;


        
        private void Awake()
        {
            player = FindObjectOfType<Player.PlayersMovement>().transform;
            playerLayerMask = 1 << player.gameObject.layer;
        }

        private void OnEnable()
        {
            StartCoroutine(ShootRepeat());
        }

        private void LookAtPlayer()
        {
            var direction = player.transform.position - transform.position;
            var rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(rotation);
        }

        private IEnumerator ShootRepeat()
        {
            Debug.DrawRay(spawnPoint.position, spawnPoint.forward, Color.red, shootDistance*2);
            while (enabled)
            {
                LookAtPlayer();
                Shoot();
                yield return new WaitForSeconds(spawnStep);
            }
            yield return null;
        }


        private void Shoot()
        {

            var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            bullet.Init(player.tag);


        }

    }
}