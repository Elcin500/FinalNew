using FinalNew.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalNew.Models.ViewModels
{
    public class AnnouncesPagedViewModel
    {
        public AnnouncesPagedViewModel(IOrderedQueryable<Home> data, int pageIndex, int pageSize)
        {
            this.TotalCount = data.Count();
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;

            this.Homes = data.Skip((PageIndex - 1) * PageSize).Take(PageSize);
        }

        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int TotalCount { get; private set; }

        public int MaxCount
        {
            get
            {
                return (int)Math.Ceiling(TotalCount * 1.0 / PageSize);
            }
        }

        public IEnumerable<Home> Homes { get; private set; }


        public string GetPagenation(IUrlHelper url, string action, object announceType, object categoryId, object cityId, object metroId,
            object minPrice, object maxPrice, object minArea, object maxArea, object minRoom, object minBath)
        {
            if (TotalCount <= PageSize)
                return "";

            StringBuilder sb = new StringBuilder();
            sb.Append("<ul  class='pagination'>");

            if (PageIndex > 1)
            {
                var link = (url.Action(action, values: new
                {
                    pageIndex = PageIndex - 1,
                    pageSize = this.PageSize,
                    announceType=announceType,
                    categoryId= categoryId,
                    cityId= cityId,
                    metroId = metroId,
                    minPrice = minPrice,
                    maxPrice = maxPrice,
                    minArea = minArea,
                    maxArea = maxArea,
                    minRoom = minRoom,
                    minBath = minBath
                }));

                sb.Append($"<li class='page-item'><a class='page-link' href='{link}' aria-label='Previous'><span aria-hidden='true'>&laquo;</span></a></li>");
            }
            else
            {
                sb.Append("<li class='page-item disabled'><a class='page-link' href='#' aria-label='Previous'><span aria-hidden='true'>&laquo;</span></a></li>");
            }


            for (int i = 1; i <= MaxCount; i++)
            {

                if (i == PageIndex)
                {
                    sb.Append($"<li class='page-item active'><a class='page-link' href='#'>{i}</a></li>");
                }
                else
                {
                    var link = (url.Action(action, values: new
                    {
                        pageIndex = i,
                        pageSize = this.PageSize,
                        announceType = announceType,
                        categoryId = categoryId,
                        cityId = cityId,
                        metroId = metroId,
                        minPrice = minPrice,
                        maxPrice = maxPrice,
                        minArea = minArea,
                        maxArea = maxArea,
                        minRoom = minRoom,
                        minBath = minBath
                    }));
                    sb.Append($"<li class='page-item'><a class='page-link' href='{link}'>{i}</a></li>");
                }

            }

            if (PageIndex < MaxCount)
            {
                var link = (url.Action(action, values: new
                {
                    pageIndex = PageIndex + 1,
                    pageSize = this.PageSize,
                    announceType = announceType,
                    categoryId = categoryId,
                    cityId = cityId,
                    metroId = metroId,
                    minPrice = minPrice,
                    maxPrice = maxPrice,
                    minArea = minArea,
                    maxArea = maxArea,
                    minRoom = minRoom,
                    minBath = minBath
                }));

                sb.Append($"<li class='page-item'><a class='page-link' href='{link}' aria-label='Next'><span aria-hidden='true'>&raquo;</span></a></li>");
            }
            else
            {
                sb.Append("<li class='page-item disabled'><a class='page-link' href='#' aria-label='Next'><span aria-hidden='true'>&raquo;</span></a></li>");
            }

            sb.Append("</ul>");


            return sb.ToString();
        }
    }
}
