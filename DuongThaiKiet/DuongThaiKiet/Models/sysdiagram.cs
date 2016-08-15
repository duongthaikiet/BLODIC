using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DuongThaiKiet.DTKEF
{
    [MetadataType(typeof(ISysdiagramMetadata))]
    public partial class sysdiagram : ISysdiagramMetadata
    {
        
    }

    public interface ISysdiagramMetadata
    {
        [Key]
        int diagram_id { get; set; }
    }
}