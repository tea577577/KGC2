using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strawberry : MonoBehaviour
{
    public GameObject pickE;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(pickE, gameObject.transform.position, Quaternion.identity);

        RubyGO GOGO = collision.GetComponent<RubyGO>();
        print("碰到的東西是：" + GOGO);
        GOGO.ChangeHealth(1);
        Destroy(gameObject);
    }
}
