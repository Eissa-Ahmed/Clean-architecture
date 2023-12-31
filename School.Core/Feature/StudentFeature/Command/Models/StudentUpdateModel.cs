﻿namespace School.Core.Feature.StudentFeature.Command.Models;

public class StudentUpdateModel : IRequest<Response<string>>
{
    public StudentUpdateModel(Guid id, string name, string phone, string address)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Address = address;
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
}
