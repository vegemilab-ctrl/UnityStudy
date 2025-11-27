using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

//무조건 필요한 컴포넌트가 있을 경우 속성에 원하는 컴포넌트를 넣어서 강제할 수 있다.
//[RequireComponent(typeof(MeshRenderer))]

public class MousePointerReactor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Material _material;
    private Color _initColor;
    public Color enterColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _material.color = enterColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _material.color = _initColor;
    }

    void Start()
    {
        MeshRenderer meshRender = GetComponent<MeshRenderer>();
        if (meshRender == null)
            return;
        
        _material = meshRender.material;
        _initColor = _material.color;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
