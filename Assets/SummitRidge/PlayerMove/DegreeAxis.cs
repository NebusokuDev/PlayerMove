using System;
using UnityEngine;

namespace SummitRidge.PlayerMove
{
    [Serializable]
    public struct DegreeAxis
    {
        [SerializeField] private float minAxis;
        [SerializeField] private float maxAxis;
        [SerializeField] private bool isClamp;

        private float _current;

        public float Current
        {
            get => _current;
            set => _current = isClamp ? Mathf.Clamp(value, minAxis, maxAxis) : value;
        }

        public DegreeAxis(float minAxis, float maxAxis, bool isClamp)
        {
            this.minAxis = minAxis;
            this.maxAxis = maxAxis;
            this.isClamp = isClamp;

            _current = 0f;
        }

        public Quaternion this[Vector3 axis] => Quaternion.AngleAxis(_current, axis);
    }
}