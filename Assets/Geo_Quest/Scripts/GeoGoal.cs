using UnityEngine;

public class GeoGoal : MonoBehaviour
{
    // Name of the scene to load when the player touches this goal
    public string nextLevel;
    public float spinSpeed = 45f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
    }
}
