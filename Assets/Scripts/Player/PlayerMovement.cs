using UnityEngine;

namespace CoreBreach.Player
{
    [RequireComponent(typeof(Rigidbody))] //rigidbody based movement
    public class PlayerMovement: MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] private float rotationSpeed = 10f;

        private Rigidbody rb;
        private Vector3 movementInput;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal"); // a,d movements left right
            float vertical = Input.GetAxisRaw("Vertical"); // w,s movements forward back

            movementInput = new Vector3(horizontal, 0f, vertical).normalized; //3D movement vector
        }
    }
}