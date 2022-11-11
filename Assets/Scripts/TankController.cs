using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TankController : MonoBehaviour
{
    [SerializeField]
    Transform barrelRotator;
    [SerializeField]
    Transform Firepoint;
    [SerializeField]
    GameObject BulletFire;
    [SerializeField]
    Sprite inactiefarrow;
    [SerializeField]
    Sprite actiefarrow;
    [SerializeField]
    GameObject turnArrow;
    [SerializeField]
    GameObject barrel;
    [SerializeField]
    GameObject Resumebutton;

    public float felocity = 10f;
    public float movespeed = 3f;
    public int spelerNummer;
    bool isAanDeBeurt = false;
    float arrow;
    public Animator anim;
    void Update()
    {
        if (isAanDeBeurt)
        {
            barrelRotator.RotateAround(Vector3.forward, Input.GetAxis("Vertical") * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject b = Instantiate(BulletFire, Firepoint.position, Firepoint.rotation);
                b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * felocity, ForceMode2D.Impulse);
                //Invoke("WisselBeurt", 0.1f);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                felocity += 1;
                if (spelerNummer == 1)
                {
                    //GameObject.Find("Canvas").GetComponent<ScoreScript>().Player1Power();
                }
                if (spelerNummer == 2)
                {
                    //GameObject.Find("Canvas").GetComponent<ScoreScript>().Player2Power();
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                felocity -= 1;
                if (spelerNummer == 1)
                {
                    //GameObject.Find("Canvas").GetComponent<ScoreScript>().Player1Power();
                }
                if (spelerNummer == 2)
                {
                    //GameObject.Find("Canvas").GetComponent<ScoreScript>().Player2Power();
                }
            }
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * movespeed * Time.deltaTime, 0, 0));
            {
                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    anim.SetBool("Driving", true);
                    barrel.active = false;
                }
                else
                {
                    anim.SetBool("Driving", false);
                    barrel.active = true;
                }
                if (Input.GetAxisRaw("Vertical") != 0)
                {
                    anim.SetBool("Shooting", true);
                }
                else
                {
                    anim.SetBool("Shooting", false);
                }
            }
        }
    }
    void WisselBeurt()
    {
        GameObject.Find("EventSystem").GetComponent<TurnEngine>().WisselBeurt();
    }
    public void ZetActief(bool b)
    {
        if (b == true)
        {
            isAanDeBeurt = true;
            turnArrow.GetComponent<SpriteRenderer>().sprite = actiefarrow;
        }
        else
        {
            isAanDeBeurt = false;
            turnArrow.GetComponent<SpriteRenderer>().sprite = inactiefarrow;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider)
        {
            Invoke("WisselBeurt", 0.1f);
        }
    }
}