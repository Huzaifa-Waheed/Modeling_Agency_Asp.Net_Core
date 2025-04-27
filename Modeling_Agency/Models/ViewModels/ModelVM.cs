using Modeling_Agency.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace Modeling_Agency.Models.ViewModels
{
    public class ModelVM
    {
        public Model model { set; get; }
        public IEnumerable<HireRecord> hireRecords { set; get; }
        public IEnumerable<Messages> messages { set; get; }
    }
}
