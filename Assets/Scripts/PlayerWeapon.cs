using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }


    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;

    }

    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }

    }

    void MoveCrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLasers()
    {
        foreach (GameObject laser in lasers) //trouves le vecteur de direction entre le laser et le point cible, puis calcule la rotation nécessaire pour que le laser pointe vers le point cible. Ensuite, il applique cette rotation au laser.
        {
            Vector3 fireDirection = targetPoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
