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
        print("�I�쪺�F��O�G" + GOGO);
        GOGO.ChangeHealth(1);
        Destroy(gameObject);
    }
}
