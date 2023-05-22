using UnityEngine;

public class Hearth : MonoBehaviour
{
    public GameObject spriteObject;

    private void Awake()
    {
        spriteObject = transform.GetChild(0).gameObject; // Récupère le premier enfant du Hearth comme objet du sprite
    }

    public void RemoveSprite()
    {
        // Désactiver le GameObject contenant le sprite
        spriteObject.SetActive(false);
    }
}