using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Contact.Application.Models.ViewModels;

public class PersonDetailViewModel : PersonViewModel
{
    public List<ContactViewModel> Contacts { get; set; }
}
