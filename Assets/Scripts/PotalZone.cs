using UnityEngine;
using UnityEngine.SceneManagement;

public class PotalZone: MonoBehaviour
{
    //허용되는 게임오브젝트 이름
    public string allowName = "Player";
    //로드할 씬 이름
    public string nextScene = "Play";
    //다른 콜라이더와 트리거 되는 순간에 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody.gameObject.name == allowName)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}