using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Crawler
{
    internal class UriFilter
    {
        static List<Uri> _values = new List<Uri>();
        private Uri _root;
        public UriFilter(Uri root)
        {
            _root = root;
            hasNotVisitedLink(root);
        }

        public List<Uri> Filter(IEnumerable<Uri> input)
        {
            return input.Where(i => i != _root && getBaseDomain(_root).Equals(getBaseDomain(i)) && hasNotVisitedLink(i)).ToList();
        }

        private string getBaseDomain(Uri uri)
        {
            var tokens = uri.Host.Split('.').Reverse().Take(2).Reverse();
            return String.Join(".", tokens);
        }
        private bool hasNotVisitedLink(Uri value)
        {
            if (_values.Contains(value))
            {
                return false;
            }
            else
            {
                _values.Add(value);
            }
            return true;
        }
    }

 }
