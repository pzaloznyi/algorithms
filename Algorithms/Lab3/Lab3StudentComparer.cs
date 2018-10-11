using System.Collections.Generic;

namespace Algorithms.Lab3
{
    public class Lab3StudentComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.AverageMark - y.AverageMark;
        }
    }
}