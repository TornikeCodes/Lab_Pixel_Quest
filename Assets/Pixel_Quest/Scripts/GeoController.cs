using UnityEngine;

public class GeoController : MonoBehaviour {
    // Movement
    public float speed = 4f;                    // Controls player X speed

    // Forces
    public float jumpForce = 10f;               // Y velocity given when jumping
    public float fallForce = 2f;                // Extra gravity applied while falling
    private Vector2 _gravityVector;

    // Capsule
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;

    // Ground Check
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;

    // Water Check
    private bool _waterCheck;
    private string _waterTag = "Water";

    private Rigidbody2D _rigidbody2D;           // Controls player physics
    private SpriteRenderer _spriteRenderer;     // Controls player image

    // Sets gravity vector and connects components
    private void Start() {
        _gravityVector = new Vector2(0, Physics2D.gravity.y);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update() {
        // Get player movement from player button press
        float xMovement = Input.GetAxis("Horizontal");

        // Give the speed to the rigidbody
        _rigidbody2D.velocity = new Vector2(xMovement * speed, _rigidbody2D.velocity.y);

        // Flips the sprite to face the direction of movement
        if (xMovement > 0) { _spriteRenderer.flipX = true; }
        else if (xMovement < 0) { _spriteRenderer.flipX = false; }

        // Checks if player is touching ground
        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position,
            new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal,
            0, groundMask);

        // Checks if player is trying to jump/can jump
        if (Input.GetKeyDown(KeyCode.Space) && (_groundCheck || _waterCheck)) {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }

        // Checks if the gravity should be getting faster
        if (_rigidbody2D.velocity.y < 0 && !_waterCheck) {
            _rigidbody2D.velocity += _gravityVector * (fallForce * Time.deltaTime);
        }
    }

    // Check if player entered water
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(_waterTag)) { _waterCheck = true; }
    }

    // Check if player left water
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag(_waterTag)) { _waterCheck = false; }
    }
}
