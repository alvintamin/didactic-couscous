using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour
{
    public GameObject target;
    public float damping = 1;
    Vector3 offset;
    Vector3 fixedVector = new Vector3(0, 0, 0);

    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = position + fixedVector;
        

        transform.LookAt(target.transform.position);
    }
}








