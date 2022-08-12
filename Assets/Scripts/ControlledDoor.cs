using System;
using System.Collections;
using UnityEngine;

namespace Quest
{
    [RequireComponent(typeof(Animator))]
    public class ControlledDoor : ControlledObject
    {
        [SerializeField] private Transform door;
        [SerializeField] private Vector3 openedDoor = new Vector3(0f, 90f, 0f);
        [SerializeField] private Vector3 closedDoor = new Vector3(0f, 0f, 0f);
        [SerializeField] private float speed = 1f;
        private Quaternion openedDoorQ;
        private Quaternion closedDoorQ;

        private Animator animator;

        private const float Delta = 5f;

        private void Awake()
        {
            openedDoorQ = Quaternion.Euler(openedDoor);
            closedDoorQ = Quaternion.Euler(closedDoor);

            animator = GetComponent<Animator>();
        }

        public override void Activate()
        {
            //StopAllCoroutines();
            //StartCoroutine(SwitchDoor(openedDoorQ));

            animator.SetBool("isOpened", true);
        
        }

        public override void Deactivate()
        {
            //StopAllCoroutines();
            //StartCoroutine(SwitchDoor(closedDoorQ));
            animator.SetBool("isOpened", false);
        }

        private IEnumerator SwitchDoor(Quaternion targetRotation)
        {
            while (Quaternion.Angle(door.rotation, targetRotation) > Delta)
            {
                door.rotation = Quaternion.Slerp(door.rotation, targetRotation, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            yield return null;
        }
    }
}