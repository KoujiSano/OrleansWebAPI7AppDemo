using Microsoft.AspNetCore.Mvc;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("Accounting/[controller]")]
    public class GetnameController : ControllerBase
    {

        private readonly IGrainFactory _grains;

        public GetnameController(IGrainFactory grains)
        {
            _grains = grains;
        }
        /// <summary>
        /// おなまえを取得します
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("")]
        public IList<string> Index()
        {
            var items = new List<string>();
            // ↓↓　一般的にはデータベースから取得する
            // SELECT * FROM AccountItem;
            items.Add("たなか");
            items.Add("しぐれ");
            // ↑↑　
            return items;
        }

    }
}
