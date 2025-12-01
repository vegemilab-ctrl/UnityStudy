using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //최대 체력
    public int maxHealth = 10;

    //현재 체력
    protected int _currentHp = 0;
    protected Rigidbody _rigidbody;
    //현재 살아있냐
    private bool _isAlive = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentHp = maxHealth;
        _isAlive = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="damage"></param>
    /// <returns>내가 때린 공격으로 죽었냐</returns>

    public bool Hit(int damage)
    {
        if (!_isAlive)
            return true;

        _currentHp = Mathf.Clamp(_currentHp -  damage, 0, maxHealth);
        if(_currentHp == 0)
        {
            Die();
            return true;
        }

        return false;
    }


    protected virtual void Die()
    {
        _isAlive = false; 
    }

    protected IEnumerator Dying()
    {
        yield return new WaitForSeconds(10f);

        Destroy(gameObject);
    }
}
