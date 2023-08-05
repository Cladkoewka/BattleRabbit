using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float ShotPeriod;
    public float BulletSpeed;
    public Transform BulletSpawn;
    public GameObject BulletPrefab;
    public AudioSource ShotSound;
    public GameObject ShotEffect;
    public ParticleSystem SmokeEffect;

    private float _timer;
    void Update()
    {
        _timer += Time.unscaledDeltaTime;

        if (_timer >= ShotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0;
                Shot();
            }
        }
    }

    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = BulletSpawn.forward * BulletSpeed;
        ShotSound.pitch = Random.Range(0.9f, 1f);
        ShotSound.Play();
        SmokeEffect.Play();
        ShotEffect.SetActive(true);
        Invoke("HideShotEffect", 0.1f);

    }

    private void HideShotEffect()
    {
        ShotEffect.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int bulletsCount)
    {
    }
}
