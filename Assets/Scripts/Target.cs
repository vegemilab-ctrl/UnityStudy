using UnityEngine;

public class Target : MonoBehaviour
{
    public int max = 100;

    private Material _material;
    [SerializeField]
    private Color _initColor = Color.white;
    private int _hitCount;

    private void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        _initColor = _material.GetColor("_EmissionColor");
        //_material.DisableKeyword("_EMISSION");
    }

    ////충돌이 감지되면 호출됨.
    private void OnCollisionEnter(Collision collision)
    {
        if (_hitCount == 0)
        {
            _material.EnableKeyword("_EMISSION");
        }

        Color current = _initColor * (++_hitCount / (float)max + 1f);
        _material.SetColor("_EmissionColor", current);
    }



    //public void OnCollisionEnter(Collision collision)
    //{
    //    Color current = (targetColor / 100f) * ++_hitCount;
    //    _material.SetColor("_EmissionColor", current);
}
