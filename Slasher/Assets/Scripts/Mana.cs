using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public float CharacterMana = 50;
    public Image ManaPoint;
    public Text Manaprocents;
    public float CurrentMana;
    void OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.name == "Character")
        {
            CharacterMana = CharacterMana + 25;
            CurrentMana = CharacterMana / 100;
            ManaPoint.fillAmount = CurrentMana;
            CurrentMana = CurrentMana * 100;
            Debug.Log(CurrentMana);
            Destroy(gameObject);
            Manaprocents.text = CurrentMana + "%";
        }
    }

    void Update()
    {
        
        Manaprocents.text = CharacterMana + "%";
    }
}
