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


}

class Student{
    public string name = "undefined";
    public string surname = "undefined";
    public string group = "undefined";
    public int year;
    public Result[] results = {};

    public float GetAveragePoints(){
        return 0;
    }

    public int GetBestSubject(){
        return 0;
    }

    public int GetWorstSubject(){
        return 0;
    }
}

class Program{
    public void ReadStudentsArray(){

    }

    public void PrintStudent(){
        
    }

    public void PrintStudents(){
        
    }

    public void GetStudentsInfo(){
        
    }

    public void SortStudentsByPoints(){
        
    }

    public void SortStudentsByName(){
        
    }
}