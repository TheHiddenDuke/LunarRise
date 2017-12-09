using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityCoolDown : MonoBehaviour
{

    public string abilityButtonAxisName  = "Skill1";
    

    [SerializeField] public Ability ability;
    [SerializeField] private GameObject skillHolder;
    
    private float coolDownDuration;
    private float nextReadyTime;
    private float coolDownTimeLeft;
    public bool skillSelected = false;
    public DragAndDropItem Itemability;



    public void Initialize(string aButton, GameObject skillHolder)
    {
        Itemability = GetComponent<DragAndDropCell>().GetItem();
        if (Itemability != null)
        {
            Debug.Log("Getting item correctly");
            ability = Itemability.GetComponent<AbilityButtonInfo>().ability;
            if (ability != null)
            {
                Debug.Log("Getting ability correctly");
                abilityButtonAxisName = aButton;
                coolDownDuration = ability.aBaseCoolDown;
                ability.Initialize(skillHolder);

            }




        }
    }

    // Update is called once per frame
    void Update()
    {
        bool coolDownComplete = (Time.time > nextReadyTime);
        if (coolDownComplete)
        {
            
            if (Input.GetButtonDown(abilityButtonAxisName))
            {
                
                if(ability!= null) { 
                    ButtonTriggered();
                Debug.Log("Trigerring right");
                }
            }
        }
        else
        {
            CoolDown();
        }
    }

    

    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(coolDownTimeLeft);
        
    }

    private void ButtonTriggered()
    {
        nextReadyTime = coolDownDuration + Time.time;
        coolDownTimeLeft = coolDownDuration;
        ability.TriggerAbility();
    }
}