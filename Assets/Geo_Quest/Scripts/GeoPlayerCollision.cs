using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoPlayerCollision : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float bounceForce = 15f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Solid objects we bump into, like spikes
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            ReloadLevel();
        }
    }

    // Trigger objects we pass through, like bounce pads and the goal
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Death":
                ReloadLevel();
                break;

            case "Bounce":
                // Launch the player straight up but keep their sideways speed
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, bounceForce);
                break;

            case "Finish":
                SceneManager.LoadScene(other.GetComponent<GeoGoal>().nextLevel);
                break;
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
