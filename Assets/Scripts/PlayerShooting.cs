using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviour
{
    const int BULLETNUM = 6;
    [SerializeField] GameObject laserPrefab;

    private bool canShoot = true;

    private PlayerInput input;

    private List<Laser> laserPool = new List<Laser>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();

        // Spawn bullets for pool
        for (int i = 0;  i < BULLETNUM; i++)
        {
            Laser newlaser = Instantiate(laserPrefab, Vector3.zero, Quaternion.identity).GetComponent<Laser>();
            newlaser.player = this;
            newlaser.Wait(); // It will add itself to the pool when waiting
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    void Shooting()
    {
        if (input.GetShooting() && canShoot)
        {
            // Get and activate laser from pool
            Laser laser = laserPool[0];
            laser.transform.position = transform.position + new Vector3(0, 1, 0);
            laser.gameObject.SetActive(true);
            laserPool.Remove(laser);

            // Start cooldown
            canShoot = false;
            StartCoroutine("Cooldown");
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.4f);
        canShoot = true;
    }

    public void ReturnToPool(Laser laser)
    {
        laserPool.Add(laser);
    }
}
