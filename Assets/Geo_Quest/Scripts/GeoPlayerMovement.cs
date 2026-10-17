using UnityEngine;

public class GeoPlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // A/D and Left/Right arrows are both mapped to the "Horizontal" axis
        float xInput = Input.GetAxis("Horizontal");

        // Only change the x velocity so gravity, bounce pads and water still move us up and down
        _rigidbody2D.velocity = new Vector2(xInput * speed, _rigidbody2D.velocity.y);
    }
}
