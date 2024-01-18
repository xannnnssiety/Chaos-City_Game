using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    private Camera mainCamera;
    public float speedBall;
    /* public int ballDamage = 20; */ // Урон, наносимый шарами


    public AudioClip ballSound; // Звук смерти
    private AudioSource audioSource; // Компонент для воспроизведения звука

    private void Start()
    {
        mainCamera = Camera.main;

        // Получаем компонент AudioSource из этого объекта
        audioSource = GetComponent<AudioSource>();
        // Присваиваем звук смерти, который будет воспроизводиться
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

