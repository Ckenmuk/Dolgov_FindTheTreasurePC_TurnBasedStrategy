using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  namespace1 
{
    public class PlayersMovement : MonoBehaviour
    {
        private Vector3 direction;

        [SerializeField] private float speed = 3f;
        [SerializeField] private float runsSpeed = 5f;

        private const string horizontal = "Horizontal";
        private const string vertical = "Vertical";
        private const string running = "Running";
        private const string jump = "Jump";

        private bool isRunning;

        private void Start()
        {

        }


        private void Update()
        {
            direction.x = Input.GetAxis(horizontal);
            direction.z = Input.GetAxis(vertical);
            direction.y = Input.GetAxis(jump);

            isRunning = Input.GetButton(running);

            transform.position += direction * (isRunning ? runsSpeed : speed) * Time.deltaTime;
        }
    }

}
