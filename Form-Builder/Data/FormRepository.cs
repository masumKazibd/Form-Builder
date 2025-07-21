using Form_Builder.Models;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace Form_Builder.Data
{
    public class FormRepository
    {
        private readonly string _connectionString;

        public FormRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void SaveForm(string formTitle, List<FormFields> fields)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlForm = "INSERT INTO Forms (Title) VALUES (@Title); SELECT SCOPE_IDENTITY();";
                SqlCommand commandForm = new SqlCommand(sqlForm, connection);
                commandForm.Parameters.AddWithValue("@Title", formTitle);
                int formId = Convert.ToInt32(commandForm.ExecuteScalar());

                if (fields != null && fields.Count > 0)
                {
                    foreach (var field in fields)
                    {
                        string sqlField = "INSERT INTO FormFields (Label, IsRequired, FormID) VALUES (@Label, @IsRequired, @FormID);";
                        SqlCommand commandField = new SqlCommand(sqlField, connection);
                        commandField.Parameters.AddWithValue("@Label", field.Label);
                        commandField.Parameters.AddWithValue("@IsRequired", field.IsRequired);
                        commandField.Parameters.AddWithValue("@FormID", formId);
                        commandField.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<Form> GetAllForms()
        {
            var forms = new List<Form>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT FormID, Title FROM Forms ORDER BY FormID DESC";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        forms.Add(new Form
                        {
                            FormID = Convert.ToInt32(reader["FormID"]),
                            FormTitle = reader["Title"].ToString()
                        });
                    }
                }
            }
            return forms;
        }
    }
}