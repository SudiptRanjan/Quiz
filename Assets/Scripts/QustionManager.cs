using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager instance;

    public TMP_Text questionText;
    public Button[] optionButtons;

    private QuestionData.Question currentQuestion;

    private void Awake()
    {
        instance = this;
    }

    public void LoadQuestion(QuestionData.Question question)
    {
        currentQuestion = question;

        // Display the question text
        questionText.text = currentQuestion.questionText;

        // Display options on buttons
        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < currentQuestion.options.Length)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<TMP_Text>().text = currentQuestion.options[i];
                int optionIndex = i;
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => OnOptionSelected(optionIndex));
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnOptionSelected(int optionIndex)
    {
        bool isCorrect = (optionIndex == currentQuestion.correctOptionIndex);
        QuizManager.instance.UpdateScore(isCorrect);

        // Notify QuizManager to move to the next question
        QuizManager.instance.LoadNextQuestion();
    }
}
