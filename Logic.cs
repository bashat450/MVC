using FirstMVCApps.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FirstMVCApps
{
    public class Logic
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbEmp"].ToString());

        #region === insert Employee Logic ===
        public void InsertEmp(InsertEmployeeModel insertEmployee)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spInsertEmployeesDetails]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName", insertEmployee.FullName);
                cmd.Parameters.AddWithValue("@Salary", insertEmployee.Salary);
                cmd.Parameters.AddWithValue("@Country", insertEmployee.Country);
                cmd.Parameters.AddWithValue("@EmailId", insertEmployee.EmailId);
                cmd.Parameters.AddWithValue("@CurrentDate", insertEmployee.CurrentDate);
                cmd.Parameters.AddWithValue("@DepId", insertEmployee.DepId);
                cmd.Parameters.AddWithValue("@JobTitle", insertEmployee.JobTitle);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        public List<ListOfEmployeeModel> GetAllEmployee()
        {
            List<ListOfEmployeeModel> LMP = new List<ListOfEmployeeModel>();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ListOfEmployees_SP]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ListOfEmployeeModel emp = new ListOfEmployeeModel
                    {
                        RegId = Convert.ToInt32(row["RegId"]),
                        FullName = row["FullName"].ToString(),
                        Salary = Convert.ToInt32(row["Salary"]),
                        Country = row["Country"].ToString(),
                        EmailId = row["EmailId"].ToString(),
                        CurrentDate = Convert.ToDateTime(row["CurrentDate"]),
                        DepId = Convert.ToInt32(row["DepId"]),
                        JobTitle = row["JobTitle"].ToString()
                    };

                    LMP.Add(emp);
                }
            }
            catch (Exception ex)
            {
                // Log or handle error
                throw;
            }

            return LMP;
        }

    }
}