using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class cylMove : MonoBehaviour {

    public float baseSpeed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float rotateSpeed = 120.0f;

    public int maxStamina = 100;
    private float currentStamina;
    private bool stamRecovery = true;
    private float timeLeft = 0;
    private bool timerActive = false;
    public Slider stamina;

    public Interactable focus;
    private Vector3 yaw;

    public float speedH = 2.0f;
    public float runSpeed = 10.0f;
    private float speed;

    private float lockPos = 0;

    public Button[] actionbuttons = new Button[10];
    AbilityCoolDown abilityCoolDown;
    public Ability[] abilities = new Ability[4];
    public RayCastSkillTrigger rcst;

    private GameObject myInv;
    private GameObject myMenu;
    private GameObject myQuest;
    private GameObject myEquip;
    private GameObject mySkillTree;
    [HideInInspector] public bool changedMenu = false;
    Camera cam;
    PlayerStats playerStats;
    CursorLockMode mouseCursor;

    private Vector3 moveDirection = Vector3.zero;

    Animator anim;

    private void Start()
    {
        cam = Camera.main;
        myInv = GameObject.FindGameObjectWithTag("Inventory");
        myInv.SetActive(false);
        myMenu = GameObject.FindGameObjectWithTag("Menu");
        myMenu.SetActive(false);
        myQuest = GameObject.FindGameObjectWithTag("Quest");
        myQuest.SetActive(false);
        myEquip = GameObject.FindGameObjectWithTag("Equip");
        myEquip.SetActive(false);
        mySkillTree = GameObject.FindGameObjectWithTag("SkillTreeMenu");
        mySkillTree.SetActive(false);

        //abilityCoolDown = GetComponent<AbilityCoolDown>();
        currentStamina = maxStamina;
        playerStats = this.GetComponent<PlayerStats>();
        rcst.GetComponent<RayCastSkillTrigger>();
    }

    void Update()
    {
        
        transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, lockPos);
        if (Input.GetButton("Run") && currentStamina >0)
        {
            speed = runSpeed;
            playerStats.running = true;
        }
        else
        {
            speed = baseSpeed;
            playerStats.running = false;
        }

        Cursor.lockState = mouseCursor;
        mouseCursor = CursorLockMode.Confined;
        yaw = transform.eulerAngles;
        yaw.z = 0;
        transform.eulerAngles = yaw;
        
        if (!Input.GetButton("Fire2"))
        {
            transform.Rotate(0, Input.GetAxis("Rotate") * rotateSpeed * Time.deltaTime, 0);
        }
        

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {

            if (!Input.GetButton("Fire2")) { 
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                
                Cursor.visible = true;
                
            }
            else if (Input.GetButton("Fire2"))
            {
                Cursor.visible = false;
                
                moveDirection = new Vector3(Input.GetAxis("HorizontalMouse2"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
            }
            if (Input.GetButton("Jump") && currentStamina > 0) {
                 
                moveDirection.y = jumpSpeed;
                currentStamina = currentStamina - 1f;
                timeLeft = 1f;
                

            }

                      
        }
        if (Input.GetButtonDown("Skill1"))
        {
            Debug.Log("Right Input");
            abilityCoolDown = actionbuttons[0].GetComponent<AbilityCoolDown>();
            if (abilityCoolDown.GetComponentInChildren<AbilityButtonInfo>() != null)
            {
                rcst.Triggered = true;
                abilityCoolDown.Initialize("Skill1", PlayerManager.instance.player);
            }
            else
            {
                Debug.Log("No ability");
            }

        }
        if (Input.GetButtonDown("SkillTreeMenu"))
        {
            //if (!changedMenu) {
                mySkillTree.SetActive(!mySkillTree.activeSelf);
            //}
                     
            
           
        }

        //Inventory
        if (Input.GetButtonDown("Inventory")){

            myInv.SetActive(!myInv.activeSelf);

        }
        //Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            myMenu.SetActive(!myMenu.activeSelf);
        }
        //QuestLog
        if (Input.GetKeyDown(KeyCode.L))
        {
            myQuest.SetActive(!myQuest.activeSelf);
        }
        //Equipment
        if (Input.GetKeyDown(KeyCode.J))
        {
            myEquip.SetActive(!myEquip.activeSelf);
        }

        

        //Look for interacable
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                    /*if(interactable is EnemyInteraction)
                    {
                        
                        playerStats.attackMode = true;

                    }*/
                }
                else
                {
                    RemoveFocus();
                }
            }
        }
        if (Input.GetButton("Fire2"))
        {
            yaw.z = 0f;
            yaw.y += speedH * Input.GetAxis("Mouse X");
            yaw.x -= speedH * Input.GetAxis("Mouse Y");
            transform.eulerAngles = yaw;
        }


        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);



        //Stamina control

        stamina.value = currentStamina;

        if (stamRecovery)
        {
            if ((Input.GetButtonDown("Jump")) || (Input.GetButton("Run") && Input.GetButton("Vertical")) && currentStamina > 0)
            {
                if (Input.GetButtonDown("Jump")){
                    //currentStamina = currentStamina - 1.0f;
                    //Moved to jump section
                }
                else {
                    currentStamina = currentStamina - 0.5f;
                    timeLeft = 0.5f;
                }
                
            }
            else
            {
                if (timeLeft > 0)
                {
                    timeLeft -= Time.deltaTime;
                }
            }
            if(timeLeft <= 0)
            {
                if (currentStamina < maxStamina)
                {
                    currentStamina = currentStamina + 0.5f;
                    timerActive = false;
                }
            }
            if (currentStamina <= 0)
            {
                speed = 1f;
                if (!timerActive)
                {
                    timeLeft = 5f;
                    timerActive = true;
                }
                
            }
        }


    }

    void SetFocus (Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            
            focus = newFocus;
        }
        focus = newFocus;
        newFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        
        focus = null;
    }
}