using UnityEngine;

namespace SummitRidge.PlayerMove
{
    public class CursorLock : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}