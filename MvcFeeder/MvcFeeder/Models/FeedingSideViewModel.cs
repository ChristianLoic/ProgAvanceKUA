using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcFeeder.Models
{
    public class FeedingSideViewModel
    {
        public List<BreastFeed> BreastFeeds { get; set; }
        public SelectList Sides { get; set; }
        public string FeedingSide { get; set; }
        public string SearchString { get; set; }
    }
}