using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 50f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRangeMin = -5f;
    [SerializeField] float yClampRangeMax = 5f;

    [SerializeField] float controlPitchFactor = 18f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float rotationSpeed = 10f;

    Vector2 movement;

    void Start()
    {
        
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }


    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);
        float clampedYPos = Mathf.Clamp(rawYPos, yClampRangeMin, yClampRangeMax);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    void ProcessRotation()
    {
        float pitch = -controlPitchFactor * movement.y;
        float roll = -controlRollFactor * movement.x;
        
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
}
