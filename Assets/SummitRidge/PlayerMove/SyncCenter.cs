using UnityEngine;

namespace SummitRidge.PlayerMove
{
    public class SyncCenter : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private CharacterController controller;

        private void Update()
        {
            transform.localPosition = controller.center + offset;
        }
    }
}