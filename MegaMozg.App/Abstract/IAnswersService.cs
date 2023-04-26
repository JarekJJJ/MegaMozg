using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg.App.Abstract
{
    public interface IAnswersService<T>
    {
        List<T> Answers { get; set; }
        List<T> GetAllAnswers();
        void AddBaseAnswer(T baseAnswer);
        int AddUserAnswer(T userAnswer);

    }
}
