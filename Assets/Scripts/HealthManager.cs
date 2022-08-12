using UnityEngine;

namespace Quest
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private int curHealth;
        [SerializeField] private GameObject hundreds;
        [SerializeField] private GameObject tens;
        [SerializeField] private GameObject ones;
        [SerializeField] private GameObject tensVLT;
        [SerializeField] private GameObject tensVRT;
        [SerializeField] private GameObject tensVLB;
        [SerializeField] private GameObject tensVRB;
        [SerializeField] private GameObject tensHT;
        [SerializeField] private GameObject tensHC;
        [SerializeField] private GameObject tensHB;
        [SerializeField] private GameObject onesVLT;
        [SerializeField] private GameObject onesVRT;
        [SerializeField] private GameObject onesVLB;
        [SerializeField] private GameObject onesVRB;
        [SerializeField] private GameObject onesHT;
        [SerializeField] private GameObject onesHC;
        [SerializeField] private GameObject onesHB;

        private Animator animator;

        private string ten = "ten";
        private string one = "one";

        private void Awake()
        {
            animator = transform.Find("Numbers").GetComponent<Animator>();
            curHealth = maxHealth;
            hundreds.SetActive(true);
            tens.SetActive(true);
            ones.SetActive(true);
            Numbers(curHealth / 10, ten);
            Numbers(curHealth % 10, one);
        }

        private void Update()
        {

        }

        public void Hit(int damage)
        {
            animator.SetBool("isDamaged", true);
            curHealth -= damage;
            DisplayHP(curHealth);
            if (curHealth <= 0)
            {
                Time.timeScale = 0;
            }
        }

        private void DisplayHP(float hp)
        {
            if (hp == 100)
            {
                hundreds.SetActive(true);
            }
            else
            {
                hundreds.SetActive(false);
            }
            Numbers(hp / 10, ten);
            Numbers(hp % 10, one);
        }

        private void Numbers(float number, string type)
        {
            if (type == ten)
            {
                if (number == 0)
                {
                    tensVLT.SetActive(true);
                    tensVLB.SetActive(true);
                    tensHT.SetActive(true);
                    tensHC.SetActive(false);
                    tensHB.SetActive(true);
                    tensVRT.SetActive(true);
                    tensVRB.SetActive(true);
                }
                else if (number == 1)
                {
                    tensVLT.SetActive(false);
                    tensVLB.SetActive(false);
                    tensHT.SetActive(false);
                    tensHC.SetActive(false);
                    tensHB.SetActive(false);
                    tensVRT.SetActive(true);
                    tensVRB.SetActive(true);
                }
                else if (number == 2)
                {
                    tensVLT.SetActive(false);
                    tensVLB.SetActive(true);
                    tensHT.SetActive(true);
                    tensHC.SetActive(true);
                    tensHB.SetActive(true);
                    tensVRT.SetActive(true);
                    tensVRB.SetActive(false);
                }
                else if (number == 3)
                {
                    tensVLT.SetActive(false);
                    tensVLB.SetActive(false);
                    tensHT.SetActive(true);
                    tensHC.SetActive(true);
                    tensHB.SetActive(true);
                    tensVRT.SetActive(true);
                    tensVRB.SetActive(true);
                }
                else if (number == 4)
                {
                    tensVLT.SetActive(true);
                    tensVLB.SetActive(false);
                    tensHT.SetActive(false);
                    tensHC.SetActive(true);
                    tensHB.SetActive(false);
                    tensVRT.SetActive(true);
                    tensVRB.SetActive(true);
                }
                else if (number == 5)
                {
                    tensVLT.SetActive(true);
                    tensVLB.SetActive(false);
                    tensHT.SetActive(true);
                    tensHC.SetActive(true);
                    tensHB.SetActive(true);
                    tensVRT.SetActive(false);
                    tensVRB.SetActive(true);
                }
                else if (number == 6)
                {
                    tensVLT.SetActive(true);
                    tensVLB.SetActive(true);
                    tensHT.SetActive(true);
                    tensHC.SetActive(true);
                    tensHB.SetActive(true);
                    tensVRT.SetActive(false);
                    tensVRB.SetActive(true);
                }
                else if (number == 7)
                {
                    tensVLT.SetActive(false);
                    tensVLB.SetActive(false);
                    tensHT.SetActive(true);
                    tensHC.SetActive(false);
                    tensHB.SetActive(false);
                    tensVRT.SetActive(true);
                    tensVRB.SetActive(true);
                }
                else if (number == 8)
                {
                    tensVLT.SetActive(true);
                    tensVLB.SetActive(true);
                    tensHT.SetActive(true);
                    tensHC.SetActive(true);
                    tensHB.SetActive(true);
                    tensVRT.SetActive(true);
                    tensVRB.SetActive(true);
                }
                else if (number == 9)
                {
                    tensVLT.SetActive(true);
                    tensVLB.SetActive(false);
                    tensHT.SetActive(true);
                    tensHC.SetActive(true);
                    tensHB.SetActive(true);
                    tensVRT.SetActive(true);
                    tensVRB.SetActive(true);
                }
            }
            else if (type == one)
            {
                if (number == 0)
                {
                    onesVLT.SetActive(true);
                    onesVLB.SetActive(true);
                    onesHT.SetActive(true);
                    onesHC.SetActive(false);
                    onesHB.SetActive(true);
                    onesVRT.SetActive(true);
                    onesVRB.SetActive(true);
                }
                else if (number == 1)
                {
                    onesVLT.SetActive(false);
                    onesVLB.SetActive(false);
                    onesHT.SetActive(false);
                    onesHC.SetActive(false);
                    onesHB.SetActive(false);
                    onesVRT.SetActive(true);
                    onesVRB.SetActive(true);
                }
                else if (number == 2)
                {
                    onesVLT.SetActive(false);
                    onesVLB.SetActive(true);
                    onesHT.SetActive(true);
                    onesHC.SetActive(true);
                    onesHB.SetActive(true);
                    onesVRT.SetActive(true);
                    onesVRB.SetActive(false);
                }
                else if (number == 3)
                {
                    onesVLT.SetActive(false);
                    onesVLB.SetActive(false);
                    onesHT.SetActive(true);
                    onesHC.SetActive(true);
                    onesHB.SetActive(true);
                    onesVRT.SetActive(true);
                    onesVRB.SetActive(true);
                }
                else if (number == 4)
                {
                    onesVLT.SetActive(true);
                    onesVLB.SetActive(false);
                    onesHT.SetActive(false);
                    onesHC.SetActive(true);
                    onesHB.SetActive(false);
                    onesVRT.SetActive(true);
                    onesVRB.SetActive(true);
                }
                else if (number == 5)
                {
                    onesVLT.SetActive(true);
                    onesVLB.SetActive(false);
                    onesHT.SetActive(true);
                    onesHC.SetActive(true);
                    onesHB.SetActive(true);
                    onesVRT.SetActive(false);
                    onesVRB.SetActive(true);
                }
                else if (number == 6)
                {
                    onesVLT.SetActive(true);
                    onesVLB.SetActive(true);
                    onesHT.SetActive(true);
                    onesHC.SetActive(true);
                    onesHB.SetActive(true);
                    onesVRT.SetActive(false);
                    onesVRB.SetActive(true);
                }
                else if (number == 7)
                {
                    onesVLT.SetActive(false);
                    onesVLB.SetActive(false);
                    onesHT.SetActive(true);
                    onesHC.SetActive(false);
                    onesHB.SetActive(false);
                    onesVRT.SetActive(true);
                    onesVRB.SetActive(true);
                }
                else if (number == 8)
                {
                    onesVLT.SetActive(true);
                    onesVLB.SetActive(true);
                    onesHT.SetActive(true);
                    onesHC.SetActive(true);
                    onesHB.SetActive(true);
                    onesVRT.SetActive(true);
                    onesVRB.SetActive(true);
                }
                else if (number == 9)
                {
                    onesVLT.SetActive(true);
                    onesVLB.SetActive(false);
                    onesHT.SetActive(true);
                    onesHC.SetActive(true);
                    onesHB.SetActive(true);
                    onesVRT.SetActive(true);
                    onesVRB.SetActive(true);
                }
            }
        }

    }
}