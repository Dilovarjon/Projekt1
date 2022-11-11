using ConsoleApp1.Enums;
using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Services
{
    public class TransitServices : ITransit
    {
        public Transit Transit(Guid Id)
        {
            var transit = new Transit();

            using (var db = new ApplicationContext())
            {
                Console.Write("Какую сумму хотите конвертировать: ");
                var check = decimal.TryParse(Console.ReadLine(), out decimal result);

                var moneuAccaunt = db.Acconts.Where(x => x.UserId == Id).FirstOrDefault();
                //transit.Id = Id;
                if (result <= moneuAccaunt?.TJK)
                {
                    moneuAccaunt.TJK -= result;
                    transit.Amout = result;
                }
                else { Console.WriteLine("У вас не хватает на счету денег"); }

                Console.WriteLine("Из сомони в какую валюту хотите сконвертировать?\n" +
                    "Если 1 то в доллары\n" +
                    "Если 2 то в рублей");

                var check1 = decimal.TryParse(Console.ReadLine().Trim(), out decimal result1);
                Guid currey;
                string cur;
                if (result1 == 1)
                {
                    currey = CurrencyEnum.USD;
                    cur = "USD";
                }
                else
                {
                    currey = CurrencyEnum.RUB;
                    cur = "RUB";
                }
                transit.from_currency = "TJS";
                transit.to_currency = cur;

                transit.cur_rate = db.Currencies.Where(x => x.Id == currey).Select(x => x.Rate).FirstOrDefault();

                transit.converted_amount = transit.Amout / transit.cur_rate;

                if (result1 == 1)
                {
                    moneuAccaunt.USD += transit.converted_amount;
                }
                else
                {
                    moneuAccaunt.RUB += transit.converted_amount;
                }
                transit.UserId = Id;

                db.Acconts.Update(moneuAccaunt!);
                db.TransitAccounts.Add(transit);
                db.SaveChanges();
            }

            return transit;
        }
    }
}
