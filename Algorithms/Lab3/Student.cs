namespace Algorithms.Lab3
{
    public class Student
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int AverageMark { get; set; }
        public bool CanPlay { get; set; }

        public override string ToString()
        {
            return $"{Firstname} {Surname} {AverageMark} {CanPlay}";
        }
    }
}