using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public InputField userInput;
    public Text gameText;
    public int minValue;
    public int maxValue;
    private int randomNum;
    public Button gameButton;
    private bool isGameWon = false;
   


    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    private void ResetGame()
    {
        if (isGameWon)
        {
            gameText.text = "You won! Guess a number between " + minValue + " and " + (maxValue - 1);
            isGameWon = false;
        }
        
        else
        {
            gameText.text = "Guess a number between " + minValue + " and " + (maxValue - 1);
        }

        userInput.text = "";
        randomNum = GetRandomNumber(minValue, maxValue);
        isGameWon = false;
    }
    
    public void OnButtonClick()
    {
        string userInputValue = userInput.text;

        if (userInputValue != "")
        {
            int answer = int.Parse(userInputValue);

            if (answer == randomNum)
            {
                gameText.text = "Correct!";
                isGameWon = true;
                //gameButton.interactable = false;
                ResetGame();
                Debug.Log("Correct!");
            }

            else if (answer > randomNum)
            {
                gameText.text = "Try lower!";
                Debug.Log("Try lower!");
            }    

            else
            {
                gameText.text = "Try higher!";
                Debug.Log("Try higher!");
            }
        }

        else
        {
            gameText.text = "Please enter a number!";
            Debug.Log("Please enter a number!");
        }
    }

    private int GetRandomNumber(int min, int max)
    {
        int random = Random.Range(min, max);
        Debug.Log("min is " + min);
        Debug.Log("max is " + max);
        return random;
    }

    
}
