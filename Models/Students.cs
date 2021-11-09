using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsManagement.Models
{
    public class Students
    {
        public int ID { set; get; }
        [Required(ErrorMessage = "Nhap ho va ten sinh vien")]
        [Display(Name = "Họ và tên:")]

        public string Fullname { set; get; }
        [Required(ErrorMessage = "Nhập địa chỉ")]
        [Display(Name = "Địa chỉ:")]
        public string Address { set; get; }

    }
    class StudentList
    {
        DBconnection db;
        public StudentList()
        {
            db = new DBconnection();
        }
        public List<Students> getStudent(String ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
                sql = "SELECT * FROM Students";
            else
                sql = "SELECT * FROM Students WHERE Id = " + ID;
            List<Students> stulist = new List<Students>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            Students tmpStu;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpStu = new Students();
                tmpStu.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                tmpStu.Fullname = dt.Rows[i]["Fullname"].ToString();
                tmpStu.Address = dt.Rows[i]["Address"].ToString();
                stulist.Add(tmpStu);
            }
            return stulist;
        }
        public void AddStudents(Students stu)
        {
            string sql = "INSERT INTO Students(fullname, address) VALUES(N'" + stu.Fullname + "', N'" + stu.Address + "')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }
        public void UpdateStudents(Students stu)
        {
            string sql = "UPDATE Students SET Fullname = N'" + stu.Fullname + "', Address = N'" + stu.Address + "' WHERE ID = " + stu.ID;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteStudent(Students stu)
        {
            string sql = "DELETE Students WHERE ID = " + stu.ID;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose ();
            con.Close();
        }
    }
}