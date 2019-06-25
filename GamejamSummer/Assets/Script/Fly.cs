using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    int goldEarn;
    public int goldMax;

    public float speed;
    float lerpT;
    bool startLerping;
    public bool isBomb;

    float desiredRotationz;
    GameManager manager;

    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDir(3));
        manager = GameObject.FindObjectOfType<GameManager>();

        goldEarn = Random.Range(1, goldMax);

        if (isBomb)
        {
            Invoke("Explode", 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);

        if (startLerping)
        {
            lerpT += Time.deltaTime;
            transform.Rotate(Vector3.back * speed, desiredRotationz);
        }

        Vector3 pos = transform.position;
        if (pos.x > 13 || pos.y > 7 || pos.x < -13 || pos.y < -7)
        {
            Destroy(this.gameObject);
        }

    }

    IEnumerator ChangeDir(float dir)
    {
        startLerping = false;
        yield return new WaitForSeconds(0.5f);
        lerpT = 0;
        startLerping = true;
        desiredRotationz = Random.Range(-dir, dir);
        yield return new WaitForSeconds(3);
        StartCoroutine(ChangeDir(3));
    }

    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0) && !isBomb)
        {
            Debug.Log("earned " + goldEarn + "gold");
            Instantiate(particle, transform.position, transform.rotation);
            manager.coins += goldEarn;
            Destroy(this.gameObject);
        }

        if (Input.GetMouseButtonDown(0) && isBomb)
        {
            Instantiate(particle, transform.position, transform.rotation);
            manager.coins += -goldEarn;
            Destroy(this.gameObject);
        }
    }
    
    void Explode()
    {
        Instantiate(particle, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
