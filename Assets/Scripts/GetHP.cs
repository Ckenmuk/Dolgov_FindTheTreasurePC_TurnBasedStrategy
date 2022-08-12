using UnityEngine;

namespace Quest
{
    public class GetHP : MonoBehaviour
    {
        [SerializeField] private int hp = 50;

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