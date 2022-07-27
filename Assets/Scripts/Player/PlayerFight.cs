using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Player
{
    public class PlayerFight : Player
    {
        [SerializeField] private GameObject indicator;
        [SerializeField] private GameObject Top;
        [SerializeField] private GameObject Center;
        [SerializeField] private GameObject Bottom;
        

        private float position;


        void Start()
        {

            position = transform.position.y;

        }


        private void Update()
        {
            Moving();
        }


        private void Moving()
        {
            if (position < Center.transform.position.y)
            {
                indicator.GetComponent<SpriteRenderer>().color = new Vector4(255.0f / 255.0f, 165 / 255.0f, 63 / 255.0f, 1);
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.position = Center.transform.position;

                }
                position = transform.position.y;

            }
            else if (position > Center.transform.position.y)
            {

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.position = Center.transform.position;
                }
                position = transform.position.y;
            }
            else if ((position < Top.transform.position.y) && (position > Bottom.transform.position.y))
            {

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.position = Top.transform.position;
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.position = Bottom.transform.position;
                }
                position = transform.position.y;
            }
        }

    }
}