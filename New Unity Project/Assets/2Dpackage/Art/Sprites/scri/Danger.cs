using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyGO GOGO = collision.GetComponent<RubyGO>();
        print("碰到的東西是：" + GOGO);
        GOGO.ChangeHealth(-1);
        
    }
}
