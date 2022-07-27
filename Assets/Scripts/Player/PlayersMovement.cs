using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Player
{
    public class PlayersMovement : Player
    {

        private Vector2 direction;
        private Vector2 rotationDir;

        [SerializeField] private float speed = 5f;
        [SerializeField] private float angularSpeed = 400f;
        [SerializeField] private float runsSpeed = 10f;

        private Rigidbody2D rb;



        private const string horizontal = "Horizontal";
        private const string vertical = "Vertical";
        private const string running = "Running";
        private const string mouseX = "Mouse X";

        private bool isRunning;


        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            direction.x = Input.GetAxisRaw(horizontal);
            direction.y = Input.GetAxisRaw(vertical);

            isRunning = Input.GetButton(running);

   //         transform.position += (isRunning ? runsSpeed : speed) * Time.fixedDeltaTime * direction;

        }
        void FixedUpdate()
        {
            rb.MovePosition(rb.position + direction * (isRunning ? runsSpeed : speed) * Time.fixedDeltaTime);
        }
    }
}