using UnityEngine;

namespace SummitRidge.PlayerMove
{
    public class KeyboardInput : MonoBehaviour, IMoverInput
    {
        [SerializeField] private KeyCode[] leftKeys = {KeyCode.A};
        [SerializeField] private KeyCode[] rightKeys = {KeyCode.D};
        [SerializeField] private KeyCode[] forwardKeys = {KeyCode.W};
        [SerializeField] private KeyCode[] backKeys = {KeyCode.S};
        [SerializeField] private KeyCode[] jumpKeys = {KeyCode.Space};
        [SerializeField] private KeyCode[] crouchKeys = {KeyCode.LeftControl};
        public float Horizontal() => GetKeyAxis(leftKeys, rightKeys);
        public float Vertical() => GetKeyAxis(backKeys, forwardKeys);
        public bool IsJump() => GetKeyButton(jumpKeys);

        public bool IsCrouch() => GetKeyButton(crouchKeys);

        private float GetKeyAxis(KeyCode[] negative, KeyCode[] positive)
        {
            if (GetKeyButton(negative))
            {
                return -1f;
            }

            if (GetKeyButton(positive))
            {
                return 1f;
            }

            return 0f;
        }

        private bool GetKeyButton(KeyCode[] keyCodes)
        {
            foreach (var keyCode in keyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    return true;
                }
            }

            return false;
        }
    }
}