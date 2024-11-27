using Microsoft.Data.SqlClient;

namespace FilmsPerActor
{
    internal class FilmDBService
    {
        public string ConnectionString { get; set; }
        public FilmDBService(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<String> GetFilmsByActorName(string firstName, string lastName)
        {
            string query = @"
            SELECT film.title
            FROM actor
            INNER JOIN film_actor ON actor.actor_id = film_actor.actor_id
            INNER JOIN film ON film.film_id = film_actor.film_id
            WHERE actor.first_name = @FirstName AND actor.last_name = @LastName";

            List<string> films = new List<string>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                films.Add(reader["title"].ToString());
                            }
                        }

                        return films;
                    }
                }

                connection.Close();
            }
        }
    }
}
