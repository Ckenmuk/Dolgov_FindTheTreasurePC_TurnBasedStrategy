using System.Collections;
using UnityEngine;

namespace Quest.Player
{
    public class PlayerThrowGrenade : MonoBehaviour
    {
        [SerializeField] private Grenade grenadePrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnStep = 3f;
        [SerializeField] private float angularSpeed = .5f;
        [SerializeField] private float shootDistance = 100f;

        private Transform enemy;
        private int enemyLayerMask;



        private void Awake()
        {

            enemy = FindObjectOfType<PlayersMovement>().transform;
            enemyLayerMask = 1 << enemy.gameObject.layer;
        }

        private void OnEnable()
        {
            StartCoroutine(ShootRepeat());
        }

        private void LookAtPlayer()
        {
            var direction = enemy.transform.position - transform.position;
            var rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(rotation);
        }

        private IEnumerator ShootRepeat()
        {
            Debug.DrawRay(spawnPoint.position, spawnPoint.forward, Color.red, shootDistance);
            while (enabled)
            {
               // LookAtPlayer();
                Shoot();
                yield return new WaitForSeconds(spawnStep);
            }
            yield return null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(spawnPoint.position, spawnPoint.forward);
        }

        private void Shoot()
        {
            if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out var hit, shootDistance, enemyLayerMask))
            {
                var grenade = Instantiate(grenadePrefab, spawnPoint.position, spawnPoint.rotation);
                grenade.Init(enemy.tag);
            }

        }

    }
}