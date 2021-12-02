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

    //��q���� 1/4
    [Header("�̰���q")] //�b�ˬd���������U���
    public int maxHealth = 5;

    [Header("��e��q"), Range(0, 5)]
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        rubyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // ��q���� 2/4
        currentHealth = maxHealth;
        print("Ruby��e��q���G" + currentHealth);
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

        // ���� �P���m
        rubyPosition = rubyPosition + speed * rubyMove * Time.deltaTime;
        rb.MovePosition(rubyPosition); //�ϥέ���i�沾��

        // ��q����
        
    }

    public void ChangeHealth(int amount)
    {
        //currentHealth = currentHealth + amount; //�[�����-1
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); //�[�����-2
        print("Ruby �̷s����q���G" + currentHealth); //�ˬd�O�_���[��
    }
    
    
}
