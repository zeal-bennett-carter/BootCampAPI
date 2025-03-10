using BootCampAPI.Application.Models.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Commands.Authors.CreateAuthor
{
    public record CreateAuthorCommand : CommandBase<AuthorDTO>
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }

        public CreateAuthorCommand(int id, string name, int age, string status)
        {
            AuthorId = id;
            Name = name;
            Age = age;
            Status = status;
        }
    }
}
