using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Enemies
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float damage = 50f;

        private void OnCollisionEnter(Collision collision)
        {
            Hit(collision.gameObject);
        }

        private void Hit(GameObject collisionGO)
        {
            if (collisionGO.TryGetComponent(out HealthManager health))
            {
                health.Hit(damage);
            }
            Destroy(gameObject);
        }
    }
}