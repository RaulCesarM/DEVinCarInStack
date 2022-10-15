using System.ComponentModel.DataAnnotations;
using DEVinCar.Domain.Entities.Models;


namespace DEVinCar.Domain.Entities.DTOs
 {
    public class StateDTO {

        public int Id {get; set;}       
        public string Name { get; set; }        
        public string Initials { get; set; }
        public StateDTO()
        {
        }
        public StateDTO(State state)
        {
            Id = state.Id;
            Name = state.Name;
            Initials = state.Initials;
        }
    }
}
