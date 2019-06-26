using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public List<Sprite> Weapons;

    [Space(10)]
    public bool hasBorrito, hasKnife, HasMap, hasFlame, hasPan, hasMep, hasNuke, hasHand, hasBazooka;
    [Space(10)]

    public int index;

    public SpriteRenderer rend;
    Animator anim;
    Vector3 ogPos;

    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();


        ogPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetInteger("ActiveWeapon", Mathf.RoundToInt(activeWeapon));
        //rend.sprite = Weapons[Mathf.RoundToInt(activeWeapon)];
        rend.sprite = Weapons[index];
        //activeWeapon += Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetKeyDown(KeyCode.F) && index != Weapons.Count - 1)
        {
            index++;
            
        }
        if (Input.GetKeyDown(KeyCode.G) && index != 0)
        {
            index--;
        }

        //activeWeapon = Mathf.Clamp(activeWeapon, 0, Weapons.Count);

        if (Input.GetMouseButtonDown(0))
        {
            Throw();
        }

        //if (activeWeapon == 0 && Input.GetMouseButtonDown(0))
        //{
        //    Throw();
        //}

        //if (activeWeapon == 1 && Input.GetMouseButtonDown(0))
        //{
        //    Throw();
        //}

        //if(activeWeapon == 2 && Input.GetMouseButtonDown(0))
        //{

        //}
    }

    Vector3 mousePos()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0;

        return target;
    }

    void ReturnPos()
    {
        transform.position = ogPos;
        anim.SetBool("Attack", false);
    }

    void Throw()
    {
        transform.position = mousePos();
        anim.SetBool("Attack", true);
        Invoke("ReturnPos", 1);

        //Debug.Log(Weapons[Mathf.RoundToInt(activeWeapon)]);
    }


}
