using Collections.IO;

namespace Collections.Tasks;

/// <summary>
/// Contains the dictionary implementation that maps a student's name to their grade.
/// </summary>
public class DictionaryOperations<TKey, TValue>
{
    private readonly Dictionary<TKey, TValue> _studentList = new Dictionary<TKey, TValue>();

    /// <summary>
    /// Creates a dictionary with student name and grade
    /// </summary>
    /// <param name="names">Array containing the key of the students to add.</param>
    /// <param name="values">Array containing the value of the student to add.</param>
    public void CreateStudentData(TKey[] names, TValue[] values)
    {
        for (int i = 0; i < 5; i++)
        {
            TKey studentName = ConsoleIO.GetName("Enter the name of the student: ");
            if (this._studentList.ContainsKey(studentName))
            {
                ConsoleIO.PrintInfo("Entered student already in the list");
                i--;
                continue;
            }

            TValue grade = ConsoleIO.GetInteger($"Enter the grade of the {studentName}: ");

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
            ConsoleIO.PrintInfo("Removed the student: " + studentName);
            return;
        }

        ConsoleIO.PrintInfo("Entered student not in the record.");
    }

    /// <summary>
    /// Displays all the students in the dictionary along with the grade.
    /// </summary>
    public void DisplayStudent()
    {
        ConsoleIO.PrintHeader("Students in the record");

        foreach (var student in this._studentList)
        {
            ConsoleIO.PrintInfo($"{student.Key} - {student.Value}");
        }
    }
}
