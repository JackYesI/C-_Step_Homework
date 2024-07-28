using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Reader_Writer
{
    internal class Program
    {
        // ex 1
        static class AppSettingHelper
        {
            public static void Write(ConsoleColor consoleColor, string console_Name, int console_size)
            {
                string filePath = "example.bin";
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create, FileAccess.Write)))
                {
                    writer.Write((int)consoleColor);           
                    writer.Write(console_Name);          
                    writer.Write(console_size);
                    Console.WriteLine("Write has done !!!");
                }
            }
            public static void Read(out ConsoleColor consoleColor, out string console_Name, out int console_size)
            {
                string filePath = "example.bin";
                if (new FileInfo(filePath).Length == 0)
                {
                    Console.WriteLine("File is empty");
                    consoleColor = 0;
                    console_Name = string.Empty;
                    console_size = 0;
                }
                else
                    using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read)))
                    {
                        consoleColor = (ConsoleColor)reader.ReadInt32();       
                        console_Name = reader.ReadString();
                        console_size = reader.ReadInt32();
                        Console.WriteLine("Read has done !!!");
                    }
            }
        }

        // ex 2
        public class Student
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public int[] Marks { get; set; }
            public string Description { get; set; }
            public Student(string firstName, string secondName, int[] marks, string description)
            {
                FirstName = firstName;
                SecondName = secondName;
                Marks = marks;
                Description = description;
            }
            private string printMark()
            {
                string result = string.Empty;
                foreach (int item in this.Marks)
                {
                    result += item.ToString() + '\t';
                }
                return result;
            }
            public override string ToString()
            {
                return $"First name is {this.FirstName, -20} Second name is {this.SecondName, -20} Description is {this.Description, -20}\n Marks is \n{printMark()}\n";
            }
        }
        static public class FileWorker
        {
            static public void SaveStudent(Student[] students, string filename)
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create, FileAccess.Write)))
                {
                    writer.Write(students.Length);
                    foreach (Student obj in students)
                    {
                        writer.Write(obj.FirstName);
                        writer.Write(obj.SecondName);
                        writer.Write(obj.Marks.Length);
                        foreach (var item in obj.Marks)
                        {
                            writer.Write(item);
                        }
                        writer.Write(obj.Description);
                    }
                }
                Console.WriteLine("Write has done !!!");
            }
            static public Student[] LoadStudents(string filename)
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open, FileAccess.Read)))
                {
                    int arrayLength = reader.ReadInt32();
                    Student[] myArray = new Student[arrayLength];

                    for (int i = 0; i < arrayLength; i++)
                    {
                        string firsName = reader.ReadString();
                        string secondName = reader.ReadString();
                        int lenght = reader.ReadInt32();
                        int[] ints = new int[lenght];
                        for (int j = 0; j < lenght; j++)
                        {
                            ints[j] = reader.ReadInt32();
                        }
                        string desc = reader.ReadString();
                        Student obj = new Student(firsName, secondName, ints, desc);                            // ...
                        myArray[i] = obj;
                    }
                    return myArray;
                }
            }
        }
        static void Main(string[] args)
        {
            // ex 1
            //AppSettingHelper.Write(ConsoleColor.Gray, "Name Random", 3);
            //ConsoleColor consoleColor;
            //string name;
            //int size;
            //AppSettingHelper.Read(out consoleColor, out name, out size);

            //Console.WriteLine($"Color is {consoleColor, -10} Name is {name,-20} Size is {size, -10}");

            // ex 2
            string file = "dataStudents.bin";
            //Student[] myArray = new Student[4];
            //myArray[0] = new Student("Anton", "pupkin", new int[4] { 1, 2, 4, 5 }, "magistr");
            //myArray[1] = new Student("Olya", "walker", new int[4] { 5, 2, 4, 3 }, "bakalavr");
            //myArray[2] = new Student("I am", "Mr", new int[4] { 1, 6, 4, 1 }, "child");
            //myArray[3] = new Student("Luzer", "Buu", new int[4] { 1, 2, 3, 5 }, "grandFather");
            //FileWorker.SaveStudent(myArray, file);

            Student[] resultRead = FileWorker.LoadStudents(file);

            foreach (var item in resultRead)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
