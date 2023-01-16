using BookShopWeb.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model
{
	public class Product
	{
		public int Id { get; set; }
		[Required]
		public string Title{ get; set; }
		public string Description { get; set; }
		[Required]
		public string ISBN { get; set; }
		[Required]
		public string Author { get; set; }
		[Required]
		[Range(1,10000)]
		public double ListPrice { get; set; }
		[Required]
		[Range(1,10000)]
		public double Price { get; set; }
		[Required]
		[Range(1, 10000)]
		public double Price50 { get; set; }
		[Required]
		[Range(1, 10000)]
		public double Price100 { get; set; }
		[ValidateNever]
		public string ImageURL { get; set; }


		// this is to make foreign key for category id in product class and table
		[Required]
		public int CategoryId { get; set; }
		[ForeignKey("CategoryId")]// this is optional , not required , if there is end with 'Id'
		[ValidateNever]
		public Category Category { get; set; }


		// this is to make foreign key for CoverType id in product class and table
		[Required]
		public int CovertypeId { get; set; }
		[ValidateNever]
		public CoverType CoverType { get; set; }

	}
}
