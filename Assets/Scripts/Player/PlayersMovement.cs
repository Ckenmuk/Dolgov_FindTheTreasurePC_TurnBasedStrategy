using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Player
{

    [RequireComponent(typeof(Rigidbody))]
    public class PlayersMovement : MonoBehaviour
    {
        private Vector3 direction;
        private Vector3 rotationDir;

        [SerializeField] private float speed = 5f;
        [SerializeField] private float angularSpeed = 400f;
        [SerializeField] private float runsSpeed = 5f;
        [SerializeField] private float jumpForce = 5f;

        private const string horizontal = "Horizontal";
        private const string vertical = "Vertical";
        private const string running = "Running";
        private const string mouseX = "Mouse X";
        private const string Ground = "Ground";

        private Rigidbody rb;

        private bool isRunning;
        private bool isGround;


        private void Awake()
        {
            rb = GetComponent<Rigidbody>();            
        }

        private void Update()
        {
            direction.x = Input.GetAxis(horizontal);
            direction.z = Input.GetAxis(vertical);
            isRunning = Input.GetButton(running);
            rotationDir.y = Input.GetAxis(mouseX) * angularSpeed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                rb.AddForce(jumpForce * transform.up, ForceMode.Impulse);
            }

            transform.localPosition += direction * (isRunning ? runsSpeed : speed) * Time.deltaTime;
            transform.Rotate(rotationDir);
        }

        private void OnCollisionEnter(Collision collision)
        {
            isGround = collision.gameObject.CompareTag(Ground);
        }

        private void OnCollisionExit(Collision other)
        {
            isGround = !other.gameObject.CompareTag(Ground);
        }
    }
}