using UnityEngine;

namespace SummitRidge.PlayerMove
{
    public class Rotor : MonoBehaviour
    {
        [SerializeField] private DegreeAxis yaw = new(0f, 0f, false);
        [SerializeField] private DegreeAxis pitch = new(-89f, 89f, true);

        private Transform _self;
        private IRotorInput _input;

        private void Awake()
        {
            _self = transform;
            _input = GetComponent<IRotorInput>();
        }

        private void Update()
        {
            yaw.Current += _input.Yaw();
            pitch.Current += _input.Pitch();

            _self.localRotation = yaw[Vector3.up] * pitch[Vector3.left];
        }
    }
}