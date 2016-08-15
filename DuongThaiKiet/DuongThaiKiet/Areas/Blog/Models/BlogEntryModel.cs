using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DuongThaiKiet.DTKEF
{
    public interface IBlogEntryMetadata
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        DateTime? DateCreated { get; set; }

        [DisplayName("Title")]
        string Title { get; set; }

        [DisplayName("Summary")]
        string Summary { get; set; }

        [DisplayName("Created By")]
        int? UserId { get; set; }

        //TODO: Allow HTML Mark ups
        [AllowHtml]
        [DisplayName("Content")]
        string Content { get; set; }
    }

    //TODO: Allow data annotation retained after updating EF model from database
    [MetadataType(typeof (IBlogEntryMetadata))]
    public partial class BlogEntry : IBlogEntryMetadata
    {

    }

    public class BlogEntryModel : BlogEntry
    {
        public string UserName = string.Empty;
        public string SortingColume = string.Empty;
        public BlogEntryModel()
        {
            
        }
    }
}