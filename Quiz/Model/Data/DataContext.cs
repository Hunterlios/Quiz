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
    public class DataContext
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
                //using (var command = new SQLiteCommand("DELETE FROM Answers WHERE QuestionID IN (SELECT ID FROM Questions WHERE QuizID = @quizId)", conn))
                //{
                //    command.Parameters.AddWithValue("@quizId", quizId);
                //    command.ExecuteNonQuery();
                //}

                //Removing Questions
                using (var command = new SQLiteCommand("DELETE FROM Questions WHERE QuizID = @quizId", conn))
                {
                    command.Parameters.AddWithValue("@quizId", quizId);
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public static void AddQuestions(int quizId, string quizName, List<Question> questions)
        {
            using (var conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Open();

                using (SQLiteTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {

                        //Adding Quiz
                        string insertQuizSql = "INSERT INTO Quizes (ID, Name) VALUES (@id, @name);";
                        var insertQuizCommand = new SQLiteCommand(insertQuizSql, conn);
                        insertQuizCommand.Parameters.AddWithValue("@id", quizId);
                        insertQuizCommand.Parameters.AddWithValue("@name", quizName);
                        insertQuizCommand.ExecuteNonQuery();

                        //Getting ID of added questions

                        string countQuery = "SELECT COUNT(*) FROM Questions";
                        SQLiteCommand command = new SQLiteCommand(countQuery, conn);
                        int rowCount = Convert.ToInt32(command.ExecuteScalar());

                        //Adding Answers to Quiz
                        foreach (var que in questions)
                        {
                            rowCount++;
                            string insertQuestionSql = "INSERT INTO Questions (ID, Text, A, B, C, D, IsCorrect, QuizID) VALUES (@id, @text, @a, @b, @c, @d, @isCorrect, @quizID);";
                            var insertQuestionCommand = new SQLiteCommand(insertQuestionSql, conn);
                            insertQuestionCommand.Parameters.AddWithValue("@id", rowCount);
                            insertQuestionCommand.Parameters.AddWithValue("@text", que.TheQuestion);
                            insertQuestionCommand.Parameters.AddWithValue("@a", que.AnswerA);
                            insertQuestionCommand.Parameters.AddWithValue("@b", que.AnswerB);
                            insertQuestionCommand.Parameters.AddWithValue("@c", que.AnswerC);
                            insertQuestionCommand.Parameters.AddWithValue("@d", que.AnswerD);
                            insertQuestionCommand.Parameters.AddWithValue("@isCorrect", que.CorrectAnswer);
                            insertQuestionCommand.Parameters.AddWithValue("@quizId", quizId);
                            insertQuestionCommand.ExecuteNonQuery();
                        }


                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that occur during the transaction
                        Console.WriteLine("An error occurred: " + ex.Message);
                        // Rollback the transaction to revert any changes
                        transaction.Rollback();
                    }
                }              
      
                conn.Close();
            }
        }


        public static List<CompletedQuiz> GetQuizzes()
        {
            List<CompletedQuiz> quizzesFound = new List<CompletedQuiz>();
            using (var connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Open();

                string selectQuizzesSql = "SELECT * FROM Quizes;";
                var selectQuizzesCommand = new SQLiteCommand(selectQuizzesSql, connection);

                using (var reader = selectQuizzesCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var quizInfo = new CompletedQuiz(reader.GetInt32(0), reader.GetString(1));
                        quizzesFound.Add(quizInfo);
                    }
                }
                connection.Close();
            }
            return quizzesFound;
        }
        public static List<Question> GetQuestions(int quizID)
        {
            List<Question> questions = new List<Question>();
            using (var conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Open();

                string selectQuestions = "SELECT ID, Text, A, B, C, D, IsCorrect, QuizID FROM Questions Where QuizID = @quizID";
                SQLiteCommand selectQuestionsCommand = new SQLiteCommand(selectQuestions, conn);
                selectQuestionsCommand.Parameters.AddWithValue("@quizID", quizID);

                SQLiteDataReader reader = selectQuestionsCommand.ExecuteReader();

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

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }

}
