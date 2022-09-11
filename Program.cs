/*

1. Оголосити структуру Result, яка представляє результати сесії з одного предмета і містить такі поля (відкриті):
- Subject – назва предмета;
- Teacher – П.І.Б. викладача;
- Points – оцінка за 100-бальною шкалою
Оголосити структуру Student, яка містить наступні поля (відкриті):
- Name – ім’я;
- Surname - прізвище;
- Group – шифр групи;
- Year – номер курсу;
- Results – масив результатів сесії, що являє собою масив структур
типу Result.
2. Для кожної структури реалізувати два конструктори.
3. У структуру Student додати методи (нестатичні):
- GetAveragePoints, який обраховує середнє арифметичне усіх оцінок;
- GetBestSubject(), що повертає назву предмета, за яким студент має
найвищий бал серед інших предметів;
- GetWorstSubject(), який повертає назву предмета, за яким студент
отримав найгірший бал.
4. У класі Program передбачити статичні методи:
- ReadStudentsArray() – читає з клавіатури масив структур (n штук) і
повертає масив структур типу Student;
- PrintStudent() – приймає структуру типу Student і виводить її на екран;
- PrintStudents() – приймає масив структур типу Student і виводить
його на екран;
- GetStudentsInfo() – приймає масив структур типу Student і повертає
через out-параметри найвищий середній бал та найнижчий середній
бал.
- SortStudentsByPoints() – приймає масив структур типу Student і сортує його за середнім балом студента;
- SortStudentsByName() – приймає масив структур типу Student і сортує його за прізвищем, якщо прізвище однакове – то розташувати
структури за ім’ям

*/

class Result{
    public string subject = "undefined";
    public string teacher = "undefined";
    public int points;

    public Result(){
        subject = Program.StringInput("Input subject name: ");
        teacher = Program.StringInput("Input teacher name: ");
        points = Program.IntegerInput("Input points amount: ");
    }

    public Result(string subject_name, string teacher_name, int points_amount){
        subject = subject_name;
        teacher = teacher_name;
        points = points_amount;
    }

    public void Print(){
        Console.WriteLine($"Subject: {subject}, Teacher: {teacher}, Points: {points}");
    }
}

class Student{
    public string name = "undefined";
    public string surname = "undefined";
    public string group = "undefined";
    public int year;
    public Result[] results = {};

    public Student(){
        name = Program.StringInput("Input student name: ");
        surname = Program.StringInput("Input student surname: ");
        group = Program.StringInput("Input student group: ");
        year = Program.IntegerInput("Input student year: ");
        int count_results = Program.IntegerInput("Input count results: ");
        for (int i = 0; i < count_results; i++){
            results.Append(new Result()).ToArray();
        }
    }

    public Student(string student_name, string student_surname, string student_group, int student_year, Result[] student_results){
        name = student_name;
        surname = student_surname;
        group = student_group;
        year = student_year;
        results = student_results;
    }

    public float GetAveragePoints(){
        float total_amount = 0;
        foreach (Result result in results){   
            total_amount += result.points;
        }

        return total_amount/results.Length;
    }

    public string GetBestSubject(){
        Result best_result = results[0];
        foreach (Result result in results){   
            if (result.points > best_result.points){
                best_result = result;
            }
        }

        return best_result.subject;
    }

    public string GetWorstSubject(){
        Result worst_result = results[0];
        foreach (Result result in results){   
            if (result.points < worst_result.points){
                worst_result = result;
            }
        }

        return worst_result.subject;
    }

    public void Print(){
        Console.WriteLine($"\nName: {name}, Surname: {surname}, Group: {group}, Year: {year}, Results:");
        foreach (Result result in results){   
            result.Print();
        }
    }
}

class Program{

    static void Main(string[] args)
    {
        int students_count = Program.IntegerInput("Input student year: ");
        Student[] students = Program.ReadStudentsArray(students_count);
        //Test in all
    }

    public static Student[] ReadStudentsArray(int students_count){
        Student[] students_array = {};

        for (int i = 0; i < students_count; i++){
            Student student = new Student();
            students_array.Append(student).ToArray();
        }

        return students_array;
    }

    public static void PrintStudent(Student student){
        student.Print();
    }

    public static void PrintStudents(Student[] students){
        foreach (Student student in students){   
            student.Print();
        }
    }

    public static void GetStudentsInfo(Student[] students, out float worst_points, out float best_points){
        float[] students_average_points = {};
        foreach (Student student in students){   
            students_average_points.Append(student.GetAveragePoints()).ToArray();
        }
        worst_points = students_average_points[0];
        best_points = students_average_points[0];

        foreach(float point in students_average_points){
            if (point > best_points){
                best_points = point;
            }

            if (point < best_points){
                worst_points = point;
            }
        }
    }

    public static void SortStudentsByPoints(Student[] students){
        var sorted_students = students.OrderBy(ob => ob.GetAveragePoints()).ToArray();
        Program.PrintStudents(sorted_students);
    }

    public static void SortStudentsByName(Student[] students){
        var sorted_students = students.OrderBy(ob => ob.surname).ThenBy(ob => ob.name).ToArray();
        Program.PrintStudents(sorted_students);
    }

    public static int IntegerInput(string title){
        int result = 0;
        bool is_valid = false;

        do {
            Console.Write(title);
            is_valid = int.TryParse(Console.ReadLine(), out result);
            if (is_valid == false)
                Console.WriteLine("Input error! Try again..");
        } while (!is_valid);

        return result;
    }

    public static string StringInput(string title){
        string? result;
        bool is_valid = false;

        do {
            Console.Write(title);
            result = Console.ReadLine();
            is_valid = !string.IsNullOrEmpty(result);
            if (is_valid == false)
                Console.WriteLine("Input error! Try again..");
        } while (!is_valid);

        return result;
    }
}