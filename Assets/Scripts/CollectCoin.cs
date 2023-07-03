using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class CollectCoin : MonoBehaviour
{

    public int score = 0;
    [SerializeField] private int winThreshold = 50;

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject endPanel; 
    private Animator playerAnim;

    private void Start() {

        playerAnim = player.GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Coin")) {

            addCoin();
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Finish")) {

            endPanel.SetActive(true);
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self); //chracter should rotate so that we can see its face when game ends
            playerController.StopMoving();
            CheckWinCondition();
        }
    }

    private void CheckWinCondition()
    {

        if (score < winThreshold) {
            //lose
            playerAnim.SetBool("lose", true);

        }
        else {
            //win
            playerAnim.SetBool("win", true);
        }
    }

    private void OnCollisionEnter(Collision other) {
        
        if (other.gameObject.CompareTag("Obstacle"))
        {
            playerAnim.SetBool("lose", true);
            playerController.StopMoving();

            //INFO: Restart Game after 1 seconds
            Invoke("RestartGame", 3);
        }
    }

    public void RestartGame()
    {
        //INFO: Restart Game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void addCoin(){

        score++;

        coinText.text = "Score: " + score.ToString();
    } 
}
