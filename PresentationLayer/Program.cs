using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Linq;

namespace PresentationLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LocationManager locationManager = new LocationManager(new EfLocationDal());
            MemberManager memberManager = new MemberManager(new EfMemberDal());
            CommentManager commentManager = new CommentManager(new EfCommentDal());

            void LocationList()
            {
                var values = locationManager.TGetAll();
                foreach (var item in values)
                {
                    Console.WriteLine(item.LocationName);
                }
            }
            void MemberList()
            {
                var values = memberManager.TGetAll();
                foreach (var item in values)
                {
                    Console.WriteLine(item.Name);
                }
            }
            void CommentList()
            {
                var values = commentManager.TGetAll();
                foreach (var item in values)
                {
                    Console.WriteLine(item.CommentContent);
                }
            }

            void LocationAdd()
            {

                Location location = new Location();
                location.LocationName = "Rotterdam";
                LocationValidator locationValid = new LocationValidator();
                ValidationResult result = locationValid.Validate(location);
                if (result.IsValid)
                {
                    locationManager.TInsert(location);
                    Console.WriteLine("Kayıt Eklendi");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        Console.WriteLine(item.ErrorMessage);
                    }
                }
            }
            void MemberAdd()
            {
                Member member = new Member();
                member.Name = "Ad";
                member.Surname = "Soyad";
                MemberValidator validator = new MemberValidator();
                ValidationResult result = validator.Validate(member);
                if (result.IsValid)
                {
                    memberManager.TInsert(member);
                    Console.WriteLine("Üye başarılı bir şekilde eklendi");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        Console.WriteLine(item.ErrorMessage);
                    }
                }
            }
            void CommentAdd()
            {
                Comment comment = new Comment();
                comment.CommentContent = "İçerik";
                comment.CommentId = 1;
                comment.MemberId = 2;
                comment.Status = true;
                CommentValidator validation = new CommentValidator();
                ValidationResult result = validation.Validate(comment);
                if (result.IsValid)
                {
                    commentManager.TInsert(comment);
                    Console.WriteLine("Kayıt Eklendi");
                }
                else
                {
                    foreach (var item in result.Errors)
                    { Console.WriteLine(item.ErrorMessage); }
                }
            }

            void LocationDelete()
            {
                var id = locationManager.TGetById(0);
                locationManager.TDelete(id);
            }
            void MemberDelete()
            {
                var id = memberManager.TGetById(0);
                memberManager.TDelete(id);
            }
            void CommentDelete()
            {
                var id = commentManager.TGetById(0);
                commentManager.TDelete(id);
            }

            void LocationUpdate()
            {
                var value = locationManager.TGetById(0);
                value.LocationName = "İstanbul";
                locationManager.TUpdate(value);
                LocationList();
            }
            void MemberUpdate()
            {
                var value = memberManager.TGetById(0);
                value.Surname = "Güncel Soyad";
                value.Name = "Güncel AD";
                memberManager.TUpdate(value);
                MemberList();
            }
            void CommentUpdate()
            {
                var values = commentManager.TGetById(0);
                values.CommentId = 2;
                values.CommentContent = "denemee";
                values.MemberId = 3;
                values.Status = false;
                commentManager.TUpdate(values);
                CommentList();
            }

            void CommentJoinLocation()
            {
                NTierContext context = new NTierContext();
                var yorumlar = (from l in context.Locations
                                join c in context.Comments
                                on l.LocationId equals c.LocationId
                                select new
                                {
                                    c.CommentId,
                                    l.LocationName,
                                    c.CommentContent,
                                }).ToList();
                foreach (var item in yorumlar)
                {
                    Console.WriteLine(item.CommentId + " " + item.LocationName + " " + item.CommentContent);
                }
            }

            void CommentJoinDal()
            {
                commentManager.TCommentLitsWithLocationAndMember();
            }


            Console.ReadLine();
        }
    }
}
