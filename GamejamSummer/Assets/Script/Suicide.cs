using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Suicide : MonoBehaviour
{
    public bool isVideo;
    

    private void Start()
    {
        if (isVideo)
        {
            Destroy(this.gameObject, 2);
        }
    }

    public void KillSelf()
    {
        Destroy(this.gameObject);
    }
}
