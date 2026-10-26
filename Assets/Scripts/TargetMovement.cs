using System;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    int dir;
    const float SPEED = 0.02f;
    const int SIDE = 9;
    public void SetDir(int inDir)
    {
        dir = inDir;
    }

    private void Update()
    {
        transform.Translate(new Vector2(SPEED * dir, 0));

        if (Math.Abs(transform.position.x) > SIDE)
            Destroy(this.gameObject);
    }
}
