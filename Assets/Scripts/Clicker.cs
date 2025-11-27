using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class Clicker : MonoBehaviour
{
    //생성시 부모설정
    public Transform parent;
    //생성할 게임오브젝트
    public GameObject ball;
    //클릭하는 카메라
    public Camera cam;
    //발사하는 힘
    public float shootingPower = 1000f;

    //마우스 클릭할 때 받는 콜백함수
    public void OnAttack()
    {
        if (!gameObject.activeSelf)
            return;

        Vector3 pos = Mouse.current.position.ReadValue();
        Ray ray = cam.ScreenPointToRay(pos);
        GameObject go = Instantiate(ball, ray.origin, Quaternion.identity, parent);
        Rigidbody rBody = go.GetComponent<Rigidbody>();
        rBody.AddForce(ray.direction * shootingPower);
    }
}
