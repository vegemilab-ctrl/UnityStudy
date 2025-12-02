using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public string bParameterName = "IsEntered";
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _animator.SetBool(bParameterName, true);
    }

    private void OnTriggerExit(Collider other)
    {
        _animator.SetBool(bParameterName, false);
    }


}
