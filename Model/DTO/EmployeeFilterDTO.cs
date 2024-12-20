namespace EmployeeService.Model.DTO
{
    public class EmployeeFilterDTO
    {
        public string City { get; set; }
        public int? Age { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
    }
}
