namespace Algorithms.Lab2
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AverageMark { get; set; }
        public string Group { get; set; }

        public override string ToString()
        {
            return $"first name: {FirstName}, last name: {LastName}, average mark: {AverageMark}, group: {Group}";
        }
    }
}