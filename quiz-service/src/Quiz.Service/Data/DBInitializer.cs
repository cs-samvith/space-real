using Quiz.Service.Models;

namespace Quiz.Service.Data
{
    public class DBInitializer
    {
        public static void Initialize(QuizDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Questions.Any())
            {
                return;
            }
            var questions = new Question[] {
            new Question{QnId=1, QnInWords = "In which city did anup and shilpa meet for the first time?", ImageName=null, Option1= "Kollam" , Option2="Chennai", Option3="Trivandrum",Option4="Bangalore",Answer= 2},
            new Question{QnId=2, QnInWords = "Which form of dance Shyam is famous for and won many awards in his school days?", ImageName=null, Option1= "Bharathanatyam" , Option2="NadodiNritham", Option3="Kathakali",Option4="Cinimatic",Answer= 2},
            new Question{QnId=3, QnInWords = "What is the thing that Samith is more excited about?", ImageName=null, Option1= "books" , Option2="food", Option3="dance",Option4="games",Answer= 2},
            new Question{QnId=4, QnInWords = "Name the game that Dinesh never played in his life.", ImageName=null, Option1= "cricket" , Option2="soccer", Option3="rugby",Option4="ping pong",Answer= 3},
            new Question{QnId=5, QnInWords = "Name of the actor with whom surya samvith took a picture once ", ImageName=null, Option1= "siddhique" , Option2="mamukoya", Option3="mukesh",Option4="alammoodan",Answer= 2},
            };

            foreach (Question t in questions)
            {
                context.Questions.Add(t);
            }
            context.SaveChanges();
        }
    }
}
