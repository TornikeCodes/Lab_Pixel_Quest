using UnityEngine;

public class GeoPlayerColor : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    // Color values in code go from 0 to 1, not 0 to 255
    public Color colorOne = new Color(1f, 0.9f, 0.4f);   // Yellow
    public Color colorTwo = new Color(0.3f, 0.8f, 1f);   // Blue
    public Color colorThree = new Color(1f, 0.4f, 0.7f); // Pink

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = colorOne;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            _spriteRenderer.color = colorOne;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            _spriteRenderer.color = colorTwo;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            _spriteRenderer.color = colorThree;
        }
    }
}
