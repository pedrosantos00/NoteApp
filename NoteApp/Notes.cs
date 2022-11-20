using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    public class Notes
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Data { get; set; }


        public Notes(string title)
        {
            Title = title;
        }
        public Notes(string title, string description, DateTime data)
        {
            Title = title;
            Description = description;
            Data = data;
        }

        public Notes(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
