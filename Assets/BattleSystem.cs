using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Pokemon playerPokemon;
    public Pokemon enemyPokemon;

    void Start()
    {
        messageText.text = "A wild " + enemyPokemon.pokemonName + " appears!";
        // Add UI elements to select actions (e.g., Attack, Run).
    }

    public void PlayerAttack()
    {
        StartCoroutine(Animation(true));

        if (enemyPokemon.IsAlive())
        {
            // Enemy's turn, implement AI logic.
            StartCoroutine(Animation(false));
        }
        // Check for win/lose conditions.
    }

    public void PlayerRun()
    {
        // Implement run logic.
    }

    public IEnumerator Animation(bool Isplayer)
    {
        Vector3 remember;
        Color originalColor;
        Color blinkColor = Color.red;
        
        float blinkDuration = 2.0f;
        
        if (Isplayer)
        {
            originalColor = playerPokemon.GetComponent<SpriteRenderer>().color;
            remember = playerPokemon.transform.position;
            playerPokemon.Attack(enemyPokemon);
            Vector2 targetPosition = new Vector2(-1,playerPokemon.transform.position.y);
            playerPokemon.transform.position = targetPosition;

            playerPokemon.GetComponent<SpriteRenderer>().color = blinkColor;
        }
        else
        {
            originalColor = enemyPokemon.GetComponent<SpriteRenderer>().color;
            remember = enemyPokemon.transform.position;
            enemyPokemon.Attack(playerPokemon);
            Vector2 targetPosition = new Vector2(1,enemyPokemon.transform.position.y);
            enemyPokemon.transform.position = targetPosition;
            
            enemyPokemon.GetComponent<SpriteRenderer>().color = blinkColor;
        }
        yield return new WaitForSeconds(1f);

        if (Isplayer)
        {
            playerPokemon.transform.position = remember;
            playerPokemon.GetComponent<SpriteRenderer>().color = originalColor;
        }
        else
        {
            enemyPokemon.transform.position = remember;
            enemyPokemon.GetComponent<SpriteRenderer>().color = originalColor;
        }
    }
}
