using UnityEngine;

namespace SummitRidge.PlayerMove
{
    public class BottomOffset : MonoBehaviour
    {
        private CharacterController _controller;


        private void Awake() => _controller = GetComponent<CharacterController>();

        private void Update() => Alignment();

        private void Alignment()
        {
            _controller.center = Vector3.up * _controller.height / 2f;
        }
    }
}