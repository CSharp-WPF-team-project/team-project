using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Notice.Model

{
    public class Grade21 : StackPanel
    { 

        private bool isCheckGrade;

        public bool IscheckGrade
        {
            get
            {
                return isCheckGrade;
            }
            set
            {
                isCheckGrade = value;
                if (isCheckGrade)
                {
                   // VM.grade.GradeNumber = 21;
                }
                else
                {
                    //VM.grade.GradeNumber =  0;
                }
            }
        }
    }
}
