using System.Collections.Generic;

namespace Algorithms.Lab3
{
    public class Lab3StudentComparer : IComparer<Student>
    {
        private bool _asc;

        public Lab3StudentComparer(bool asc = true)
        {
            _asc = asc;
        }
        public int Compare(Student x, Student y)
        {
            return _asc ? y.AverageMark - x.AverageMark : x.AverageMark - y.AverageMark;
        }
    }
}