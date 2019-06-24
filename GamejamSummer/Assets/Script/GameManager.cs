using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Fly> flies;
    public GameObject[] flyPrefab;

    public float spawnDesired;
    public float coins;

    public Text scoreText;
    public GameObject ShopWindow;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckFlies());
        SpawnFlies(3);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = coins.ToString();
    }

    IEnumerator CheckFlies()
    {
        if(GameObject.FindObjectsOfType<Fly>().Length < 0)
        {
            //Debug.Log("ALL FLIES HAS PERISHED");

            SpawnFlies(3);
        }

        yield return new WaitForSeconds(3);
        StartCoroutine(CheckFlies());
    }

    void SpawnFlies(float spawnAmount)
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 randPos = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
            GameObject tempFly = Instantiate(flyPrefab[Random.Range(0,flyPrefab.Length)], randPos, transform.rotation);
            tempFly.transform.eulerAngles += new Vector3(0, 0, Random.Range(-4, 4));

        }
    }

    public void ActivateShop()
    {
        ShopWindow.SetActive(!ShopWindow.activeInHierarchy);
    }
}
