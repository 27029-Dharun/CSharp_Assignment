using Collections.IO;

namespace Collections.Tasks;

/// <summary>
/// Contains the dictionary implementation that maps a student's name to their grade.
/// </summary>
public class DictionaryOperations
{
    private readonly Dictionary<string, int> _studentList = new Dictionary<string, int>();

    /// <summary>
    /// Creates a dictionary with student name and grade
    /// </summary>
    public void CreateStudentData()
    {
        for (int i = 0; i < 5; i++)
        {
            string studentName = ConsoleIO.GetName("Enter the name of the student: ");
            if (this._studentList.ContainsKey(studentName))
            {
                ConsoleIO.PrintInfo("Entered student already in the list");
                i--;
                return;
            }

            int grade = ConsoleIO.GetInteger($"Enter the grade of the {studentName}: ");

            this._studentList.Add(studentName, grade);
        }
    }

    /// <summary>
    /// Deletes a student from the dictionary.
    /// </summary>
    public void DeleteStudent()
    {
        string studentName = ConsoleIO.GetName("Enter the name of the student to delete: ");

        if (this._studentList.ContainsKey(studentName))
        {
            this._studentList.Remove(studentName);
        }
        else
        {
            ConsoleIO.PrintInfo("Entered student not in the list.");
        }
    }

    /// <summary>
    /// Displays all the students in the dictionary along with the grade.
    /// </summary>
    public void DisplayStudent()
    {
        ConsoleIO.PrintHeader("Students in the dictionary");

        foreach (var student in this._studentList)
        {
            ConsoleIO.PrintInfo($"{student.Key} - {student.Value}");
        }
    }
}
