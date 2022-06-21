using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public static class PlayerCharacter
{
    public static string ModelName = "man_skeleton";
    public static string playerId = null;
    
}


public class ModelSelect : MonoBehaviour
{

    private GameObject character = null;
    private GameObject contentscharacter;


    private void Start()
    {

        GameObject[] models = GameObject.FindGameObjectsWithTag("Button");
        Button[] modelsbtn = new Button[models.Length];
    
        for (int i = 0; i < models.Length; i++)
        {
            modelsbtn[i] = models[i].GetComponent<Button>();
            
        }
    

        for (int i = 0; i < models.Length; i++)
        {
            int index = i;
            modelsbtn[i].onClick.AddListener(() => ChangeCharacter(models[index].name));
        }


    }

    public void ChangeCharacter(string btnname)
    {
        if (contentscharacter != null)
        {
            Destroy(contentscharacter);
        }
        
        Vector3 spawnPosition = new Vector3(-8.01799965f, 0.181999996f, 61.9199982f);
        Quaternion spawnRotation = new Quaternion(0, 0.406379521f, 0, 0.913704395f);
        character = Resources.Load<GameObject>($"UI_pref/CustomizeChar/{btnname}");
        PlayerCharacter.ModelName = character.name;
        contentscharacter  = Instantiate(character, spawnPosition, spawnRotation);

        //Debug.Log($"PlayerCharacter.ModelName: {PlayerCharacter.ModelName}");



    }


}
