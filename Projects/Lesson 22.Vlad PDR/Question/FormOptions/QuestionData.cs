using System.Collections.Generic;

namespace FormOptions
{
    public class QuestionData
    {
        public string Text { get; set; } = "";
        public string[] Options { get; set; } = new string[0];
        public int CorrectIndex { get; set; } = -1;
        public string ImagePath { get; set; } = "";
    }

    public class CustomTestProject
    {
        public string TestName { get; set; } = "Новий тест";
        public List<QuestionData> Questions { get; set; } = new List<QuestionData>();
    }
}