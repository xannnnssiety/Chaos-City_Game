using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    private Camera mainCamera;
    public float speedBall;
    /* public int ballDamage = 20; */ // ����, ��������� ������


    public AudioClip ballSound; // ���� ������
    private AudioSource audioSource; // ��������� ��� ��������������� �����

    private void Start()
    {
        mainCamera = Camera.main;

        // �������� ��������� AudioSource �� ����� �������
        audioSource = GetComponent<AudioSource>();
        // ����������� ���� ������, ������� ����� ����������������
        audioSource.clip = ballSound;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();

        Vector3 cameraDirection = mainCamera.transform.forward;

        ballRigidbody.velocity = cameraDirection * speedBall;

        audioSource.Play();

        Destroy(ball, 5f);
    }

/*    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(ballDamage);
        }
    }*/
}

