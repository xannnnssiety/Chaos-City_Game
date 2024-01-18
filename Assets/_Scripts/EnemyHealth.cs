using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyHealth : MonoBehaviour
{
    public static int HP = 100;  // ������������ ���������� �������� �����
    private float currentHealth;    // ������� ���������� ��������
    public GameObject explosionPrefab;

    public AudioClip deathSound; // ���� ������
    private AudioSource audioSource; // ��������� ��� ��������������� �����

    private bool isDead = false;

 


    private void Start()
    {
        // �������� ��������� AudioSource �� ����� �������
        audioSource = GetComponent<AudioSource>();
        // ����������� ���� ������, ������� ����� ����������������
        audioSource.clip = deathSound;

        
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            KillCount.killEnemy += 1;
            PlayerPrefs.SetInt("KillEnemy", KillCount.killEnemy);
            GetComponent<Collider>().enabled = false;
            Die();
            
        }
    }

    void Die()
    {

        if (!isDead)
        {
            isDead = true;

            // �������� �������� ������ �����
            GetComponent<Animator>().SetTrigger("Die");

            // ������������� ���� ������
            audioSource.Play();


            // ������� � �������� ������ ������
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2f); // ���������� ������ ������ ����� 2 �������

            // ���������� ����� ����� �������� ������ (�� ������ ��������� ��� � ���������)
            Destroy(gameObject, 2f);

            
            
        }


        
    }
}
