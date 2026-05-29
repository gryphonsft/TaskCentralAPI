# Task Central API
### Şirket içi ekiplerin görev oluşturmasını, atamasını, takibini ve ilerleme durumlarını yönetmesini sağlayan çok kullanıcılı bir görev yönetim sistemi API'si.
# Teknoloji ve Özellikler

Bu proje aşağıdaki teknolojileri ve mimarileri kullanmaktadır:

- **.NET Core 8.0** - Web API framework
- **MS SQL Server** - Veritabanı
- **Entity Framework Core** - ORM (Object-Relational Mapping)
- **JWT (JSON Web Token)** - Kimlik doğrulama
- **Katmanlı Mimari** - Temiz kod yapısı ve sürdürülebilirlik
- **DTO (Data Transfer Objects)** - Veri transfer nesneleri ile veri aktarımı
- **Role-Based Authorization** - Rol bazlı yetkilendirme
# Katman isimleri ve özellikleri

- **Presentation Layer (API)** - HTTP isteklerini karşılayan controller'lar
- **Application Layer** -  İş mantığı ve kuralları
- **Infrastructure Layer** - Veritabanı işlemleri 
- **Domain Layer** - DTO'lar, entity'ler ve ortak yapılar 

## API Endpoints

### 🔐 Auth (Kimlik Doğrulama)

#### POST `/api/auth/login`
Kullanıcı girişi yapar ve JWT token döner.

**Request Body:**
```json
{
  "email": "user@example.com",
  "password": "password123"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "message": "Giriş başarılı"
}
```

### POST /api/auth/register
Yeni kullanıcı kaydı oluşturur.

**Request Body:**
```json
{
  "Username": "ahmet123",
  "FullName": "Ahmet Yılmaz",
  "Email": "ahmet@example.com",
  "Password": "SecurePass123!"
}
```
**Response:**
```json
{
  "email": "ahmet@example.com",
  "message": "Kayıt başarılı"
}
```
### GET /api/auth/getall
Sistemdeki tüm kullanıcıları listeler (Admin yetkisi gerektirir).

**Response:**
``` json
  {
    "Username": "ahmet123",
    "FullName": "Ahmet Yılmaz",
    "Email": "ahmet@example.com",
    "Roles": ["User"]
  }
```

### 📁 Project (Proje Yönetimi)
### GET /api/project/getall
Kullanıcının erişim yetkisi olan tüm projeleri listeler.
Response:

```json
  {
    "name": "Web Sitesi Yenileme",
    "description": "Kurumsal web sitesinin yeniden tasarlanması",
    "createdDate": "2024-11-01T09:00:00Z",
    "status": "Active"
  }
```
### GET /api/project/get/{id}
Belirli bir projenin detaylarını getirir.
Response:
```json
{
  "name": "Web Sitesi Yenileme",
  "description": "Kurumsal web sitesinin yeniden tasarlanması",
  "createdDate": "2024-11-01T09:00:00Z",
  "status": "Active",
  "tasks": []
}
```
### POST /api/project/create
Yeni proje oluşturur (Manager/Admin yetkisi gerektirir).
Request Body:
```json 
{
  "name": "Mobil Uygulama",
  "description": "iOS ve Android mobil uygulama geliştirme projesi"
}
```
### PUT /api/project/update/{id}
Var olan projeyi günceller (Manager/Admin yetkisi gerektirir).
Request Body:
```json
{
  "name": "Mobil Uygulama v2",
  "description": "Güncellenmiş proje açıklaması",
  "status": "Completed"
}
```
### DELETE /api/project/delete/{id}
#### Projeyi siler (Admin yetkisi gerektirir). Proje silme işlemi cascade delete ile ilişkili tüm görevleri de siler.

### GET /api/project/search?keyword={keyword}
#### Proje adı veya açıklamasında arama yapar.
### Query Parameters:

```json
{
  "keyword": "Aranacak kelime"
}
```
Response:
```json
  {
    "name": "Web Sitesi Yenileme",
    "description": "Kurumsal web sitesinin yeniden tasarlanması"
  }
```

### ✅ Task (Görev Yönetimi)
### GET /api/task/getall
Kullanıcının erişebildiği tüm görevleri listeler.
Response:
``` json
  {
    "id": 1,
    "title": "Ana Sayfa Tasarımı",
    "description": "Responsive ana sayfa tasarımı yapılacak",
    "status": "InProgress",
    "priority": "High",
    "dueDate": "2024-12-15T00:00:00Z",
    "assignedTo": "Ahmet Yılmaz",
    "projectName": "Web Sitesi Yenileme"
  }

```
### GET /api/task/get/{id}
Belirli bir görevin detaylarını getirir.
Response:
```json
{
  "id": 1,
  "title": "Ana Sayfa Tasarımı",
  "description": "Responsive ana sayfa tasarımı yapılacak",
  "status": "InProgress",
  "priority": "High",
  "dueDate": "2024-12-15T00:00:00Z",
  "createdDate": "2024-12-01T09:00:00Z",
  "assignedTo": "Ahmet Yılmaz",
  "projectId": 1,
  "projectName": "Web Sitesi Yenileme"
}
```
### POST /api/task/create
Yeni görev oluşturur (Admin gerektirir).
Request Body:
```json
{
  "title": "Backend API Geliştirme",
  "description": "REST API endpoint'lerinin geliştirilmesi",
  "projectId": 1,
  "assignedUserId": 2,
  "priority": "High",
  "dueDate": "2024-12-20T00:00:00Z"
}
```
### PUT /api/task/update/{id}
Var olan görevi günceller.
Request Body:
```json
{
  "title": "Backend API Geliştirme",
  "description": "Güncellenmiş açıklama",
  "status": "Completed",
  "priority": "Medium",
  "dueDate": "2024-12-20T00:00:00Z"
}
```
### DELETE /api/task/delete/{id}
Görevi siler (Admin yetkisi gerektirir).

### GET /api/task/getbyproject/{projectId}
Belirli bir projeye ait tüm görevleri listeler.
Response:
```json
  {
    "id": 1,
    "title": "Ana Sayfa Tasarımı",
    "status": "YapimAsamasi"
  }

```
### GET /api/task/getbyuser/{userId}
Belirli bir kullanıcıya atanmış tüm görevleri listeler.

### PUT /api/task/updatestatus/{id}
Görevin durumunu günceller.
Request Body:
```json
{
  "status": "Sonlandı"
}
```
Status değerleri: Boşta, Yapım aşaması, Sonlandı

### 👥 User (Kullanıcı Yönetimi)
### GET /api/user/getuserroles
Mevcut kullanıcının rollerini getirir.
Response:
```json
{
  "userId": 1,
  "email": "ahmet@example.com",
  "roles": ["User"]
}
```
### POST /api/user/assignrole
Kullanıcıya rol atar (Admin yetkisi gerektirir).
Request Body:
```json
{
  "userId": 2,
  "roleName": "User"
}
```
# Mevcut Roller:

- **User - Temel kullanıcı, kendine atanan görevleri görüntüleyebilir ve güncelleyebilir** 
- **Admin - Tüm yetkilere sahip, kullanıcı ve rol yönetimi yapabilir**


# Bilgi
### UserSeed.cs sınıfı sayesinde, örnek bir kullanıcı kaydı, rol oluşturma ve kullanıcıya rolün atanması, proje başladığı zaman otomatik olarak yapılmaktadır. 
### GET /api/user/getall
Tüm kullanıcıları listeler (Admin yetkisi gerektirir).

### GET /api/user/get/{id}
Belirli bir kullanıcının bilgilerini getirir.

### PUT /api/user/update/{id}
Kullanıcı bilgilerini günceller.
Request Body:
```json
{
  "firstName": "Mehmet",
  "lastName": "Demir",
  "email": "mehmet@example.com"
}
```
### DELETE /api/user/delete/{id}
Kullanıcıyı siler (Admin yetkisi gerektirir).
### DELETE /api/user/removerole
Kullanıcıdan rol kaldırır (Admin yetkisi gerektirir).
Request Body:
```json
{
  "userId": 2,
  "roleName": "Manager"
}
```

# Kurulum
### Gereksinimler

.NET 8.0 SDK
MS SQL Server
Visual Studio 2022 veya VS Code

# Adımlar

### Projeyi klonlayın:

bashgit clone https://github.com/gryphonsft/TaskCentralAPI.git
cd TaskCentralAPI

appsettings.json dosyasında veritabanı bağlantı stringini güncelleyin:

json{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TaskManagerDb;Trusted_Connection=true;"
  },
  "JwtSettings": {
    "SecretKey": "your-secret-key-here",
    "Issuer": "TaskManagerAPI",
    "Audience": "TaskManagerClient",
    "ExpirationMinutes": 60
  }
}

# Migration'ları uygulayın:

dotnet ef database update

Uygulamayı çalıştırın:

dotnet run

API varsayılan olarak https://localhost:7055 adresinde çalışacaktır.
Kimlik Doğrulama
API, JWT (JSON Web Token) tabanlı kimlik doğrulama kullanır. İsteklerde bulunmak için:

### /auth/login endpoint'i ile giriş yapın ve token alın
### Sonraki isteklerde Authorization header'ına token'ı ekleyin:

### Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
### Rol Bazlı Yetkilendirme

**Bana ulaş:** [abdullah_bozdag@outlook.com](mailto:abdullah_bozdag@outlook.com)
