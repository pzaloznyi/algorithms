using System.Collections.Generic;

namespace Algorithms.Lab2
{
    public class Lab2StudentComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.AverageMark - y.AverageMark;
        }
    }
}