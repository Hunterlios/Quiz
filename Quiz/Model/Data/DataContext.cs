using Quiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model.Data
{
    internal class DataContext
    {
        public static void CreateQuiz(CreateQuestionViewModel model)
        {
            using (var conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Open();

                //Adding a quiz
                string insertQuizSql = "INSERT INTO Quizes (Name) VALUES (@name);";
                var insertQuizCommand = new SQLiteCommand(insertQuizSql, conn);
                insertQuizCommand.Parameters.AddWithValue("@name", model.QuizName);
                insertQuizCommand.ExecuteNonQuery();

                //Getting ID of added quiz
                string selectQuizSql = "SELECT ID FROM Quizes WHERE Name = @name;";
                var selectQuizCommand = new SQLiteCommand(selectQuizSql, conn);
                selectQuizCommand.Parameters.AddWithValue("@name", model.QuizName);
                int quizId = Convert.ToInt32(selectQuizCommand.ExecuteScalar());

                //Adding questions and answers
                foreach (var question in model.creatingQuiz.questions)
                {
                    //Adding questions
                    string insertQuestionSql = "INSERT INTO Questions (ID, Text, A, B, C, D, IsCorrect, QuizID) VALUES (@questionId, @text, @answerA, @answerB, @answerC, @answerD, @isCorrect, @quizId);";
                    var insertQuestionCommand = new SQLiteCommand(insertQuestionSql, conn);
                    insertQuestionCommand.Parameters.AddWithValue("@text", question.TheQuestion);
                    insertQuestionCommand.Parameters.AddWithValue("@answerA", question.AnswerA);
                    insertQuestionCommand.Parameters.AddWithValue("@answerB", question.AnswerB);
                    insertQuestionCommand.Parameters.AddWithValue("@answerC", question.AnswerC);
                    insertQuestionCommand.Parameters.AddWithValue("@answerD", question.AnswerD);
                    insertQuestionCommand.Parameters.AddWithValue("@correctAnswer", question.CorrectAnswer);
                    insertQuestionCommand.Parameters.AddWithValue("@questionId", question.Id);
                    insertQuestionCommand.Parameters.AddWithValue("@quizId", quizId);
                    insertQuestionCommand.ExecuteNonQuery();

                    //Getting ID of added questions
                    string selectQuestionSql = "SELECT last_insert_rowid();";
                    var selectQuestionCommand = new SQLiteCommand(selectQuestionSql, conn);
                    int questionId = Convert.ToInt32(selectQuestionCommand.ExecuteScalar());
                }
                conn.Close();
            }
        }

        public static void RemoveQuiz(int quizId)
        {

            RemoveQuestions(quizId);
            using (var conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Open();

                //Removing Quiz
                using (var command = new SQLiteCommand("DELETE FROM Quizes WHERE ID = @quizId", conn))
                {
                    command.Parameters.AddWithValue("@quizId", quizId);
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public static void RemoveQuestions(int quizId)
        {
            using (var conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Open();

                //Removing Answers
                using (var command = new SQLiteCommand("DELETE FROM Answers WHERE QuestionID IN (SELECT ID FROM Questions WHERE QuizID = @quizId)", conn))
                {
                    command.Parameters.AddWithValue("@quizId", quizId);
                    command.ExecuteNonQuery();
                }

                //Removing Questions
                using (var command = new SQLiteCommand("DELETE FROM Questions WHERE QuizID = @quizId", conn))
                {
                    command.Parameters.AddWithValue("@quizId", quizId);
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        //public static void AddQuestions(int quizId, List<QuestionViewModel> questions)
        //{
        //    using (var conn = new SQLiteConnection(LoadConnectionString()))
        //    {
        //        conn.Open();

        //        //Adding questions and answers
        //        foreach (var question in questions)
        //        {
        //            //Adding questions
        //            string insertQuestionSql = "INSERT INTO Questions (Text, QuizID) VALUES (@text, @quizId);";
        //            var insertQuestionCommand = new SQLiteCommand(insertQuestionSql, conn);
        //            insertQuestionCommand.Parameters.AddWithValue("@text", question.QuestionModel.Question);
        //            insertQuestionCommand.Parameters.AddWithValue("@quizId", quizId);
        //            insertQuestionCommand.ExecuteNonQuery();

        //            //Getting ID of added questions
        //            string selectQuestionSql = "SELECT last_insert_rowid();";
        //            var selectQuestionCommand = new SQLiteCommand(selectQuestionSql, conn);
        //            int questionId = Convert.ToInt32(selectQuestionCommand.ExecuteScalar());

        //            //Adding answers
        //            foreach (var answer in question.QuestionModel.Answers)
        //            {
        //                string insertAnswerSql = "INSERT INTO Answers (Text, IsCorrect, QuestionID) VALUES (@text, @isCorrect, @questionId);";
        //                var insertAnswerCommand = new SQLiteCommand(insertAnswerSql, conn);
        //                insertAnswerCommand.Parameters.AddWithValue("@text", answer.Answer);
        //                insertAnswerCommand.Parameters.AddWithValue("@isCorrect", answer.IsCorrect);
        //                insertAnswerCommand.Parameters.AddWithValue("@questionId", questionId);
        //                insertAnswerCommand.ExecuteNonQuery();
        //            }
        //        }
        //        conn.Close();
        //    }
        //}

        public static List<CompleteQuiz> GetQuizes()
        {
            List<CompleteQuiz> quizesFound = new List<CompleteQuiz>();
            using (var conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Open();

                string selectQuizesSql = "SELECT * FROM Quizes;";
                var selectQuizesCommand = new SQLiteCommand(selectQuizesSql, conn);

                using (var reader = selectQuizesCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int quizId = reader.GetInt32(0);
                        string quizName = reader.GetString(1);
                        var quizInfo = new CompleteQuiz(reader.GetInt32(0), reader.GetString(1));
                        quizesFound.Add(quizInfo);
                    }
                }
                conn.Close();
            }
            return quizesFound;
        }

        public static List<Question> GetQuestions(int quizID)
        {
            List<Question> questions = new List<Question>();
            using (var conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Open();

                string selectQuestions = "SELECT ID, Text FROM Questions Where QuizID = @quizID";
                SQLiteCommand selectQuestionsCommand = new SQLiteCommand(selectQuestions, conn);
                selectQuestionsCommand.Parameters.AddWithValue("@quizID", quizID);

                SQLiteDataReader reader = selectQuestionsCommand.ExecuteReader();
                int questionNumber = 1;
                while (reader.Read())
                {
                    questions.Add(new Question
                        (reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetString(6)));
                }
                reader.Close();
                conn.Close();
            }
            return questions;
        }

        private static string LoadConnectionString()
        {
            return "Data Source=D:/Studia/Sem4/Programowanie objektowe i graficzne/Quizz/Quiz/Quiz/Quizes.db;Version=3;";
        }
    }

}
