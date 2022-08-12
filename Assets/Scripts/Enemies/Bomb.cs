using UnityEngine;

namespace Quest.Enemies
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private int damage = 50;

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