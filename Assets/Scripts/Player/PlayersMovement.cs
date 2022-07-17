using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Player
{


    public class PlayersMovement : MonoBehaviour
    {
        private Vector3 direction;
        private Vector3 rotationDir;

        [SerializeField] private float speed = 3f;
        [SerializeField] private float angularSpeed = 300f;
        [SerializeField] private float runsSpeed = 5f;
        
        private const string horizontal = "Horizontal";
        private const string vertical = "Vertical";
        private const string running = "Running";
        private const string mouseX = "Mouse X";



        private bool isRunning;

        private void Start()
        {
        
        }

    
        private void Update()
        {
            direction.x = Input.GetAxis(horizontal);
            direction.z = Input.GetAxis(vertical);

            isRunning = Input.GetButton(running);


            rotationDir.y = Input.GetAxis(mouseX) * angularSpeed * Time.deltaTime;

            transform.localPosition += direction * (isRunning ? runsSpeed : speed) * Time.deltaTime;
            transform.Rotate(rotationDir);
        }
    }
}