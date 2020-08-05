using NetEmu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace NetEmu.Services
{
    public class QuestionService
    {
          public static List<QuestionModel> LoadedQuestions { get; set; }

        public static void LoadSampleQuestions() {
            LoadedQuestions = new List<QuestionModel>();

            LoadedQuestions.Add(new QuestionModel() { ID = "-1", Question="This is a sample question, the correct asnwer is sample 1", CorrectAnswer ="Sample 1", WrongAnswer = new List<string>() { "Sample 2", "Sample 3", "Sample 4" }, State = State.NotYetAnswered  });
            LoadedQuestions.Add(new QuestionModel() { ID = "-2", Question = "This is a sample question, the correct asnwer is sample 2", CorrectAnswer = "Sample 2", WrongAnswer = new List<string>() { "Sample 3", "Sample 4", "Sample 5" }, State = State.NotYetAnswered });
            LoadedQuestions.Add(new QuestionModel() { ID = "-3", Question = "This is a sample question, the correct asnwer is sample 3", CorrectAnswer = "Sample 3", WrongAnswer = new List<string>() { "Sample 4", "Sample 5", "Sample 6" }, State = State.NotYetAnswered });
            LoadedQuestions.Add(new QuestionModel() { ID = "-4", Question = "This is a sample question, the correct asnwer is sample 4", CorrectAnswer = "Sample 4", WrongAnswer = new List<string>() { "Sample 5", "Sample 6", "Sample 7" }, State = State.NotYetAnswered });
            LoadedQuestions.Add(new QuestionModel() { ID = "-5", Question = "This is a sample question, the correct asnwer is sample 5", CorrectAnswer = "Sample 5", WrongAnswer = new List<string>() { "Sample 6", "Sample 7", "Sample 8" }, State = State.NotYetAnswered });

        }

        public static void LoadQuestions() {
            var questions = new List<QuestionModel>();
            LoadedQuestions = JsonConvert.DeserializeObject<List<QuestionModel>>(LoadQuestionsAndAnswers()); ;
        }

        private static string LoadQuestionsAndAnswers() {

            var result = string.Empty;
            string fileName = "NetEmu.Data.QEModel.json";
            result = GetResourceStringFromFile(fileName);
            return result;
        }
        private static string GetResourceStringFromFile(string fileName)
        {
            var result = string.Empty;
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream(fileName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
        public static void LoadTestProgress() { 
        
        }

        public static void SaveTestProgress() { 
        
        }

    }
}
