using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    // 💡 애니메이션 컴포넌트를 연결할 변수
    private Animator doorAnimator;

    // 💡 Unity 에디터에서 애니메이션 클립 이름을 지정할 변수
    [Header("Animation Clip Names")]
    [Tooltip("문이 열릴 때 재생할 애니메이션 클립의 이름")]
    public string openAnimationName = "Door1";

    [Tooltip("문이 닫힐 때 재생할 애니메이션 클립의 이름")]
    public string closeAnimationName = "Door2";

    private void Awake()
    {
        // 💡 스크립트가 시작될 때, 같은 게임 오브젝트에 있는 Animator 컴포넌트를 가져옵니다.
        doorAnimator = GetComponent<Animator>();
    }

    // --- OnTriggerEnter: 사람이 문에 접근했을 때 (열림) ---
    private void OnTriggerEnter(Collider other)
    {
        // 💡 "Player" 태그를 가진 오브젝트만 문을 열 수 있도록 검사합니다.
        // 플레이어 오브젝트에 "Player" 태그를 꼭 부여해야 합니다.
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 접근 감지: 문 열림");
            // 💡 문 열림 애니메이션을 재생합니다.
            doorAnimator.Play(openAnimationName);
        }
    }

    // --- OnTriggerExit: 사람이 문 영역을 벗어났을 때 (닫힘) ---
    private void OnTriggerExit(Collider other)
    {
        // 💡 "Player" 태그를 가진 오브젝트가 벗어났을 때만 문을 닫습니다.
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 이탈 감지: 문 닫힘");
            // 💡 문 닫힘 애니메이션을 재생합니다.
            doorAnimator.Play(closeAnimationName);
        }
    }
}
