using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int curentHp = 1000;
    [SerializeField]
    private int damage = 1;
    [SerializeField] StatusBar hpBar;

    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        curentHp -= damage;
        if(curentHp < 0)
        {
            GetComponent<CharacterGameOver>().GameOver();
            isDead = true;
        }
        hpBar.SetState(curentHp,maxHp);
    }

    public void RaiseDamage()
    {
        damage++;
    }
    public int GetDamage()
    {
        return damage;
    }
}
