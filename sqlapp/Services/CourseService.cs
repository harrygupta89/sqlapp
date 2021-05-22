using sqlapp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace sqlapp.Services
{
    public class CourseService
    {
        public static string db_source = "dbserver100089.database.windows.net";
        public static string db_user = "demouser";
        public static string db_password = "password@123";
        public static string db_database = "appdb";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;

            return new SqlConnection(_builder.ConnectionString);        
        }
        public IEnumerable<Course> GetCourses()
        {
            List<Course> _lst = new List<Course>();
            string _statement = "select CourseID, CourseName, Rating from Course";
            SqlConnection _connection = GetConnection();
            _connection.Open();
            SqlCommand _sqlCommand = new SqlCommand(_statement, _connection);

            using (SqlDataReader _reader = _sqlCommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Course _course = new Course()
                    {
                        CourseID = _reader.GetInt32(0),
                        CourseName = _reader.GetString(1),
                        Rating = _reader.GetDecimal(2)
                    };
                    _lst.Add(_course);
                }
            }
            _connection.Close();
            return _lst;
        }
    }
}
