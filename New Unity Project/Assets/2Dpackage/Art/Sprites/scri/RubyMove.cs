using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ϥέ���i�樤�Ⲿ�ʡB�ʵe����-1�G�i�ϥΰʵe Animator�j
/// </summary>

public class RubyMove : MonoBehaviour
{
    public float moveSpeed; //�ŧi moveSpeed (float ���A)�ܼơA
                            //�Q�� public �i�b #Inspector �]�w���ʳt��

    public Rigidbody2D rb;  //�ŧi rb (���髬�A)�ܼơA�@���i���������󪺭����ܼƽc�l

    //�i�ϥΰʵe Animator 1/3�j
    public Animator rubyAnimator; //�ŧi rubyAnimator (Animator)�ܼơA�@���ʵe�����ܼƽc�l

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //�C���Ұʫ�A�۰ʱ��������󪺭��餸��
                                          //�b������ #Inspector ���O�o���[���餸��

        //�i�ϥΰʵe Animator 2/3�j
        rubyAnimator = GetComponent<Animator>(); //���o�������󪺰ʵe����v����
    }


    // �ϥ� FixedUpdate ���N Update() �i�o���n�����z�ĪG
    void FixedUpdate()
    {
        Vector2 rubyPosition = transform.position; //�ŧi�@�� rubyPosition (�V�q ���A)�ܼơA
                                                   //���������󪺮y�Ц�m
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal == 0 && vertical == 0)
        {
            rubyAnimator.SetTrigger("idle");
        }

        //�i�ϥΰʵe Animator 3/3�j�i�D�q�� moveX, moveY����
        rubyAnimator.SetFloat("moveX", horizontal);
        rubyAnimator.SetFloat("moveY", vertical);
        //�ܧ� rubyPosition �y�СA���O�w�� x�y�С�y�y�� ����m�P�W�U���k����t�X���첾�p��
        //���W Time.deltaTime �N���o��Ǫ��ɶ��t��
        rubyPosition.x += moveSpeed * horizontal * Time.deltaTime;
        rubyPosition.y += moveSpeed * vertical * Time.deltaTime;
        //print(Input.GetAxis("Horizontal")); //�b #Console ������ܥ��k���䪺�ƭ�(��0~1)
        //transform.position = rubyPostion;  //�¤�k���ϥΡA�]���|���ͧݰʦ欰

        rb.MovePosition(rubyPosition);  //�ϥέ��骺 MovePosition()��k�Ӳ��ʨ���
    }



}
