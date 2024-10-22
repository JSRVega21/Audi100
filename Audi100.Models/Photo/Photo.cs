using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audi100.Models
{
    public class Photo : IRecordLogger
    {
        public int PhotoId { get; set; }
        public byte[]? BytePhone { get; set; }
        public byte[]? BytePdf { get; set; }
        public int AuditFindingId { get; set; }
        public RecordLog? RecordLog { get; set; } = new RecordLog();
    }
}
