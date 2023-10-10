using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShot : MonoBehaviour
{
    [Header("Projectile Settings")]
    public int shotCount = 10;                   // 발사할 발사체의 수
    public float projectileSpeed = 20f;          // 발사체의 속도
    public float spawnInterval = 10f;            // 각 발사 체크 사이의 간격
    public float fireInterval = 0.5f;            // 개별 발사 간격
    public GameObject projectilePrefab;          // 발사체 프리팹

    private Transform target;                    // 발사체가 추적할 대상
    private Vector3 startingPosition;            // 발사체 시작 위치
    private int shotsFired = 0;                   // 현재 웨이브에서 발사된 발사체 수

    private void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;  // 플레이어 캐릭터의 트랜스폼 찾기
        StartCoroutine(StartShooting());                          // 발사 시작하기

       // gameObject.transform.LookAt(target);                      // 초기에 대상을 바라보기
    }

    private IEnumerator StartShooting()
    {
        while (true)
        {
            startingPosition = transform.position;                // 시작 위치 설정
            shotsFired = 0;                                       // 발사체 수 초기화
            yield return new WaitForSeconds(spawnInterval);       // 다음 발사체 웨이브까지 대기

            StartCoroutine(ShootProjectiles());                    // 발사체 발사 시작

            yield return new WaitForSeconds(fireInterval * shotCount);  // 모든 발사체 발사가 끝날 때까지 대기
        }
    }

    private IEnumerator ShootProjectiles()
    {
        for (int i = 0; i < shotCount; i++)
        {
            gameObject.transform.LookAt(target);                                             // 대상 바라보기

            Vector3 projectileDirection = (target.position - startingPosition).normalized;  // 발사체의 방향 계산
            startingPosition.y += 0.2f;                                                     // 시작 위치를 약간 올리기

            GameObject projectile = Instantiate(projectilePrefab, startingPosition, Quaternion.identity);  // 발사체 생성
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();                          // 발사체의 Rigidbody 가져오기
            projectileRigidbody.velocity = projectileDirection * projectileSpeed;                          // 발사체에 속도 적용
            
            projectile.transform.LookAt(target);                                               // 대상을 바라보도록 회전
            projectile.transform.rotation = Quaternion.LookRotation(projectileDirection);     // 발사체의 회전 설정

            shotsFired++;                                                                      // 발사체 수 증가

            if (shotsFired < shotCount)
                yield return new WaitForSeconds(fireInterval);                                 // 다음 발사까지 대기
        }
    }

}
