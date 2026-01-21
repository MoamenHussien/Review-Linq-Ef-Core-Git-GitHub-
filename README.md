Entities (Models)
Product: Id, Name, Price, StockQty, CategoryId, IsDeleted, CreatedAt

Category: Id, Name

Order: Id, CreatedAt, CustomerName, Total

OrderItem: OrderId, ProductId, Qty, UnitPrice

(Bonus) AuditLog: Id, EntityName, Action, When, User

Relations:

Category 1..* Products

Order 1..* OrderItems

Product 1..* OrderItems
_______________________________________________________________________________

1) Part A — EF Core (أسئلة/مهام شغل حقيقي)
A1) DbContext & Configuration 
Product.Name required + max length 120

Price decimal(18,2)

composite key لـ OrderItem (OrderId + ProductId)

Add Global Query Filter لـ Product.IsDeleted == false (Soft Delete).

✅ Deliverable: Migration + Database تتعمل.
_______________________________________________________________________________
A2) Seeding Data 

Seed 5 Categories + 20 Product (Prices مختلفة + Stock مختلفة).

_______________________________________________________________________________

A3) CRUD مع Business Rules (15 درجة)

AddProduct (لازم Category موجودة)

UpdateProductPrice

SoftDeleteProduct

RestockProduct (يزود stock)

_______________________________________________________________________________

Eager Loading: Order مع Items ومع Product
_______________________________________________________________________________
B1) Filtering + Sorting + Paging

Category اسمها تحتوي "Elect"

Price بين 500 و 5000

Sorted by Price desc ثم Name asc

Paging: pageSize=5, page=2
_______________________________________________________________________________
 B2) Projection (DTO) (10 درجات)

ProductCard { Id, Name, CategoryName, Price, InStock }
_______________________________________________________________________________
B3) Grouping + Aggregates (15 درجة)

Group products by CategoryName 

Count

AvgPrice

MaxPrice

TotalStockQty
_______________________________________________________________________________

B4) Joins (10 درجات)

اطلع تقرير: كل OrderItem ومعاه ProductName و CategoryName و subtotal
_______________________________________________________________________________
B5) Advanced LINQ (15 درجة)

Top 3 categories by revenue (من Orders)

Customers with total spending > 10,000

Products never ordered

Products ordered more than 5 times (sum qty)
_______________________________________________________________________________
