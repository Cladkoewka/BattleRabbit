using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 5;
    public AudioSource AddHealthSound;
    public AudioSource TakeDamageSound;


    private bool _isDamageable = true;
    private HealthUI _healthUI;
    private DamageEffect _damageEffect;
    private Blink _blink;

    private void Awake()
    {
        _healthUI = FindObjectOfType<HealthUI>();
        _damageEffect = FindObjectOfType<DamageEffect>();
        _blink = GetComponent<Blink>();
    }

    private void Start()
    {
        _healthUI.Setup(MaxHealth);
        _healthUI.DisplayHealth(Health);
    }

    public void TakeDamage(int damage)
    {
        if (_isDamageable)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
            _isDamageable = false;
            Invoke("MakeDamageable", 1);
            TakeDamageSound.Play();
            _healthUI.DisplayHealth(Health);
            _damageEffect.StartEffect();
            _blink.StartEffect();
        }
    }

    private void MakeDamageable()
    {
        _isDamageable = true;
    }

    public void AddHealth(int health)
    {
        Health += health;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        AddHealthSound.Play();
        _healthUI.DisplayHealth(Health);
    }

    public void Die()
    {
        SceneManager.LoadScene(0);
        Cursor.visible = true;
    }
}
