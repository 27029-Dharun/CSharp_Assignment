using Collections.IO;

namespace Collections.Tasks;

/// <summary>
/// Contains the dictionary implementation that maps a student's name to their grade.
/// </summary>
/// <typeparam name="TKey">The data type of the student's identifier for the name.</typeparam>
/// <typeparam name="TValue">The data type of the student's grade.</typeparam>
public class DictionaryOperations<TKey, TValue>
    where TKey : notnull
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
            TKey studentName = names[i];
            TValue grade = values[i];

            this._studentList.Add(studentName, grade);
        }
    }

    /// <summary>
    /// Deletes a student from the record.
    /// </summary>
    /// <param name="studentName">The name of the student to remove.</param>
    public void DeleteStudent(TKey studentName)
    {
        this._studentList.Remove(studentName);
        ConsoleIO.PrintInfo("Removed the student: " + studentName);
    }

    /// <summary>
    /// Displays all the students in the record along with the grade.
    /// </summary>
    public void DisplayStudent()
    {
        ConsoleIO.PrintHeader("Students in the record");

        foreach (var student in this._studentList)
        {
            ConsoleIO.PrintInfo($"{student.Key} - {student.Value}");
        }
    }

    /// <summary>
    /// Checks if the key is present in the record.
    /// </summary>
    /// <param name="name">The name of the student to check.</param>
    /// <returns>A boolean true if exists; otherwise false.</returns>
    public bool ContainsKey(TKey name)
    {
        return this._studentList.ContainsKey(name);
    }
}
