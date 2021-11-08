using Db4objects.Db4o;
using Lab05.Elmasri_Navathe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab05.DB
{
    public class Database
    {
        public static string DbFileName { get; set; }
        public static IObjectContainer DB => Db4oEmbedded.OpenFile(DbFileName);
        public static void CloseDB(IObjectContainer db) { db.Close(); }

        //Phương thức tạo đối tượng Employee
        public static void CreateEmployees(IObjectContainer db, string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int nEmps = int.Parse(fin.ReadLine());
                for (int i = 0; i < nEmps; i++)
                {
                    string line = fin.ReadLine();
                    if (line != null)
                    {
                        string[] fields = line.Split(':');
                        string fname = fields[0];
                        char minit = fields[1][0];
                        string lname = fields[2];
                        int ssn = int.Parse(fields[3]);
                        string bdate = fields[4];
                        string address = fields[5];
                        char sex = fields[6][0];
                        float salary = float.Parse(fields[7]);
                        Employee e = new Employee
                        {
                            Ssn = ssn,
                            FName = fname,
                            MInit = minit,
                            LName = lname,
                            Address = address,
                            BirthDate = bdate,
                            Salary = salary,
                            Sex = sex
                        };
                        db.Store(e);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }

        //Phương thức tạo đối tượng Depentdents
        public static void CreateDependents(IObjectContainer db, string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int nEmps = int.Parse(fin.ReadLine());
                for (int i = 0; i < nEmps; i++)
                {
                    string line = fin.ReadLine();
                    if (line != null)
                    {
                        string[] fields = line.Split(',');
                        string Name = fields[1];
                        char sex = fields[4][0];
                        string bdate = fields[3];
                        string rela = fields[2];
                        Dependent e = new Dependent
                        {
                            Name = Name,
                            Sex = sex,
                            BirthDate = bdate,
                            Relationship = rela
                        };
                        db.Store(e);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }

        //Phương thúc tạo đối tượng Department
        public static void CreateDepartment(IObjectContainer db, string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int nEmps = int.Parse(fin.ReadLine());
                for (int i = 0; i < nEmps; i++)
                {
                    string line = fin.ReadLine();
                    if (line != null)
                    {
                        string[] fields = line.Split(':');
                        int DNumber = int.Parse(fields[0]);
                        string DName = fields[1];
                        List<string> Locations = new List<string>(fields);
                        
                        Department e = new Department
                        {
                            DName = DName,
                            DNumber =DNumber,
                            Locations = Locations
                        };
                        db.Store(e);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }

        //Phương thức khởi tạo Project
        public static void CreateProject(IObjectContainer db, string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int nEmps = int.Parse(fin.ReadLine());
                for (int i = 0; i < nEmps; i++)
                {
                    string line = fin.ReadLine();
                    if (line != null)
                    {
                        string[] fields = line.Split(':');
                        int PNumber = int.Parse(fields[0]);
                        string PName = fields[1];
                        string Location = fields[2];

                        Project e = new Project
                        {
                            PName = PName,
                            PNumber = PNumber,
                            Location = Location,
                        };
                        db.Store(e);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }

        //Phương thúc tạo đối tượng WorksOn
        public static void CreateWỏkOn(IObjectContainer db, string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int nEmps = int.Parse(fin.ReadLine());
                for (int i = 0; i < nEmps; i++)
                {
                    string line = fin.ReadLine();
                    if (line != null)
                    {
                        string[] fields = line.Split(':');
                        float Hour = float.Parse(fields[0]);

                        WorksOn e = new WorksOn
                        {
                            Hours = Hour
                        };
                        db.Store(e);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }

        //Phương thúc đọc dữ liệu từ tập tin văn bản và thiết lập manager cho lớp Employee
        public static void SetManagers(IObjectContainer db, string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open); 
                StreamReader fin = new StreamReader(fs); 
                int nMgrs = int.Parse(fin.ReadLine()); 
                for (int i = 0; i < nMgrs; i++)
                {
                    string line = fin.ReadLine();
                    string[] fields = line.Split(','); 
                    int dno = int.Parse(fields[0]); 
                    int essn = int.Parse(fields[1]); 
                    string startDate = fields[2];
                    IList<Department> depts = db.Query(delegate (Department dept)
                    {
                        return (dept.DNumber == dno);
                    });
                    Department d = null;
                    if (depts != null)
                        d = depts[0];
                    IList<Employee> emps = db.Query(delegate (Employee emp)
                    {
                        return (emp.Ssn == essn);
                    });
                    Employee e = null;
                    if (emps != null && emps.Count != 0)
                        e = emps[0];
                    if (e != null && d != null)
                    {
                        d.MgrStartDate = startDate; 
                        e.Manages = d; 
                        d.Manager = e; 
                        db.Store(d); 
                        db.Store(e); 
                    }
                }
            }
        }
    }
}
