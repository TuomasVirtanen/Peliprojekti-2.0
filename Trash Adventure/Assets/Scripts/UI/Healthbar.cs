using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
   /*
   JOKAISTA VIHOLLISTA VARTEN OMA CANVAS PREFAB. (Googlasin, oli ok - ellei jopa suositeltavaa. 
   */

    private Slider healthBar;
    
    [SerializeField]
    private Gradient HPColor;
    [SerializeField]
    private Image fillImage;

   
    public GameObject enemy;
    [SerializeField]
    private Vector3 hoverOffset;

    


    private void Awake()
    {
        healthBar = GetComponentInChildren<Slider>();
        if (healthBar == null)
        {
            Debug.Log("Healhbar Slider not found in " + this);
        }
       
    }
    private void Start()
    {
        Debug.Log("I've been instantiated by: " + enemy);


    }

    private void FixedUpdate()
    {
        //Voi olla null, jos on pelaajahahmo, + parempi että on 1 debug logi kuin 50 per s 
        if(enemy != null) { 
        transform.position = enemy.transform.position + hoverOffset;
        }
    }


    public void setMaxHealth(int health)
    {
        healthBar.maxValue = health;
        setHealth(health);
    }
    
    public void setHealth(int health)
    {
        healthBar.value = health;
        fillImage.color = HPColor.Evaluate(health/healthBar.maxValue);


        if(healthBar.value <= 0) { Destroy(gameObject); }
    }

}
