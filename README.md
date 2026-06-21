# Restaurant Orders API

מערכת Web API לניהול הזמנות במסעדה — ניהול תפריט (מנות וקטגוריות) וניהול הזמנות לקוחות, כולל חישוב אוטומטי של סכום ההזמנה.
פרויקט סיום לקורס ASP.NET Core Web API.

## טכנולוגיות
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server (LocalDB)
- AutoMapper
- Swagger / OpenAPI

## מבנה השכבות
- **Controllers** — שכבת ה-API, מקבלת בקשות HTTP ומחזירה DTOs ללקוח
- **Services** — שכבת ה-Business Logic, מכילה את הלוגיקה העסקית (לדוגמה חישוב TotalAmount בהזמנה)
- **Repositories** — שכבת ה-Data Access, אחראית בלעדית על הגישה למסד הנתונים דרך EF Core
- **Data** — ה-DbContext
- **Models** — ה-Entities שמייצגות את טבלאות ה-DB
- **DTOs** — אובייקטים להעברת נתונים בין השרת ללקוח, כדי לא לחשוף את ה-Entities ישירות
- **Profiles** — מיפוי בין Entities ל-DTOs (AutoMapper)
- **Middleware** — טיפול מרכזי בשגיאות

## ישויות מרכזיות
- **Category** — קטגוריית מנות (למשל: מנות עיקריות, קינוחים)
- **Dish** — מנה בתפריט, משויכת לקטגוריה (קשר Many-to-One)
- **Order** — הזמנת לקוח
- **OrderDish** — טבלת קישור בין הזמנה למנות (קשר Many-to-Many בין Order ל-Dish), כוללת כמות לכל מנה

CRUD מלא מיושם עבור **Dish** ו-**Order**.

## הוראות התקנה והרצה
1. שכפול הריפו:git clone https://github.com/NaamaLaufer/restaurant-orders-api.git
2. פתיחת `restaurant-orders-api.sln` ב-Visual Studio.
3. לוודא ש-SQL Server LocalDB מותקן (מגיע כברירת מחדל עם Visual Studio).
4. ב-`appsettings.json`, לוודא שמחרוזת החיבור (`DefaultConnection`) מתאימה — ברירת המחדל מוגדרת לעבוד מול LocalDB בלי שינוי.
5. יצירת מסד הנתונים — אחת משתי דרכים:
   - **אוטומטית:** ב-Package Manager Console, להריץ `Update-Database`
   - **ידנית:** להריץ את הסקריפט המצורף `Database/CreateDatabase.sql` מול השרת
6. הרצה (F5) — הדפדפן ייפתח אוטומטית בעמוד Swagger.

## שימוש ב-API (Swagger)
לאחר ההרצה, Swagger זמין ב-:https://localhost:<הפורט שלכם>/swagger
שם ניתן לראות את כל ה-endpoints, לשלוח בקשות לבדיקה ("Try it out"), ולראות דוגמאות לבקשות ולתשובות.

## Endpoints עיקריים

| Method | Endpoint | תיאור |
|---|---|---|
| GET | /api/Dishes | רשימת כל המנות |
| GET | /api/Dishes/{id} | מנה לפי מזהה |
| POST | /api/Dishes | יצירת מנה חדשה |
| PUT | /api/Dishes/{id} | עדכון מנה |
| DELETE | /api/Dishes/{id} | מחיקת מנה |
| GET | /api/Orders | רשימת כל ההזמנות |
| GET | /api/Orders/{id} | הזמנה לפי מזהה |
| POST | /api/Orders | יצירת הזמנה חדשה |
| PUT | /api/Orders/{id} | עדכון הזמנה |
| DELETE | /api/Orders/{id} | מחיקת הזמנה |

