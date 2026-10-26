using UnityEngine;

public class TargetBuilder : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;
    // Color, point val, hits to break, and spawn location/move dir as components

    public void BuildTarget()
    {
        // Create empty target
        GameObject target = Instantiate(targetPrefab);

        // Set location
        int dir = 1, offset = 0;
        if (Random.Range(0, 2) == 1)
        {
            dir = -1;
            offset = 1;
        }
        target.transform.position = new Vector2(9 * -dir, Random.Range(-1, 3) * 2 - offset);

        // Add movement and set direction
        TargetMovement movement = target.AddComponent<TargetMovement>();
        movement.SetDir(dir);

        // Set color
        target.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));

        // Add hit reciever and set hits to break
        TargetHit hit = target.AddComponent<TargetHit>();
        hit.SetHP(Random.Range(1, 6));

        // Set points recieved on hitting target
        hit.SetPointVal(Random.Range(1, 100));
    }

    private void Start() // Would probably be handled by a Director in a full game but here that would be a waste of an object
    {
        InvokeRepeating(nameof(BuildTarget), 0, 0.5f);
    }
}
