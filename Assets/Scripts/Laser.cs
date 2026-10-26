using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public PlayerShooting player;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 8f);

        if (transform.position.y > 11f)
        {
            Wait();
        }
    }

    public void Wait()
    {
        gameObject.SetActive(false);
        player.ReturnToPool(this);
    }
}
