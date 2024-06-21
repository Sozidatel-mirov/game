using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float jumpStrength = 5f;
   [SerializeField] private float maxGroundDistance = 0.3f;

    private Rigidbody rb;
    private Transform groundCheckObject;

    private bool isgrounded;

    [SerializeField] private float speed = 5f;
    private Vector2 velocity;

    Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        groundCheckObject = GameObject.FindGameObjectWithTag("GroundCheck").transform;
        animator = transform.GetChild(2).GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ���������� ����������� �������� � ������� ������������
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        // ����������� ��������� ����������� �������� � �������
        moveDirection = transform.TransformDirection(moveDirection);

        // ������������� �������� ����
        animator.SetBool("isRunning", moveDirection.magnitude > 0);

        // ���������� ��������� ����
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 7f;
        }
        else
        {
            speed = 5f;
        }

        // ������� ������ � ��������� ����������� � ������ ��������
        rb.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);

        // ���������, ��������� �� ����� �� �����
        isgrounded = Physics.Raycast(groundCheckObject.transform.position, Vector3.down, maxGroundDistance);

        // ���� ����� ����� ������ � ����� �� �����, �� �������
        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            rb.AddForce(Vector3.up * 100 * jumpStrength);
        }
    }
}
