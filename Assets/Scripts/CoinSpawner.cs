using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    public float maxTime = 1;
    private float timer = 0;
    public GameObject coin;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newCoin = Instantiate(coin);
        newCoin.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newCoin = Instantiate(coin);
            newCoin.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newCoin, 15);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
