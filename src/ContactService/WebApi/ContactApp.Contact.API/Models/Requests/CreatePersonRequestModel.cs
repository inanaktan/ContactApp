using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Contact.API.Models.Requests;

/// <summary>
/// Create person model
/// </summary>
public class CreatePersonRequestModel
{
    /// <summary>
    /// The field is first name of Person
    /// </summary>
    /// <value></value>
    public string FirstName { get; set; }
    /// <summary>
    /// The field is last name of Person
    /// </summary>
    /// <value></value>
    public string LastName { get; set; }
    /// <summary>
    /// The field is company of Person
    /// </summary>
    /// <value></value>
    public string Company { get; set; }
}
