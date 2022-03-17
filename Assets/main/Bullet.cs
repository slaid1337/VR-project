using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float force;
    private AudioSource audioSource;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(0.80f, 1.20f);
        audioSource.Play();
        rigidbody.AddForce(transform.forward * force * 100);
        StartCoroutine(DeleteBullet());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            other.GetComponent<DroneController>().Damage(2);
        }
    }

    private IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}