using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWebApiCore.Model
{
    public class db
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QSTKRO;Initial Catalog=EmployeeCore;Integrated Security=True;");

        public string EmployeeOpt(Employee emp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Id", emp.Id);
                com.Parameters.AddWithValue("Email", emp.Email);
                com.Parameters.AddWithValue("Emp_name", emp.Emp_name);
                com.Parameters.AddWithValue("Designation", emp.Designation);
                com.Parameters.AddWithValue("type", emp.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";
            }
            catch (Exception ee)
            {
                msg = ee.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        //Get Record
        public DataSet EmployeeGet(Employee emp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Id", emp.Id);
                com.Parameters.AddWithValue("Email", emp.Email);
                com.Parameters.AddWithValue("Emp_name", emp.Emp_name);
                com.Parameters.AddWithValue("Designation", emp.Designation);
                com.Parameters.AddWithValue("type", emp.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";
            }
            catch (Exception ee)
            {
                msg = ee.Message;
            }
            return ds;
        }
    }
}
