using System.Globalization;


namespace Models
{
    public class SearchModel
    {
        public int? CityId { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int? AmountOfGuests { get; set; }

        public DateTime GetStartDate()
        {
            DateTime startDate = DateTime.ParseExact(StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return new DateTime(startDate.Year, startDate.Month, startDate.Day, 16, 0, 0);
        }

        public DateTime GetEndDate()
        {
            DateTime endTime = DateTime.ParseExact(EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return new DateTime(endTime.Year, endTime.Month, endTime.Day, 11, 0, 0);

        }

        public void Setup()
        {
            if (StartDate == null)
            {
                //StartDate = new DateTime(DateTime.Today.Year,DateTime.Today.Month, DateTime.Today.Day, 16, 0, 0).ToString("dd/MM/yyyy HH:mm");
                StartDate = DateTime.Today.ToString("dd/MM/yyyy");
                //EndDate = .AddDays(3).ToString("dd/MM/yyyy HH:mm");
                EndDate = DateTime.Today.AddDays(3).ToString("dd/MM/yyyy");
            }
        }
    }
}
