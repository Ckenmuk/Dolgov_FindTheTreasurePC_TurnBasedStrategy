using UnityEngine;

namespace Quest.Player
{

    public class CameraMoving : MonoBehaviour
    {
        [SerializeField] private float angularSpeed = 300f;

        private Vector3 rotationDir;
        private const string mouseX = "Mouse X";
        private const string mouseY = "Mouse Y";

        void Update()
        {
 //           rotationDir.y = Input.GetAxis(mouseX) * angularSpeed * Time.deltaTime;
            rotationDir.x =  -Input.GetAxis(mouseY) * angularSpeed * Time.deltaTime;
            transform.Rotate(rotationDir);
        }
    }
}