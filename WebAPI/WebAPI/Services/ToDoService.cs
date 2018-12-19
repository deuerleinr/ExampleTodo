using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class ToDoService
    {

        public List<ToDo> GetAll()
        {
            using (var con = GetConnection())
            {
                var cmd = con.CreateCommand();

                cmd.CommandText = "ToDo_GetAll";
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    var todos = new List<ToDo>();

                    while (reader.Read())
                    {
                        //this loop will happen once for every row
                        var todo = new ToDo
                        {
                            Id = (int)reader["id"],
                            Task = (string)reader["task"],
                            DateCreated = (DateTime)reader["DateCreated"],
                            DateModified = (DateTime)reader["DateModified"]
                        };

                        todos.Add(todo);
                    }

                    return todos;
                }



            } // calls con.Dispose () using statments guarantee that the connection object will be disposed of when over
        }

        public int Create(ToDoCreate request)
        {
            using (var con = GetConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "ToDo_Create";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@task", request.Task);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                return (int)cmd.Parameters["@Id"].Value;
            }
        }


        // helper method to create and open a database connection
        SqlConnection GetConnection()
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            con.Open();
            return con;
        }
    }
}