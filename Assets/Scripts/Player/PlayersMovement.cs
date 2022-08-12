using UnityEngine;

namespace Quest.Player
{

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent (typeof(Animator))]
    public class PlayersMovement : Player
    {
        private Vector3 direction;
        private Vector3 rotationDir;

        [SerializeField] private float speed = 3f;
        [SerializeField] private float angularSpeed = 400f;
        [SerializeField] private float runsSpeed = 5f;
        [SerializeField] private float jumpForce = 5f;

        //private const string horizontal = "Horizontal";
        //private const string vertical = "Vertical";
        private const string running = "Running";
        private const string mouseX = "Mouse X";
        private const string Ground = "Ground";

        private Rigidbody rb;
        private Animator animator;

        private bool isRunning;
        private bool isGround;


        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            //direction.x = Input.GetAxis(horizontal);
            //direction.z = Input.GetAxis(vertical);
            isRunning = Input.GetButton(running);
            rotationDir.y = Input.GetAxis(mouseX) * angularSpeed * Time.deltaTime;

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                rb.AddForce((isRunning ? runsSpeed : speed) * transform.forward, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-(isRunning ? runsSpeed : speed) * transform.forward, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                rb.AddForce((isRunning ? runsSpeed : speed) * transform.right, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-(isRunning ? runsSpeed : speed) * transform.right, ForceMode.Force);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                rb.AddForce(jumpForce * transform.up, ForceMode.Impulse);
            }

            //transform.localPosition += direction * (isRunning ? runsSpeed : speed) * Time.deltaTime;
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