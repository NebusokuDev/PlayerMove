using UnityEngine;

namespace SummitRidge.PlayerMove
{
    public class MouseRotorInput : MonoBehaviour, IRotorInput
    {
        [SerializeField] private float sensitivity = .1f;
        [SerializeField] private string yawAxisName = "Mouse X";
        [SerializeField] private string pitchAxisName = "Mouse Y";

        public float Yaw() => Input.GetAxisRaw(yawAxisName) * sensitivity * .1f / Time.deltaTime;

        public float Pitch() => Input.GetAxisRaw(pitchAxisName) * sensitivity * .1f / Time.deltaTime;
    }
}