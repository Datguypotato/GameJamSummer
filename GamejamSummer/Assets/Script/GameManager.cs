using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Fly> flies;
    public GameObject[] flyPrefab;

    public float spawnDesired;
    public int coins;

    public Text scoreText;
    public GameObject ShopWindow;

    public Sprite[] allweapons;
    Weapon weapons;
    // Start is called before the first frame update
    void Start()
    {
        weapons = GameObject.FindObjectOfType<Weapon>();
        StartCoroutine(CheckFlies());
        SpawnFlies();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = coins.ToString();
    }

    IEnumerator CheckFlies()
    {
        if (GameObject.FindObjectsOfType<Fly>().Length < 3)
        {
            //Debug.Log("ALL FLIES HAS PERISHED");

            SpawnFlies();
        }

        yield return new WaitForSeconds(1);
        StartCoroutine(CheckFlies());
    }

    void SpawnFlies()
    {
        Vector3 randPos = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
        GameObject tempFly = Instantiate(flyPrefab[Random.Range(0, flyPrefab.Length)], randPos, transform.rotation);
        tempFly.transform.eulerAngles += new Vector3(0, 0, Random.Range(0, 300));
    }

    public void ActivateShop()
    {
        ShopWindow.SetActive(!ShopWindow.activeInHierarchy);
    }

    bool CanBuyItem(int cost)
    {
        if (coins >= cost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void BuyBorrito()
    {
        if (CanBuyItem(10) && !weapons.hasBorrito)
        {
            weapons.Weapons.Add(allweapons[0]);
            coins -= 10;
        }
    }

    public void BuySlipper()
    {
        if (CanBuyItem(50))
        {

        }
    }

    public void BuyFlameThrower()
    {
        if (CanBuyItem(100))
        {

        }
    }

    public void BuyNuke()
    {
        if (CanBuyItem(1000))
        {

        }
    }
}
