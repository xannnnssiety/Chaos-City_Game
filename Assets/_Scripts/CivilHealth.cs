using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilHealth : MonoBehaviour
{
    public static int cHP = 100;  // Максимальное количество здоровья врага
    private float currentHealth;    // Текущее количество здоровья
    public GameObject explosionPrefab;

    public AudioClip deathSound; // Звук смерти
    private AudioSource audioSource; // Компонент для воспроизведения звука

    private bool isDead = false;




    private void Start()
    {
        // Получаем компонент AudioSource из этого объекта
        audioSource = GetComponent<AudioSource>();
        // Присваиваем звук смерти, который будет воспроизводиться
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

            // Включить анимацию смерти врага
            GetComponent<Animator>().SetTrigger("Die");

            // Воспроизвести звук смерти
            audioSource.Play();


            // Создать и включить эффект взрыва
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2f); // Уничтожить эффект взрыва через 2 секунды

            // Уничтожить врага после анимации смерти (вы можете настроить это в аниматоре)
            Destroy(gameObject, 2f);



        }



    }
}
