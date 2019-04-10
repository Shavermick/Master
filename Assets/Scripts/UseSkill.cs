using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSkill : MonoBehaviour {

    public ParticleSystem IttashuraEffect;

    public Image imageIttashure;
    public Text timeBuff;

    public Image imageAssistent;
    public Text timeCD;

    public Skills useSkill;

    public Characteristic attack;
    public NewController controller;

    public GameObject pref;
    public GameObject Assistent;

    public bool useAssistent;

    public bool IttaShura;

    public bool ColdownAssistent;
    float effectItta;
    float coldownAssistent;

    public bool ColdownIttaShura;
    float coldownShura;
   
    void Start () {

        useAssistent = false;
        effectItta = useSkill.buffSkill.durationSkill;
        coldownShura = useSkill.buffSkill.Coldown;

        imageIttashure.gameObject.SetActive(false);
        imageAssistent.gameObject.SetActive(false);

        IttashuraEffect.gameObject.SetActive(false);
    }
	
	void LateUpdate () {

        Assistent = GameObject.Find("wolk");

        if (Input.GetKeyDown(KeyCode.Alpha1) && useSkill.attackSkill.realLvl > 0 && !ColdownAssistent)
        {
            
            if (useAssistent)
            {
                useAssistent = false;
                ColdownAssistent = true;
                Destroy(Assistent);
                attack.MinPhysicalAttack -= useSkill.attackSkill.Attack;
                attack.MaxPhysicalAttack -= useSkill.attackSkill.Attack;

            } else
            {
                GameObject newGO = Instantiate(pref, transform.position, Quaternion.identity);
                newGO.name = "wolk";
                useAssistent = true;
                coldownAssistent = useSkill.attackSkill.Coldown;
                attack.MinPhysicalAttack += useSkill.attackSkill.Attack;
                attack.MaxPhysicalAttack += useSkill.attackSkill.Attack;
                attack.RealMp -= useSkill.attackSkill.manaConst;
                timeCD.text = "";
                imageAssistent.gameObject.SetActive(true);
            }
           
        }

        // КД первого умения
        if (ColdownAssistent)
        {

            coldownAssistent -= 1 * Time.deltaTime;
            timeCD.text =Mathf.Floor(coldownAssistent).ToString();

            if (coldownAssistent <= 0)
            {
                ColdownAssistent = false;
                imageAssistent.gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && useSkill.buffSkill.realLvl > 0 && ColdownIttaShura == false && IttaShura == false)
        {
            IttaShura = true;
            attack.RealMp -= useSkill.buffSkill.manaConst;
            effectItta = useSkill.buffSkill.durationSkill;
            imageIttashure.gameObject.SetActive(true);

            IttashuraEffect.gameObject.SetActive(true);
            IttashuraEffect.Play();
        }

        // Использование второго умения
        if (IttaShura)
        {
            controller.walkSpeed = useSkill.NewWalkSpeed;
            controller.runSpeed = useSkill.NewRunSpeed;
            effectItta -= 1 * Time.deltaTime;

            Debug.Log(effectItta);
            timeBuff.text = effectItta.ToString();
        }

        // кд второго умения
        if (effectItta <= 0)
        {
            IttaShura = false;
            controller.walkSpeed = 5;
            controller.runSpeed = 10;
            coldownShura -= 1 * Time.deltaTime;
            ColdownIttaShura = true;
            timeBuff.text = Mathf.Floor(coldownShura).ToString();

            IttashuraEffect.gameObject.SetActive(false);

            if (coldownShura <= 0)
            {
                ColdownIttaShura = false;
                imageIttashure.gameObject.SetActive(false);
            }
        }
    }
}