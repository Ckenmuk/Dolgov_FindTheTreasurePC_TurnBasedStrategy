using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Enemies
{
    public class BulletActions : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;

        private Vector2 direction;

        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }


        void Update()
        {
            direction.x = transform.position.x;
            direction.y = transform.position.y;

            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        }
    }
}