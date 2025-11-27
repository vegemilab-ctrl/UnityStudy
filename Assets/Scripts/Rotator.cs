using UnityEngine;

public class Rotator : MonoBehaviour
{

    public Transform target;

    public float rotateSpeed = 90f;
    public Vector3 rotateAxis = Vector3.up;

    private float _distance = 0f;

    void Start()
    {
        if (target == null)
            return;
        //목적지에서 현재 위치를 빼면 목적지를 향하는 방향과 거리를 알 수 있다.
        Vector3 forward = target.position - transform.position;

        //벡터에서 magnitude변수를 이용해 벡터값이 가진 거리를 알 수 있다.

        //LookRotation함수로 목적방향으로 회전시킬 수 있다.
        _distance = forward.magnitude;
        transform.rotation = Quaternion.LookRotation(forward.normalized, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime * rotateAxis, Space.World);

        if(target != null)
            transform.position = target.position + (-transform.forward * _distance);
    }
}
