using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyGO GOGO = collision.GetComponent<RubyGO>();
        print("�I�쪺�F��O�G" + GOGO);
        GOGO.ChangeHealth(-1);
        
    }
}
