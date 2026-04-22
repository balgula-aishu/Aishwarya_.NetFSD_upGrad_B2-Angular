
using week10_day1;

var service = new BadContactService();

var contact = new Contact
{
    Id = 1,
    Name = "Test",
    Email = "test@gmail.com",
    Phone = "1234567890"
};

service.add(contact);

Console.WriteLine("Contact added using bad code.");
