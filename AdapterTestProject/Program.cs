using AdapterTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdapterTestProject
{
    class Program
    {
        public static readonly Adapter.DatabaseAdapter databaseAdapter=new Adapter.DatabaseAdapter();
        static void Main(string[] args)
        {
            int id = 0;
            Insert();
            List();

            Console.WriteLine("Silmek istediğiniz id yi giriniz: ");
            string deleteValue = Console.ReadLine();
            Int32.TryParse(deleteValue, out id);
            Delete(id);

            List();
            Console.WriteLine("Güncellemek istediğiniz id yi giriniz: ");
            string updateValue = Console.ReadLine();
            Int32.TryParse(updateValue, out id);

            Update(id);
            List();

            Console.ReadLine();
        }

        public static void Update( int id)
        {
            Models.Student student= GetValues();

            Models.Student oldValue= databaseAdapter.Find<Models.Student>(id);
            oldValue.Name = student.Name;
            oldValue.Surname = student.Surname;
            oldValue.StudentNumber = student.StudentNumber;

            student=databaseAdapter.Update(oldValue);

            Console.WriteLine("Güncelleme işlemi gerçekleştirildi.");

        }

        public static void List()
        {
            IQueryable<Student> students = databaseAdapter.Get<Models.Student>();
            foreach (var item in students.ToList())
            {
                Console.Write("Id: {0} Adı: {1} Soyadı: {2} Öğrenci No: {3}", item.Id, item.Name, item.Surname, item.StudentNumber);
                Console.WriteLine();
            }
        }

        public static void Delete(int id)
        {
            databaseAdapter.Delete<Models.Student>(id);
            Console.WriteLine("Kayıt silindi.");
        }

        public static Models.Student GetValues()
        {
            int studentNumber = 0;
            string studentName = "", studentSurname = "";

            while (true)
            {
                Console.WriteLine("Öğrenci numarası giriniz:");
                string studentNumberStr = Console.ReadLine();

                if (Int32.TryParse(studentNumberStr, out studentNumber))
                {
                    if (studentNumber > 0)
                    {
                        Console.WriteLine("Öğrenci adını giriniz:");
                        studentName = Console.ReadLine();

                        if (studentName != null)
                        {
                            Console.WriteLine("Öğrenci soyadını giriniz:");
                            studentSurname = Console.ReadLine();

                            if (studentSurname != null)
                            {
                                break;
                            }
                        }
                    }
                }
            }


            Student student = new Student
            {
                StudentNumber = studentNumber,
                Name = studentName,
                Surname = studentSurname
            };

            return student;
        }

        public static void Insert()
        {
            databaseAdapter.Insert(GetValues());

            Console.WriteLine("Kayıt eklendi.");
        }
    }
}
