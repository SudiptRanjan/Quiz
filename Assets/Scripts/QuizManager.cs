//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using System.Collections.Generic;
//using TMPro;

//public class QuizManager : MonoBehaviour
//{
//    public static QuizManager instance;

//    public GameObject mainMenu;
//    public GameObject quizScreen;
//    public GameObject resultScreen;

//    public TMP_Text scoreText;
//    public TMP_Text categoryText;
//    public Toggle[] categoryToggles; // Assuming you have N toggles for N categories

//    private int currentScore = 0;
//    private int selectedCategoryIndex = -1;

//    private List<QuestionData.Question> currentCategoryQuestions;
//    private int currentQuestionIndex = 0;

//    public QuestionData questionData; // Reference to the Scriptable Object

//    private void Awake()
//    {
//        instance = this;
//    }

//    public void StartQuiz()
//    {
//        mainMenu.SetActive(false);
//        quizScreen.SetActive(true);

//        // Find the selected category
//        for (int i = 0; i < categoryToggles.Length; i++)
//        {
//            if (categoryToggles[i].isOn)
//            {
//                selectedCategoryIndex = i;
//                break;
//            }
//        }

//        if (selectedCategoryIndex != -1)
//        {
//            StartQuizForCategory();
//        }
//        else
//        {
//            Debug.LogError("No category selected!");
//        }
//    }

//    private void StartQuizForCategory()
//    {
//        // Get questions for the selected category from the Scriptable Object
//        currentCategoryQuestions = questionData.allCategories[selectedCategoryIndex].questions;

//        // For simplicity, assume there are 5 questions in each category
//        LoadNextQuestion(); // Load the first question

//        categoryText.text = "Category: " + selectedCategoryIndex;
//    }

//    public void UpdateScore(bool isCorrect)
//    {
//        if (isCorrect)
//        {
//            currentScore++;
//        }
//    }

//    public void EndQuiz()
//    {
//        quizScreen.SetActive(false);
//        resultScreen.SetActive(true);

//        scoreText.text = "Score: " + currentScore + "/" + currentCategoryQuestions.Count;
//        Debug.Log("End");
//    }

//    public void RestartQuiz()
//    {
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//    }

//    public void LoadNextQuestion()
//    {
//        if (currentQuestionIndex < currentCategoryQuestions.Count)
//        {
//            QuestionData.Question nextQuestion = currentCategoryQuestions[currentQuestionIndex];
//            QuestionManager.instance.LoadQuestion(nextQuestion);
//            currentQuestionIndex++;
//        }
//        else
//        {
//            EndQuiz();
//        }

//    }
//}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;

    public GameObject mainMenu;
    public GameObject quizScreen;
    public GameObject resultScreen;

    public TMP_Text scoreText;
    public TMP_Text categoryText;
    public Toggle[] categoryToggles; // Assuming you have N toggles for N categories

    private int currentScore = 0;
    private int selectedCategoryIndex = -1;

    private List<QuestionData.Question> currentCategoryQuestions;
    private int currentQuestionIndex = 0;

    public QuestionData questionData; // Reference to the Scriptable Object

    private void Awake()
    {
        instance = this;
    }

    public void StartQuiz()
    {
        mainMenu.SetActive(false);
        quizScreen.SetActive(true);

        // Find the selected category
        for (int i = 0; i < categoryToggles.Length; i++)
        {
            if (categoryToggles[i].isOn)
            {
                // Ensure only the selected category is on
                selectedCategoryIndex = i;
                categoryToggles[i].interactable = false;
                break;
            }
        }

        if (selectedCategoryIndex != -1)
        {
            StartQuizForCategory();
        }
        else
        {
            Debug.LogError("No category selected!");
        }
    }

    private void StartQuizForCategory()
    {
        // Get questions for the selected category from the Scriptable Object
        currentCategoryQuestions = questionData.allCategories[selectedCategoryIndex].questions;

        // For simplicity, assume there are 5 questions in each category
        LoadNextQuestion(); // Load the first question

        categoryText.text = "Category: " + selectedCategoryIndex;
    }

    public void UpdateScore(bool isCorrect)
    {
        if (isCorrect)
        {
            currentScore++;
        }
    }

    public void EndQuiz()
    {
        quizScreen.SetActive(false);
        resultScreen.SetActive(true);

        scoreText.text = "Score: " + currentScore + "/" + currentCategoryQuestions.Count;
        Debug.Log("End");
    }

    public void RestartQuiz()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextQuestion()
    {
        if (currentQuestionIndex < currentCategoryQuestions.Count)
        {
            QuestionData.Question nextQuestion = currentCategoryQuestions[currentQuestionIndex];
            QuestionManager.instance.LoadQuestion(nextQuestion);
            currentQuestionIndex++;
        }
        else
        {
            EndQuiz();
        }
    }
}
