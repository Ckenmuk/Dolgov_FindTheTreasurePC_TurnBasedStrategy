using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Quest.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class FollowingEnemy : Enemy
    {
        private NavMeshAgent agent;
        private float walkStep = 0.2f;

        private Transform player;
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            player = FindObjectOfType<Player.PlayersMovement>().transform;
            StartCoroutine(Walk());
        }

        private void Update()
        {
            if (NavMesh.SamplePosition(agent.transform.position, out NavMeshHit hit, .2f, NavMesh.AllAreas))
            {
                Debug.Log(NavMesh.GetAreaCost((int)Mathf.Log(hit.mask, 2))); // Mathf.Log(hit.mask, 2) - перевод в десятиричное число 
            }
        }

        private IEnumerator Walk()
        {
            while (enabled)
            {
                agent.SetDestination(player.position);
                yield return new WaitForSeconds(walkStep);
            }

            yield return null;
        }
    }
}