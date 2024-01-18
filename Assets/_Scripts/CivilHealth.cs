using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilHealth : MonoBehaviour
{
    public static int cHP = 100;  // ������������ ���������� �������� �����
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
        cHP -= damageAmount;

        if (cHP <= 0)
        {
            KillCount.killCivil += 1;
            PlayerPrefs.SetInt("KillCivil", KillCount.killCivil);
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
