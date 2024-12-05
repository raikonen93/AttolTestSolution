-- To get 'TotalAmount' column and not break out normalization rules we created View - OrderSummary

--Query 1
Select top 5 
    p.ProductName,
    SUM(op.Quantity) AS TotalQuantity
from 
    OrderProducts op
join 
    Products p ON op.ProductID = p.ProductID
group by 
    p.ProductName
order by 
    TotalQuantity desc;

--Query 2
Select CustomerName, Sum(TotalAmount) as AmountOfAllTimes
From OrderSummary
Group by CustomerName
Having Sum(TotalAmount)>1000

--Query 3
Select c.CategoryName, count(*) as ProductsCount
from categories c
join products p on c.CategoryId=p.CategoryId
group by c.CategoryName

