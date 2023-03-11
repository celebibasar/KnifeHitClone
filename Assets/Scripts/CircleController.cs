using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    private void Update()
    {
        SetCircleRotation();
        
    }
    private void SetCircleRotation()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

    }
}
