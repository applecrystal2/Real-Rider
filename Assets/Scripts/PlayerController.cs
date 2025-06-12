using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;            // 최대 속도
    public float acceleration = 2f;         // 가속도
    public float rotationTorque = 5f;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            // 마우스를 클릭 중일 때만 힘을 가해 오른쪽으로 가속
            float targetSpeed = moveSpeed;
            float speedDiff = targetSpeed - rb.velocity.x;
            float force = speedDiff * acceleration;
            rb.AddForce(new Vector2(force, 0f), ForceMode2D.Force);

            // 공중에 떠있을 때만 회전 토크 적용
            if (!IsGrounded())
            {
                rb.AddTorque(rotationTorque, ForceMode2D.Force);
            }
        }
        // 클릭하지 않을 때는 물리엔진에 맡김 (관성, 중력, 경사면 모두 자연스럽게 적용)
    }

    // 바닥에 닿아있는지 판정 (간단한 Raycast 사용)
    private bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            GetComponent<Collider2D>().bounds.extents.y + extraHeight,
            LayerMask.GetMask("Default")
        );
        return hit.collider != null;
    }
}
