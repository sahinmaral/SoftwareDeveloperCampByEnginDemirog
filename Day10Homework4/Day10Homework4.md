# In English 
In your Car Rental project; 

Create users table. Users-->Id,FirstName,LastName,Email,Password

Create customers table. Customers-->UserId,CompanyName

Users and customers are related.

Create a table to store car's rental information. Rentals-->Id, CarId, CustomerId, RentDate(Renting Date), ReturnDate(Delivery Date).
If car has not been delivered , then ReturnDate will be null.

Create that entities and write CRUD operations to this entities.

Add new customers

Code the opportunity to rent the car.Rental-->Add. 
In order for the car to be rented, the car must be delivered. 


# In Turkish 

CarRental projenizde;

Kullanıcılar tablosu oluşturunuz. Users-->Id,FirstName,LastName,Email,Password

Müşteriler tablosu oluşturunuz. Customers-->UserId,CompanyName

*****Kullanıcılar ve müşteriler ilişkilidir.

Arabanın kiralanma bilgisini tutan tablo oluşturunuz. Rentals-->Id, CarId, CustomerId, RentDate(Kiralama Tarihi), ReturnDate(Teslim Tarihi). Araba teslim edilmemişse ReturnDate null'dır.

Projenizde bu entity'leri oluşturunuz.
CRUD operasyonlarını yazınız.

Yeni müşteriler ekleyiniz.

Arabayı kiralama imkanını kodlayınız. Rental-->Add
Arabanın kiralanabilmesi için arabanın teslim edilmesi gerekmektedir.

