using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPatrol : MonoBehaviour
{
  

    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;
    [SerializeField] private Animator anim;
    private GameObject coffeegameobject;

    [Header ("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header ("Idle duration")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    void Awake()
    {
        initScale = enemy.localScale;
        /*
          coffeegameobject = GameObject.Find ("CoffeMugEnemy");
        enemy=coffeegameobject.GetComponent<Transform>();
        anim = coffeegameobject.GetComponent<Animator>();
        Debug.Log("ADADADA "+coffeegameobject);
         */
        //enemy ja anim pitää hakea awakessa jos haluis sillee helposti drag & drop

    }

    void OnDisable()
    {
        if(anim != null)
        {
            anim.SetBool("moving", false);
        }
    }

    void FixedUpdate()
    {
        //Tuhotaan tämä, jos itse vihollinen on kuollut. Muuten konsoli täyttyy paskalla.
        if (enemy == null) {Destroy(gameObject); return;}

        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);                    
            }
            else
            {
                // Vaihtaa suuntaa
                DirectionChange();
            }
        } 
        else 
        {
            if(enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);                    
            }
            else
            {
                // Vaihtaa suuntaa
                DirectionChange();
            }
        }

       
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);
        // Kääntyy oikeaan suuntaan
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        // Liikkuminen
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        // Laskee kuinka pitkään vihollinen on ollut päätepisteessä
        idleTimer += Time.deltaTime;
        // Vaihtaa bool-arvoa, jos vihollinen on ollut päätepisteessä pidempään kuin sille asetettu aika
        if(idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }
    }
}