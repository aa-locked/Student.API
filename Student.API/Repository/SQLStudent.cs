using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Student.API.Models.Domain;
using System.Data;

namespace Student.API.Repository
{
    public class SQLStudent : IStudent
    {
        private readonly IConfiguration _configuration;

        public SQLStudent(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string SqlConnection()
        {
            return _configuration.GetConnectionString("dbCon").ToString();
        }

        public List<Students> GetAllStudent()
        {
            List<Students> students = new List<Students>();
            try
            {
                using (var con = new SqlConnection(this.SqlConnection()))
                {
                    string sqlTxt = " Select * from students ";
                    SqlCommand cmd =new SqlCommand(sqlTxt, con);
                    cmd.CommandType= CommandType.Text;
                    DataTable dt=new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);

                    if(dt!=null && dt.Rows.Count > 0)
                    {
                        foreach(DataRow row in dt.Rows)
                        {
                            Students std = new Students();
                            std.StudentID = (Guid)row["StudentID"];
                            std.FirstName = row["FirstName"].ToString();
                            std.LastName = row["LastName"].ToString();
                            std.Standard = Convert.ToInt32(row["Standard"].ToString());
                            students.Add(std);
                        }
                        
                    }
                    return students;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
           


            return students;
        }
    }
}
