using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Quest.Enemies
{

    [RequireComponent(typeof(NavMeshAgent))]
    
    public class PatrolEnemy : Enemy
    {

        [SerializeField] private NavMeshAgent agent;
        private float lookLength = 3f;
        [SerializeField] private Transform[] wayPoints;
        private Transform player;
        private int index;

//        private float height = 2.0f;
//        private float duration = 0.5f;

        private void Start()
        {
            player = FindObjectOfType<Player.PlayersMovement>().transform;
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(wayPoints[0].position);
/*            agent.autoTraverseOffMeshLink = false;
            while (enabled)
            {
                if (agent.isOnOffMeshLink)
                {
                    StartCoroutine(Parabola(agent, height, duration));
                }

            }
*/
        }

        private void Update()
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                index = (index + 1) % wayPoints.Length;
                agent.SetDestination(wayPoints[index].position);
            }

            if ((player.transform.position - transform.position).magnitude < lookLength)
            {

                transform.GetComponent<FollowingEnemy>().enabled = true;
                transform.GetComponent<PatrolEnemy>().enabled = false;
            }
            else
            {
                transform.GetComponent<FollowingEnemy>().enabled = false;
                transform.GetComponent<PatrolEnemy>().enabled = true;
            }

        }

        IEnumerator Parabola (NavMeshAgent agent, float height, float duration)
        {
            OffMeshLinkData data = agent.currentOffMeshLinkData;
            Vector3 startPos = agent.transform.position;
            Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
            float normalisedTime = 0.0f;
            while (normalisedTime < 1.0f)
            {
                float yOffset = height * 4.0f * (normalisedTime - normalisedTime * normalisedTime);
                agent.transform.position = Vector3.Lerp(startPos, endPos, normalisedTime) + yOffset * Vector3.up;
                normalisedTime += Time.deltaTime / duration;
                yield return null;
            }
        }


    }
}