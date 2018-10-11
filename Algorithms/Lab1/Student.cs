namespace Algorithms.Lab1
{
    public class Student
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Card { get; set; }
        public Gender Gender { get; set; }
        public City City { get; set; }

        public override string ToString()
        {
            return $"card - {Card}, name - {Name}, year - {Year}, gender - {Gender}, city - {City}";
        }
    }
}