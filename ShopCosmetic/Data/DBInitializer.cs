using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShopCosmetic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.Data
{
    public class DBInitializer
    {
        public static void Start(AppDBContext context)
        {
           
         
            if(!context.Category.Any())
                context.Category.AddRange(Categories.Select(c => c.Value));
            
            if (!context.Cosmetic.Any())
            {
                context.AddRange(
                    new Cosmetic
                    {
                        Name = "YADAH pore refining foam cleanser ",
                        Price = 975,
                        ShortDescription = "ОЧИЩАЮЩАЯ ПЕНКА ДЛЯ СУЖЕНИЯ ПОР",
                        LongDescription = "Мягкая пенка YADAH нежно удаляет загрязнения и избыток себума, не вызывая ощущения сухости и стянутости. В состав входит экстракт яичного белка, который глубоко очищает кожу и улучшает её тон. Минеральная вода также способствует глубокому очищению, а гидролат лотоса помогает сузить поры и успокаивает чувствительную кожу.",
                        Category = Categories["Уход для лица"],
                        Image = "/img/cleanser.jpg",
                        InStock = true,
                        IsPreferredCosmetic = true
                    },
                     new Cosmetic
                     {
                         Name = "ISADORA mascara volume 2.0",
                         Price = 591,
                         ShortDescription = "Тушь для ресниц",
                         LongDescription = "Тушь для ресниц IsaDora Mascara Volume 2.0 обладает массой достоинств. У нее эластичная фактура, удобная щеточка, насыщенный пигмент. Поэтому краска великолепно ложится на реснички, увеличивает их объем, придаваем им визуальную густоту. Тушь Mascara Volume 2.0 устойчива к влаге. В течение всего дня она не размазывается, не осыпается. Женщина может не беспокоиться по поводу своего макияжа, если вдруг попадет под дождь или слегка всплакнет. В формуле этой туши для ресниц отсутствуют ароматические и аллергические вещества. Клиническое тестирование подтвердило безопасность ее использования.",
                         Category = Categories["Макияж"],
                         Image = "/img/mascara.jpg",
                         InStock = true,
                         IsPreferredCosmetic = false
                     },
                      new Cosmetic
                      {
                          Name = "ESTEL curex therapy",
                          Price = 540,
                          ShortDescription = "ИНТЕНСИВНАЯ МАСКА ДЛЯ ПОВРЕЖДЕННЫХ ВОЛОС",
                          LongDescription = "Интенсивная маска для поврежденных волос Estel Curex Therapy питает и укрепляет ослабленную структуру. Нарушение целостности строения клеток и тканей вызывает ломкость, потускнение и истончение локонов. Маска Curex Therapy призвана обеспечить оптимальный уровень увлажнения и нормализовать питание. В течение нескольких минут воздействия средство обогащает волосы натуральными микроэлементы, свойства которых способны оживить, придать блеск и силу. Постепенно травмированные волосы становятся более эластичными, плотными и защищенными от внешнего неблагоприятного воздействия.",
                          Category = Categories["Уход за волосами"],
                          Image = "/img/hair.jpg",
                          InStock = true,
                          IsPreferredCosmetic = false
                      },
                       new Cosmetic
                       {
                           Name = "ECOOKING shower gel",
                           Price = 1600,
                           ShortDescription = "ГЕЛЬ ДЛЯ ДУША",
                           LongDescription = "Гель для душа мягко очищает кожу тела и дарит ощущение свежести. В состав входит органический глицерин, делающий кожу мягкой и сияющей. Гидролаты алоэ вера и огурца помогают увлажнить и успокоить кожу. Для всех типов кожи.",
                           Category = Categories["Уход для тела"],
                           Image = "/img/gel.jpg",
                           InStock = true,
                           IsPreferredCosmetic = true
                       }
                    );

            }
            context.SaveChanges();

        }

       

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var List = new Category[]
                    {
                        new Category { CategoryName = "Уход для лица", Description = "Все товары категории" },
                        new Category { CategoryName = "Уход для тела", Description = "Все товары категории" },
                        new Category { CategoryName = "Уход за волосами", Description = "Все товары категории" },
                        new Category { CategoryName = "Макияж", Description = "Все товары категории" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in List)
                        categories.Add(genre.CategoryName, genre);
                    
                }
                return categories;
            }
        }
    }
}
