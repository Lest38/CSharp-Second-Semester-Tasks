namespace StudentHandler
{
    /// <summary>
    /// Represents a student with a name and a list of grades.
    /// </summary>
    /// <param name="name"></param>
    public class Student(string name)
    {
        public string Name { get; } = name;
        private List<int> grades = [];

        /// <summary>
        /// Adds a grade to the student's list of grades.
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="minGrade"></param>
        /// <param name="maxGrade"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddGrade(int grade, int minGrade, int maxGrade)
        {
            if (grade < minGrade || grade > maxGrade)
                throw new ArgumentException("Grade should be from 1 to 10.");
            grades.Add(grade);
        }

        /// <summary>
        /// Calculates the average of the student's grades.
        /// </summary>
        /// <returns></returns>
        public double GetAverageGrade() => grades.Count > 0 ? grades.Average() : 0.0;
        
        /// <summary>
        /// Returns all grades of the student.
        /// </summary>
        /// <returns></returns>
        public List<int> GetAllGrades() => new(grades);

        /// <summary>
        /// Removes the lowest grade from the student's list of grades.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void RemoveLowestGrade()
        {
            if (grades.Count == 0)
                throw new InvalidOperationException("No grades to remove.");

            int minGrade = grades.Min();
            grades.Remove(minGrade);
        }
    }

}