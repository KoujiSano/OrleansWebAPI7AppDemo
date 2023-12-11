using Microsoft.AspNetCore.Mvc;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("Accounting/[controller]")]
    public class BirthdayController : ControllerBase
    {

        private readonly IGrainFactory _grains;

        public BirthdayController(IGrainFactory grains)
        {
            _grains = grains;
        }

        /// <summary>
        /// 誕生日が今日から何日前かと、その曜日を計算します
        /// </summary>
        /// <param name="birthdate">誕生日（yyyy/MM/dd形式）</param>
        /// <returns>誕生日が今日から何日前かと、その曜日</returns>
        [HttpGet()]
        [Route("CalculateDaysAgoAndDayOfWeek")]
        public ActionResult<string> CalculateDaysAgoAndDayOfWeek(string birthdate)
        {
            if (DateTime.TryParseExact(birthdate, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime birthdateDateTime))
            {
                // 現在の日時を取得
                DateTime currentDate = DateTime.Now;

                // 誕生日と現在の日時の差を計算
                TimeSpan difference = currentDate - birthdateDateTime;

                // 結果を文字列として返す
                return Ok($"{difference.Days}日前, {birthdateDateTime.DayOfWeek}");
            }
            else
            {
                return BadRequest("無効な日付形式です。");
            }
        }
    }
}
