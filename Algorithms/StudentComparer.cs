using System.Collections.Generic;
using Algorithms.Lab2;

namespace Algorithms
{
    public class Lab2StudentComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.AverageMark - y.AverageMark;
        }
    }
}