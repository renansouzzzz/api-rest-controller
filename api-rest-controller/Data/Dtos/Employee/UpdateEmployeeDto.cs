using System.ComponentModel.DataAnnotations;

namespace api_rest_controller.Data.Dtos.Employee
{
    public class UpdateEmployeeDto
    {
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }
    }
}
