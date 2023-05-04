using MegaMozg.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg.Domain.Entity
{
    public class Answer : BaseEntity
    {        
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public Answer(int id, int questionId, string description, bool isCorrect)
        {
            Id= id;
            QuestionId = questionId;
            Description = description;
            IsCorrect = isCorrect;               
        }
    }  
}
