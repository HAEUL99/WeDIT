using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCharLoad : MonoBehaviour
{
    private GameObject character;
    private GameObject contentscharacter;
    private Animator animator;
    private Animator Lobbyanimator;

    private void Start()
    {
        //spawn
        Vector3 spawnPosition = new Vector3(-8.01799965f, 0.181999996f, 61.9199982f);
        Quaternion spawnRotation = new Quaternion(0, 0.406379521f, 0, 0.913704395f);

        if (PlayerCharacter.ModelName == null)
        {
            character = Resources.Load<GameObject>("UI_pref/CustomizeChar/man_skeleton");
            contentscharacter = Instantiate(character, spawnPosition, spawnRotation);
            animator = contentscharacter.GetComponent<Animator>();
            Lobbyanimator = gameObject.GetComponent<Animator>();
            animator.runtimeAnimatorController = Lobbyanimator.runtimeAnimatorController;
            return;
        }

        character = Resources.Load<GameObject>($"UI_pref/CustomizeChar/{PlayerCharacter.ModelName}");
        contentscharacter = Instantiate(character, spawnPosition, spawnRotation);

        //animator change
        animator = contentscharacter.GetComponent<Animator>();
        Lobbyanimator = gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = Lobbyanimator.runtimeAnimatorController;

        animator = Lobbyanimator;
    }

}
