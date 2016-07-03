using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace code.fun.do_HealthCare_Cycle_1
{
    public class DoctorInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RegNo { get; set; }
        public string Qualification { get; set; }
        public string Address { get; set; }

        public DoctorInfo() { }

        public void LoadFromHtmlDocument(HtmlDocument htmlIMRNumberSearch)
        {
            HtmlNode htmlnode = htmlIMRNumberSearch.DocumentNode.FirstChild;
            htmlnode = htmlnode.ChildNodes[2];
            htmlnode = htmlnode.ChildNodes[7];
            htmlnode = htmlnode.ChildNodes[1];
            htmlnode = htmlnode.ChildNodes[1];
            HtmlNode node = htmlnode.ChildNodes[4];
            node = node.ChildNodes[3];
            node = node.ChildNodes[1];
            Name = node.InnerText;
            node = htmlnode.ChildNodes[10];
            node = node.ChildNodes[3];
            node = node.ChildNodes[1];
            RegNo = node.InnerText;
            node = htmlnode.ChildNodes[14];
            node = node.ChildNodes[3];
            node = node.ChildNodes[1];
            Qualification = node.InnerText;
            node = htmlnode.ChildNodes[24];
            node = node.ChildNodes[3];
            node = node.ChildNodes[1];
            Address = node.InnerText;
        }
    }
}
