
using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Domain.Entities.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }

        public virtual List<City> Cities { get; set; }

        public State()
        {            
        }

        public State(StateDTO stateDTO)
        {
            Id = stateDTO.Id;
            Name = stateDTO.Name;
            Initials = stateDTO.Initials;
        }

        public void Update(StateDTO stateDTO)
        {
            Id = stateDTO.Id;
            Name = stateDTO.Name;
            Initials = stateDTO.Initials;
        }

        public State(int id, string name, string initials)
        {
            Id = id;
            Name = name;
            Initials = initials;
        }
    }
}