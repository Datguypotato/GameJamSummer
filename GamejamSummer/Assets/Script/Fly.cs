using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float goldEarn;

    public float speed;
    public float lerpT;
    public bool startLerping;

    float desiredRotationz;
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDir(3));
        manager = GameObject.FindObjectOfType<GameManager>();
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
        Debug.Log("0");
        if (Input.GetMouseButtonDown(0))
        {
            manager.coins += goldEarn;
            Destroy(this.gameObject);
        }
    }

}
