using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    public class GetHP : MonoBehaviour
    {
        [SerializeField] private float hp = 50f;

        private void OnCollisionEnter(Collision collision)
        {
            UpHP(collision.gameObject);
        }

        private void UpHP(GameObject collisionGO)
        {
            if (collisionGO.TryGetComponent(out HealthManager health))
            {
                health.Hit(-hp);
            }
            Destroy(gameObject);
        }

    }
}