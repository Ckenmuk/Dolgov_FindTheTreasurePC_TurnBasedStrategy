using UnityEngine;

namespace Quest
{
    public class ControlButton : MonoBehaviour
    {
        [SerializeField] private ControlledObject controlledObject;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player.PlayersMovement player))
            {
                Debug.Log(other.name);
                controlledObject.Activate();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player.PlayersMovement player))
            {
                controlledObject.Deactivate();
            }
        }
    }
}