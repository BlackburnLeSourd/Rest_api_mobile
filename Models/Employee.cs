
namespace RocketElevatorsApi.Models
{
    public class Employee
    {
        public long id { get; set; }

        public string? first_name { get; set; }

        public string? last_name { get; set; }

        public string? title { get; set; }


        public string? email { get; set; }

        public long user_id { get; set; }
    }
}