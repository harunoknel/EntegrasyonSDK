CREATE DATABASE EntegrasyonSDK;
USE EntegrasyonSDK;

--TrendYol sipariş veren müşteri tablosu
CREATE TABLE [dbo].[TrendyolCustomers] (
    CustomerID INT NOT NULL IDENTITY(1, 1),
    CustomerTrendYolID int NOT NULL,
    CustomerTCKN NVARCHAR(20) NOT NULL,
    CustomerFirstName NVARCHAR(150) NOT NULL,
    CustomerLastName NVARCHAR(150) NOT NULL,
    CustomerEmail NVARCHAR(150) NOT NULL,
    CustomerShipmentPackageID NVARCHAR(150) NOT NULL,
    CargoTrackingNumber NVARCHAR(150) NOT NULL,
    CargoTrackingLink NVARCHAR(150) NOT NULL,
    CargoSenderNumber NVARCHAR(150) NOT NULL,
    CargoProviderName NVARCHAR(150) NOT NULL,
    PRIMARY KEY (CustomerID)
);

CREATE TABLE [dbo].TrendyolShipmentCompany(
    ShipmentCompanyID INT NOT NULL IDENTITY(1,1),
    ShipmentCompanyTrendYolID int NOT NULL,
    ShipmentCompanyTrendYolCode NVARCHAR(50) NOT NULL,
    ShipmentCompanyName NVARCHAR(250) NOT NULL,
    ShipmentCompanyTaxCode NVARCHAR(50) NOT NULL,
);

CREATE TABLE [dbo].TrendyolCategories(
    CategoryID INT NOT NULL IDENTITY(1,1),
    TrendyolCategoryID int NOT NULL,
    TrendyolCategoryCode NVARCHAR(50) NOT NULL,
    TrendyolCategoryName NVARCHAR(250) NOT NULL,
    TrendyolParentCategoryID int 
)


CREATE TABLE [dbo].TrendyolOrders(
    OrderID INT NOT NULL IDENTITY(1,1),
    OrderCustomerName NVARCHAR(100) NOT NULL,
    OrderAdress NVARCHAR(250) NOT NULL,
    OrderCity NVARCHAR(50) NOT NULL,
    OrderDistrict NVARCHAR(50) NOT NULL,
    OrderInvoiceAdress NVARCHAR(250) NOT NULL,
    OrderInvoiceCustomerName NVARCHAR(100) NOT NULL,
    OrderInvoiceID NVARCHAR(50) NOT NULL,
    OrderGrossAmount MONEY NOT NULL,
    OrderTotalDiscount MONEY NOT NULL,
    OrderTotalPrice MONEY NOT NULL
)

CREATE TABLE [dbo].TrendYolOrderDetails(
    OrderDetailID INT NOT NULL IDENTITY(1,1),
    OrderID INT NOT NULL,
    OrderDetailQuantity INT NOT NULL,
    OrderDetailProductName NVARCHAR(250) NOT NULL

)


