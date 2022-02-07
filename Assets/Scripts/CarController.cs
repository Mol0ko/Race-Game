using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using static UnityEngine.InputSystem.InputAction;

namespace RaceGame
{
    public class CarController : MonoBehaviour
    {
        [SerializeField]
        public Rigidbody _rigidBody;
        [SerializeField, Range(1f, 50f)]
        public float speed = 17f;


        private Vector3 rotationRight = new Vector3(0, 30, 0);
        private Vector3 rotationLeft = new Vector3(0, -30, 0);

        public void OnMoveAction(CallbackContext context)
        {
            // https://stackoverflow.com/questions/54832462/car-movement-in-unity/54832937
            var key = ((KeyControl)context.control).keyCode;
            if (key == Key.W)
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (key == Key.S)
                transform.Translate(Vector3.back * speed * Time.deltaTime);

            if (key == Key.D)
            {
                Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime);
                _rigidBody.MoveRotation(_rigidBody.rotation * deltaRotationRight);
            }
            if (key == Key.A)
            {
                Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime);
                _rigidBody.MoveRotation(_rigidBody.rotation * deltaRotationLeft);
            }
        }

        public void OnStopAction(CallbackContext context)
        {

        }
    }
}