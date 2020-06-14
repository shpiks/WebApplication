using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.DAL.Entities;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ProductController : Controller
    {
        public List<Phone> _phones;
        List<PhoneGroup> _phoneGroups;
        int _pageSize;

        public ProductController()
        {
            _pageSize = 3;
            SetupData();
        }
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var dishesFiltered = _phones.Where(d => !group.HasValue || d.PhoneGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _phoneGroups; 

            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
            return View(ListViewModel<Phone>.GetModel(dishesFiltered, pageNo, _pageSize));
        }

        private void SetupData()
        {
            _phoneGroups = new List<PhoneGroup>
            {
                new PhoneGroup { PhoneGroupId = 1, GroupName = "BQ-Mobile" },
                new PhoneGroup { PhoneGroupId = 2, GroupName = "TeXet" },
                new PhoneGroup { PhoneGroupId = 3, GroupName = "Vertex" },
                new PhoneGroup { PhoneGroupId = 4, GroupName = "ZTE" },
                new PhoneGroup { PhoneGroupId = 5, GroupName = "Inoi" },
                new PhoneGroup { PhoneGroupId = 6, GroupName = "Nobby" }
            };

            _phones = new List<Phone>
            { 
                new Phone {PhoneId = 1, PhoneName="TeXet TM-121 (черный)",  Description="экран 1.44 TFT (96x68), аккумулятор 500 мАч, 1 SIM", Price = 19.90, PhoneGroupId=2, Image="TeXet TM-121 (черный).jpg" },
                new Phone { PhoneId = 2, PhoneName="ZTE F327s (черный)",  Description="экран 2.4 TFT (240x320), карты памяти, камера 2 Мп, аккумулятор 1000 мАч, 2 SIM", Price =19.90, PhoneGroupId=4, Image="ZTE F327s (черный).jpg" },
                new Phone { PhoneId = 3, PhoneName="BQ-Mobile BQ-1805 Step (желтый)", Description="экран 1.77 TFT (128x160), ОЗУ 32 Мб, флэш-память 64 Мб, карты памяти, аккумулятор 600 мАч, 2 SIM", Price =20.11, PhoneGroupId=1, Image="BQ-Mobile BQ-1805 Step (желтый).jpeg" },
                new Phone { PhoneId = 4, PhoneName="Vertex M110 (черный)", Description="экран 1.77 TFT (128x160), карты памяти, аккумулятор 800 мАч, 2 SIM", Price =21.00, PhoneGroupId=3, Image="Vertex M110 (черный).jpg" },
                new Phone { PhoneId = 5, PhoneName="TeXet TM-128 (черный-красный)",  Description="экран 1.77 TFT (128x160), карты памяти, аккумулятор 500 мАч, 2 SIM", Price =21.90, PhoneGroupId=2, Image="TeXet TM-128 (черный-красный).jpg" }
            };

        }

    }
}