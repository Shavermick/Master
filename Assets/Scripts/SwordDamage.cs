using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour {

    public Characteristic characteristic;
    //public AIBoss boss;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tyt2");
        if (other.gameObject.tag == "Mob")
        {
            Debug.Log("Tyt");
            float RmdDamage = Random.Range(characteristic.MinPhysicalAttack, characteristic.MaxPhysicalAttack + 1);
            other.GetComponent<AIBoss>().realHP -= (int)RmdDamage;
            Debug.Log("Damag " + RmdDamage);
            Debug.Log("Hp " + other.GetComponent<AIBoss>().realHP);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
