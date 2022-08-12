using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Grenade : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private int damage = 50;

        private Rigidbody rb;

        private string targetTag;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * speed, ForceMode.Force);
        }

        public void Init(string targetTag)
        {
            this.targetTag = targetTag;
        }


        private void OnCollisionEnter(Collision collision)
        {
            Hit(collision.gameObject);
        }

        private void Hit(GameObject collisionGO)
        {
            if (collisionGO.CompareTag(targetTag) && collisionGO.TryGetComponent(out HealthManager health))
            {
                health.Hit(damage);
            }
            Destroy(gameObject);
        }
    }
}