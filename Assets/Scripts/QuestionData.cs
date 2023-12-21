using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewQuestionData", menuName = "Quiz/QuestionData")]
public class QuestionData : ScriptableObject
{
    [System.Serializable]
    public class CategoryQuestions
    {
        public string categoryName;
        public List<Question> questions;
    }

    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] options;
        public int correctOptionIndex;
    }

    public List<CategoryQuestions> allCategories;
}
