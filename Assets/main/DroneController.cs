using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    [SerializeField] private Transform[] routes;

    private int routToGo;
    private float tParam;
    private Vector3 catPosition;
    [SerializeField] private float speedModifire;
    private bool coroutineAllowed;

    [SerializeField] private int health;


    private void Start()
    {
        routToGo = 0;
        tParam = 0f;
        coroutineAllowed = true;
    }

    private void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routToGo));
        }
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;

        while (tParam < 1)
        {

            tParam += Time.deltaTime * speedModifire;

            catPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;

            transform.position = catPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;
        routToGo += 1;

        if (routToGo > routes.Length - 1)
        {
            routToGo = 0;
        }

        coroutineAllowed = true;
    }

    public void Damage(int damage)
    {
        this.health -= damage;

        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
