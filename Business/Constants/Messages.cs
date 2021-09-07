using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    { 
        public static string BrandAdded = "Marka Eklendi.";
        public static string BrandDeleted="Marka Silindi.";
        public static string BrandUpdated="Marka Güncellendi.";
        public static string CarListed="Araba Listelendi.";
        public static string CarAdded="Araba Eklendi.";
        public static string CarDeleted="Araba Silindi.";
        public static string CarUpdated="Araba Güncellendi";
        public static string BrandListed="Marka Listelendi.";
        public static string ColorAdded="Resim Eklendi.";
        public static string ColorDeleted="Resim Silindi.";
        public static string ColorListed="Resim Listelendi.";
        public static string ColorUpdated="Resim Güncellendi.";
        public static string CustomerAdded="Müşteri Eklendi.";
        public static string CustomerDeleted="Müşteri Silindi.";
        public static string CustomerListed="Müşteri Listelendi.";
        public static string CustomersListed="Müşteriler Listelendi.";
        public static string CustomerUpdated="Müşteri Güncellendi.";
        public static string ColorsListed="Resimler Listelendi.";
        public static string CarsListed="Arabalar Listelendi.";
        public static string BrandsListed="Markalar Listelendi.";
        public static string RentalAdded="Kiralama Başarılı.";
        public static string RentalListed="Kiralama Gösterildi.";
        public static string RentalsListed="Kiralamalar Listelendi.";
        public static string RentalUpdated="Kiralama Bilgisi Güncellendi.";
        public static string CarImageAdded="Araba Resmi Eklendi.";
        public static string CarImageInvalid="Araba Resmi Eklenemedi.";
        public static string CarImageDeleted="Araba Resmi Silindi.";
        public static string CarImageDeletedInvalid="Araba Resmi Silinemedi.";
        public static string CarImageListed="Araba Resmi Listelendi.";
        public static string CarImagesListed="Araba Resimleri Listelendi.";
        public static string CarImageUpdated="Araba Resmi Güncellendi.";
        public static string CarImageUpdatedInvalid="Araba Resmi Güncellenemedi.";
        public static string CarImageLimited="Bir Arabaya Eklenecek Resim Limiti Aşıldı.";
        public static string CarImageAddedInvalid="Araba Resmi Eklenemedi.";
        public static string AuthorizationDenied="Yetkiniz Yok!";
        public static string UserRegistered="Kayıt Başarılı.";
        public static string UserNotFound="Kullanıcı Bulunamadı.";
        public static string PasswordError="Şifre Hatalı.";
        public static string SuccessfulLogin="Giriş Başarılı.";
        public static string AccessTokenCreated="";
        public static string UserAlreadyExists="Kullanıcı Mevcut.";
    }
}
