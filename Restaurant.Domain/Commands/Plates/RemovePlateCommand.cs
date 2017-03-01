using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Commands.Plates
{
    public class RemovePlateCommand
    {
        public int PlateId { get; set; }
        public int RestaurantId { get; set; }

        public RemovePlateCommand(int plateId, int restaurantId)
        {
            PlateId = plateId;
            RestaurantId = restaurantId;
        }
    }
}
