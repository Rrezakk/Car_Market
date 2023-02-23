namespace Market.Domain.ViewModels.Order
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        
        public string Manufacturer { get; set; }
        
        public string Model { get; set; }
        
        // other props
        
        public string Type { get; set; }
        
        public string ImageUrl { get; set; }
        
        
        //billing info
        
        public string Address { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string DateCreate { get; set; }
    }   
}
