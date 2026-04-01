using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task4
{
    internal class Task4
    {
        public void Example()
        {
            Order order = new Order
            {
                Id = 1,
                Status = OrderStatusEnum.Pending
            };

            JsonHandler.SerializeJson(order);
        }
    }
}
