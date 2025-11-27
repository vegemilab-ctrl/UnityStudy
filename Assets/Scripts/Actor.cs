using UnityEngine;

public class Actor : MonoBehaviour
{
    public string actorName;
    public string actorType;
    //활성화될 때마다 위치해 있어야 할 초기 위치, 회전값
    public Vector3 initPosition;
    public Vector3 initRotation;
    public float moveSpeed = 1.0f;
    public float rotateSpeed = 90f;

    //패트롤해야하는 위치값들
    //public Vector3[] movePositions;
    public Transform[] moveTransforms;

    //현재 목적지 순서
    private int _currentIndex = 0;

    private void OnEnable()
    {
        //Debug.Log($"저의 역할은 {actorType}입니다.");
        //transform의 position과 rotation을 변경하면 그 위치, 회전상태로 변경할 수 있음.
        if(moveTransforms.Length > 0)
        {
            //transform의 position에 Vector3타입의 값을 넣어주면 그 위치로 이동함.
            transform.position = moveTransforms[0].position;
        }
        else
        {
            transform.position = initPosition;
        }
        transform.rotation = Quaternion.Euler(initRotation);
    }
    void Start()
    {
        //Debug.Log($"액터의 이름은 {actorName}입니다.");
    }

    // Update is called once per frame
    void Update()
    {
        //지정된 방향으로 원하는 거리만큼 이동하는 함수
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        //현재 회전값에서 목적 회전값까지 최대 회전각도만큼 회전하는 함수(엔터칠 때마다 원하는 방향으로 회전)
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(30, 30, 30)), 90f * Time.deltaTime);


        //현재 위치에서 목적지까지 최대거리만큼 이동하는 함수
        transform.position = Vector3.MoveTowards(transform.position, moveTransforms[_currentIndex].position, moveSpeed * Time.deltaTime);
        
        if(transform.position == moveTransforms[_currentIndex].position)
        {
            UpdateDestination();
        }

        //지정된 축으로 원하는 각도만큼 회전하는 함수
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);

    }

    //InputSystem_Actions에셋에 등록된 Attack에 해당하는 버튼을 누르면 호출됨.
    public void OnAttack()
    {
        //Debug.Log("Enter키 눌렀냐?");
        if (moveTransforms.Length == 0)
            return;

        UpdateDestination();

        //갱신된 목적지로 위치 이동.
        //transform.position = moveTransforms[_currentIndex].position;
    }

    private void UpdateDestination()
    {
        //현재 목적지를 갱신하고
        _currentIndex++;
        if (_currentIndex >= moveTransforms.Length)
        {
            _currentIndex = 0;
        }
    }

}
