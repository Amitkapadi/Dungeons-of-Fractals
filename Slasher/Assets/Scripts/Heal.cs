using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Heal : MonoBehaviour
{
    public float CharacterHP = 50;
    public Image HP;
    public Text HPprocents;
    
    void OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.name == "Character")
        {
            CharacterHP = CharacterHP + 25;
            float CurrentHP = CharacterHP / 100;
            HP.fillAmount = CurrentHP;
            CurrentHP = CurrentHP * 100;
            Debug.Log(CurrentHP);
            Destroy(gameObject);
            HPprocents.text = CurrentHP + "%";
        }
    }

    void Update()
    {
        HPprocents.text = CharacterHP + "%";
    }
}
