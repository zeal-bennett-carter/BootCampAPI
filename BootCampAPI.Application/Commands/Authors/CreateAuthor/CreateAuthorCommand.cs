using BootCampAPI.Application.Models.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Commands.Authors.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<AuthorDTO>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }

        public CreateAuthorCommand(string name, int age, string status)
        {
            Name = name;
            Age = age;
            Status = status;
        }
    }
}
