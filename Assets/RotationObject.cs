using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    private Vector3 randomDirection;
    public float speed;    


    private void Start()
    {
        randomDirection = new Vector3(Random.Range(-90f, 90f), Random.Range(-90f, 90f), Random.Range(-90f, 90f));
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            randomDirection = new Vector3(Random.Range(-90f, 90f), Random.Range(-90f, 90f), Random.Range(-90f, 90f));

        }
        transform.LookAt(player.transform);
        transform.RotateAround(target.transform.position, randomDirection, speed * Time.fixedDeltaTime);
        Debug.Log(transform.position - target.transform.position);
        if (Vector3.Angle(target.transform.forward, transform.position - target.transform.position) >= 60f || (transform.position - target.transform.position).y <= -20f)
        {
            randomDirection *= -1;
            StartCoroutine(ChangeDirection());
        }

    }

    private IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(2f);

        randomDirection = new Vector3(Random.Range(-90f, 90f), Random.Range(-90f, 90f), Random.Range(-90f, 90f));
    }
}
