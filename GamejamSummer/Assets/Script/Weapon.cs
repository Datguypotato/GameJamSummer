using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public List<Sprite> Weapons;
    public float activeWeapon;
    public bool hasBorrito;

    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.sprite = Weapons[Mathf.RoundToInt(activeWeapon)];
        activeWeapon += Input.GetAxis("Mouse ScrollWheel");

        activeWeapon = Mathf.Clamp(activeWeapon, 0, Weapons.Count -1);
    }
}
