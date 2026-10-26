using System;
using UnityEngine;
using static ScoreObserver;

public class TargetHit : MonoBehaviour
{
    int HP, pointVal;
    public delegate void AddScoreDel(int points);
    public static event AddScoreDel AddEvent;

    public void SetHP(int value)
    {
        HP = value;
    }

    public void SetPointVal(int value)
    {
        pointVal = value;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Laser"))
            return;

        collider.GetComponent<Laser>().Wait();
        AddEvent?.Invoke(pointVal);
        HP -= 1;
        if (HP <=  0)
        {
            Destroy(this.gameObject);
        }
    }
}
