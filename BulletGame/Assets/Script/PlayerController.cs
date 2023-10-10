using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Setting")]

    private Rigidbody PRb;
    public float speed = 8f;
    public FloatingJoystick joy;

    // 플레이어 영역 설정
    [Header("Move Area Setting")]

    public float minX = -15f;
    public float maxX = 15f;
    public float minZ = -20f;
    public float maxZ = 20f;

    void Start()
    {
        PRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 조이스틱 입력 제어
        float xInput = joy.Horizontal;
        float zInput = joy.Vertical;

        // 입력 속도 지정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        PRb.velocity = newVelocity;
    }

    void LateUpdate()
    {
        // 입력을 받아 이동 범위 내에서만 이동
        float clampedX = Mathf.Clamp(transform.position.x + PRb.velocity.x * Time.deltaTime, minX, maxX);
        float clampedZ = Mathf.Clamp(transform.position.z + PRb.velocity.z * Time.deltaTime, minZ, maxZ);

        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }

    public void Die()
    {
        gameObject.SetActive(false);

        // gameManager 게임 종료
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}