using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTestV3 : MonoBehaviour
{
    
    public float moveSpeed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rubyMove = transform.position;
        rubyMove.x = rubyMove.x + Input.GetAxis("Horizontal") * moveSpeed;
        rubyMove.y = rubyMove.y + Input.GetAxis("Vertical") * moveSpeed;
        transform.position = rubyMove;
        rb.MovePosition(rubyMove);
    }
}