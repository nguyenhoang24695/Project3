using NgoProjectk3.Models;

namespace NgoProjectk3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NgoProjectk3.DataContext.NgoProjectk3Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "NgoProjectk3.DataContext.NgoProjectk3Context";
        }

        protected override void Seed(NgoProjectk3.DataContext.NgoProjectk3Context context)
        {
            Random rnd = new Random();
            context.Categories.AddOrUpdate(x=>x.Id,
                new Category(){Id = 1,Name = "PoorKid",Description = "About PoorKid" },
                new Category() { Id = 2, Name = "Education",Description = "Education" },
                new Category() { Id = 3, Name = "Animal",Description = "Animal" });
            context.DonatePrograms.AddOrUpdate(x=>x.Id,
                new DonateProgram(){Id = 1,Name = "‘A BIKE TO A CHILD’ FUND",Amount = 12000,CategoryId = 1,
                    Content = "Throughout the 25 years of our work supporting Vietnamese children in overcoming barriers to education," +
                              " we saw many underprivileged children still struggling to continue their education. One of the most common" +
                              " reasons is financial difficulties, leading many to feel discouraged in pursuing their education as their" +
                              " families were unable to afford the costs of attending school.\r\n\r\nFor many of these children, it can take" +
                              " as long as two to three hours to go to school and back home every day. It’s not only a matter of time, but also" +
                              " of safety and health that continues to weigh heavy on the students and their families, begging the question, how " +
                              "many children can continue their studies in these conditions?\r\n\r\nA gift of a bike would provide a student with an" +
                              " opportunity to overcome such barriers and continue their education, saigonchildren is asking you to support our “A Bike" +
                              " to a Child” fund – aiming to give 100 bicycles to children in need.\r\n\r\nThis fund provides support for disadvantaged" +
                              " children to be able to go school. This will open the door to a brighter future.",
                    ThumbnailUrl = "http://www.saigonchildren.com/wp-content/uploads/2017/09/FINALLLLLLLL.jpg",
                    StartedAt = DateTime.Now,
                    EndedAt = DateTime.Now.AddDays(rnd.Next(3,10))
                },
                new DonateProgram()
                {
                    Id = 2,
                    Name = "‘CHALLENGE DAY",
                    Amount = 5000,
                    CategoryId = 1,
                    Content = "The Corporate Challenge Day programme seeks to supplement insufficient school maintenance budgets through corporate contributions and volunteer work as a means of maintaining and improving the functionality of the schools. Whether painting the walls or planting a garden, we can guarantee you and your team a memorable day with long–lasting team and individual benefits.\r\n\r\nThe 2017 Challenge Day programme is focused on improving the landscaping and infrastructure of the schools and kindergartens we build and work with.",
                    ThumbnailUrl = "http://www.saigonchildren.com/wp-content/uploads/2017/12/BASF-2.jpg",
                    StartedAt = DateTime.Now,
                    EndedAt = DateTime.Now.AddDays(rnd.Next(3, 10))
                },
                new DonateProgram()
                {
                    Id = 3,
                    Name = "Child Development Scholarship Programme",
                    Amount = 25000,
                    CategoryId = 1,
                    Content = "The mission of saigonchildren is to remove barriers to education for disadvantaged children in Vietnam. Over the past 25 years, saigonchildren has provided thousands of scholarships to poor children each year. There are still many children living in Vietnam that do not receive the support they need to be able to attend school.\r\n\r\nsaigonchildren knows how to help, but we can only do this with the support of our donors. Together, we can provide opportunities for disadvantaged children to access quality education and have a brighter future.\r\n\r\nAny support from you makes a big difference and is greatly appreciated, whether it is a small or large amount.",
                    ThumbnailUrl = "http://www.saigonchildren.com/wp-content/uploads/2017/12/3-4.jpg",
                    StartedAt = DateTime.Now,
                    EndedAt = DateTime.Now.AddDays(rnd.Next(10, 15))
                },
                new DonateProgram()
                {
                    Id = 4,
                    Name = "Event: April 13th: Nail Trim at Thrift Store",
                    Amount = 100,
                    CategoryId = 3,
                    Content = "Bring your pet into the ABC Thrift Store for a nail trim by Labs Tested Mobile Dog Grooming. All donations will go to Animal Based Charities, Inc.\r\n\r\nWhere?\r\nABC Thrift Store, 4465 W. Gandy Blvd, Suite 315, Tampa, FL 33611. The store is behind YouFit and faces Oakellar Ave.",
                    ThumbnailUrl = "https://animalbasedcharities.org/wp-content/uploads/2014/06/300px-Dog_Paw.jpg",
                    StartedAt = DateTime.Now,
                    EndedAt = DateTime.Now.AddDays(rnd.Next(1, 10))
                },
                new DonateProgram()
                {
                    Id = 5,
                    Name = "Aid for Angela",
                    Amount = 5000,
                    CategoryId = 2,
                    Content = "Her name is Angela. She found me on the side of the road, bleeding and confused, in such shock i didnt even realize I\'d been injured, used google translate to tell me \"I want to give you love\" before applying her own scarf to wrap my bloodied knee. She parked my motorbike around the corner and took me on the back of her scooter to the nearest hospital. For those who have been to Vietnam, you might know what it means to check in to a rural hospital.  Mine was a dirty and dark place and I was terrified. \r\n\r\nBut Angela stayed with me the entire time. She held my hand as they cut the loose skin away from my knee, and wiped my tears as they stitched me back together. She washed the blood off my face and out of my hair, and helped me use the bathroom. While I waited for a friend to get to the hospital, she kept me company, using Google translate to talk back and forth.  When my friend arrived, she offered to store my motorbike for me until I figured out what to do with it. She’s messaged me on whatsapp every day, with Google translate still playing its part; sometimes she\'ll video call just to wave and say hello. After 3 days, she visited me at my hostel with her 10 year old son, who knew enough english to help us translate a little. She invited myself and my friend for dinner at her home, and that night we ate the most amazing, home cooked meal with her family. Angela pushed me in my wheelchair to show me around her home town. ",
                    ThumbnailUrl = "https://d2g8igdw686xgo.cloudfront.net/37701036_1552409067101592_r.jpeg",
                    StartedAt = DateTime.Now,
                    EndedAt = DateTime.Now.AddDays(rnd.Next(1, 10))
                });
        }
    }
}
