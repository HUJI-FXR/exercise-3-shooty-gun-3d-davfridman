using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody rb; 
    private bool isGrounded = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MoveFront()
    {
        Vector3 direction = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.forward;
        rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, direction.z * moveSpeed);
    }

    public void MoveBack()
    {
        Vector3 direction = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.back;
        rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, direction.z * moveSpeed);
    }

    public void MoveLeft()
    {
        Vector3 direction = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.left;
        rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, direction.z * moveSpeed);
    }

    public void MoveRight()
    {
        Vector3 direction = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.right;
        rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, direction.z * moveSpeed);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log($"Jumping with force: {jumpForce}");
        }
        else
        {
            Debug.LogWarning("Jump attempted but the character is not grounded.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Character is grounded.");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Character is no longer grounded.");
        }
    }
}