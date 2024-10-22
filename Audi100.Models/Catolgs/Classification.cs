using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audi100.Models
{
    public class Classification : IRecordLogger
    {
        public int ClassificationId { get; set; }
        public string Description { get; set; }
        public RecordLog? RecordLog { get; set; } = new RecordLog();
    }
}
