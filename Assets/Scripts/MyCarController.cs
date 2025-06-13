using UnityEngine;

public class MyCarController : MonoBehaviour
{
    private SurfaceEffector2D surfaceEffector2D;
    private Rigidbody2D rb;
    private bool onGround = false;

    public float jumpForce = 7f;
    public float defaultSpeed = 7f;      // �⺻ �ӵ�
    public float maxSpeed = 15f;         // �ִ� �ӵ�
    public float minSpeed = 2f;          // �ּ� �ӵ�
    public float speedStep = 5f;         // �ӵ� ��ȭ��(����/����)

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<SurfaceEffector2D>(out var effector))
        {
            onGround = true;
            surfaceEffector2D = effector;

            // �浹 �� �⺻ �ӵ��� ����
            surfaceEffector2D.speed = defaultSpeed;
        }
    }

    private void Update()
    {
        if (surfaceEffector2D == null) return;

        // ������ ȭ��ǥ�� ������ ������ �ӵ� ����
        if (Input.GetKey(KeyCode.RightArrow))
        {
            surfaceEffector2D.speed += speedStep * Time.deltaTime;
            surfaceEffector2D.speed = Mathf.Clamp(surfaceEffector2D.speed, minSpeed, maxSpeed);
        }
        // ���� ȭ��ǥ�� ������ ������ �ӵ� ����
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            surfaceEffector2D.speed -= speedStep * Time.deltaTime;
            surfaceEffector2D.speed = Mathf.Clamp(surfaceEffector2D.speed, minSpeed, maxSpeed);
        }
        // �ƹ� Ű�� ������ ������ �⺻ �ӵ��� ����
        else
        {
            surfaceEffector2D.speed = Mathf.MoveTowards(surfaceEffector2D.speed, defaultSpeed, speedStep * Time.deltaTime);
        }

        // ����
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {   
            Jump();
        }
    }

    private void Jump()
    {
        onGround = false;

        if (rb == null) return;

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
