using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetEmu.Models
{
    public enum State { 
        AnsweredCorrectly,
        AnsweredWrong,
        NotYetAnswered
    }

    public class QuestionModel
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }


        [JsonProperty(PropertyName = "question")]
        public string Question { get; set; }

        [JsonProperty(PropertyName = "correct_answer")]
        public string CorrectAnswer { get; set; }

        [JsonProperty(PropertyName = "wrong_answer")]
        public List<string> WrongAnswer { get; set; }

        [JsonProperty(PropertyName = "state")]
        public State State { get; set; } = State.NotYetAnswered;
    }
}
