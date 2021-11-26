using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator anim;
    [SerializeField]private int animint = 0;
    public GameObject[] menubuttons = new GameObject[3];
    private float time = 1f;
    void Start()
    {
        anim = GetComponent<Animator>();
        animint = anim.GetInteger("Camerapos");
        menubuttons[1].SetActive(false);
        menubuttons[0].SetActive(false);
        menubuttons[2].SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            animint = animint + 1;
           
        }
        anim.SetInteger("Camerapos", (animint));
        if (animint >= 4)
        {
            animint = 1;
        }
        if (animint == 0)
        {
            menubuttons[0].SetActive(true);
            menubuttons[1].SetActive(false);
            menubuttons[2].SetActive(false);
        }
        if (animint == 1)
        {
            menubuttons[0].SetActive(false);
            menubuttons[1].SetActive(true);
            menubuttons[2].SetActive(false);
        }
        if (animint == 2)
        {
            menubuttons[0].SetActive(false);
            menubuttons[1].SetActive(false);
            menubuttons[2].SetActive(true);
        }
        if (animint == 3)
        {
            menubuttons[0].SetActive(true);
            menubuttons[1].SetActive(false);
            menubuttons[2].SetActive(false);
        }
    }
   
    
      
    
    
   
}
