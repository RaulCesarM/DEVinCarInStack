namespace DEVinCar.Domain.Entities.DTOs
{
    public class AddressPatchDTO
    {
       
        public string Street { get; set; }       
        public string Cep { get; set; }
        public int Number { get; set; }     
        public string Complement { get; set; }

    }
}