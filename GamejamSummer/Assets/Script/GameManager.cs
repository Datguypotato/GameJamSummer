using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    public Weapon weapons;
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
        if (GameObject.FindObjectsOfType<Fly>().Length < spawnDesired)
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

    #region ButtonsFunctions
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

    void BuyItem(int cost, bool weaponCheck, int index)
    {
        if (CanBuyItem(cost) && !weaponCheck)
        {
            weapons.Weapons.Add(allweapons[index]);
            coins -= cost;
            weaponCheck = true;
        }
    }

    public void BuyHand()
    {
        BuyItem(25, weapons.hasHand, 7);
    }

    public void BuyBorrito()
    {
        BuyItem(10, weapons.hasBorrito, 0);
        //if (CanBuyItem(10) && !weapons.hasBorrito)
        //{
        //    weapons.Weapons.Add(allweapons[0]);
        //    coins -= 10;
        //    weapons.hasBorrito = true;
        //}
    }
    public void BuyKnife()
    {
        BuyItem(50, weapons.hasKnife, 1);
    }

    public void BuyFlameThrower()
    {
        BuyItem(100, weapons.hasFlame, 2);

    }

    public void BuyMap()
    {
        BuyItem(200, weapons.HasMap, 3);

    }

    public void BuyPan()
    {
        BuyItem(500, weapons.hasPan, 4);
    }

    public void BuyMepper()
    {
        BuyItem(666, weapons.hasMep, 5);
    }

    public void BuyNuke()
    {
        SceneManager.LoadSceneAsync("EndGame");
    }

    public void BuyBazooka()
    {
        BuyItem(750, weapons.hasBazooka, 8);
    }
    #endregion
}
