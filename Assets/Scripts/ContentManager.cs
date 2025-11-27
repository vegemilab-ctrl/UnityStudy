using UnityEngine;
using UnityEngine.InputSystem;

public class ContentManager : MonoBehaviour
{
    public GameObject[] contents;
    public Clicker clicker;
    public Mover mover;

    public void OnPress1()
    {
        if(contents.Length == 0 || contents[0] == null)
            return;

        contents[0].SetActive(!contents[0].activeSelf);
        //for (int i = 0; i < contents.Length; i++)
        //{
        //    contents[i].SetActive(i == 0);
        //}
    }

    public void OnPress2()
    {
        if(contents.Length < 2 || contents[1] == null)
            return;
       
        contents[1].SetActive(!contents[1].activeSelf);

        //for (int i = 0; i < contents.Length; i++)
        //{
        //    contents[i].SetActive(i == 1);
        //}
    }

    public void OnAttack()
    {
        clicker.OnAttack();
    }

    public void OnMove(InputValue value)
    {
        mover.OnMove(value);
    }
}
