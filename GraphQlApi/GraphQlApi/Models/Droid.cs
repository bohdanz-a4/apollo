using System.Collections.Generic;

namespace GraphQlApi.Models
{
    public class Droid
    {
        public string Name { get; set; }
        public List<Episodes> AppearsIn { get; set; }
    }
}
