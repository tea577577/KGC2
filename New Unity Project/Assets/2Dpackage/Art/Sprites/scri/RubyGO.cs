using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyGO : MonoBehaviour
{
    private Vector2 lookDirection;
    private Vector2 rubyPosition;
    private Vector2 rubyMove;

    public Animator rubyAnimator;
    public Rigidbody2D rb;

    public float speed = 3;

    //血量控制 1/4
    [Header("最高血量")] //在檢查器內的輔助顯示
    public int maxHealth = 5;

    [Header("當前血量"), Range(0, 5)]
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        rubyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // 血量控制 2/4
        currentHealth = maxHealth;
        print("Ruby當前血量為：" + currentHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rubyPosition = transform.position;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //print("Horizontal is:" + horizontal);
        //print("Vertical is:" + vertical);

        rubyMove = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(rubyMove.x, 0) || !Mathf.Approximately(rubyMove.y, 0))
        {
            lookDirection = rubyMove;
            lookDirection.Normalize();
        }

        rubyAnimator.SetFloat("Look X", lookDirection.x);
        rubyAnimator.SetFloat("Look Y", lookDirection.y);
        rubyAnimator.SetFloat("Speed", rubyMove.magnitude);

        // 移動 嚕比位置
        rubyPosition = rubyPosition + speed * rubyMove * Time.deltaTime;
        rb.MovePosition(rubyPosition); //使用剛體進行移動

        // 血量控制
        
    }

    public void ChangeHealth(int amount)
    {
        //currentHealth = currentHealth + amount; //加血機制-1
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); //加血機制-2
        print("Ruby 最新的血量為：" + currentHealth); //檢查是否有加血
    }
    
    
}
