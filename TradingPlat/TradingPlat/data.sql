--
-- File generated with SQLiteStudio v3.3.3 on Sun Nov 21 12:09:36 2021
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: __EFMigrationsHistory
CREATE TABLE "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES ('20211113183604_InitialCreate', '5.0.12');
INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES ('20211120165142_SecondMigration', '5.0.12');

-- Table: PortfolioStocks
CREATE TABLE "PortfolioStocks" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PortfolioStocks" PRIMARY KEY AUTOINCREMENT,
    "StockID" INTEGER NOT NULL,
    "UserID" INTEGER NOT NULL,
    "ExecutionPrice" TEXT NOT NULL,
    "Quantity" INTEGER NOT NULL,
    CONSTRAINT "FK_PortfolioStocks_Stocks_StockID" FOREIGN KEY ("StockID") REFERENCES "Stocks" ("StockID") ON DELETE CASCADE,
    CONSTRAINT "FK_PortfolioStocks_Users_UserID" FOREIGN KEY ("UserID") REFERENCES "Users" ("UserID") ON DELETE CASCADE
);

-- Table: Stocks
CREATE TABLE "Stocks" (
    "StockID" INTEGER NOT NULL CONSTRAINT "PK_Stocks" PRIMARY KEY AUTOINCREMENT,
    "StockName" TEXT NULL,
    "Symbol" TEXT NULL
);
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (4, '3M Inc', 'MMM');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (5, 'Advanced Micro Devices', 'AMD');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (6, 'Aflac', 'AFL');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (7, 'Apple Common Stock', 'AAPL');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (8, 'Microsoft Corporation Common Stock', 'MSFT');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (9, 'Alphabet Inc', 'GOOGL');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (10, 'Amazon.com', 'AMZN');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (11, 'Tesla, Inc', 'TSLA');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (12, 'Meta Platforms', 'FB');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (13, 'NVIDIA Corporation', 'NVDA');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (14, 'JP Morgan Chase & Co.', 'JPM');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (15, 'Alibaba Group', 'BABA');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (16, 'UnitedHealth', 'UNH');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (17, 'Walmart Inc', 'WMT');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (18, 'Bank Of American', 'BAC');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (19, 'Analog Devices Inc', 'ADI');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (20, 'Home Depot Inc', 'HD');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (21, 'Mastercard Incorporated', 'MA');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (22, 'Procter & Gamble', 'PG');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (23, 'Adobe Inc', 'ADBE');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (24, 'Netflix Inc', 'NFLX');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (25, 'Saleforce.com', 'CRM');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (26, 'NetEase Inc', 'NTES');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (27, 'Walt Disney Company', 'DIS');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (28, 'Pfizer Inc', 'PFE');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (29, 'Exxon Mobil Cor', 'XOM');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (30, 'Nike Inc', 'NKE');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (31, 'Toyota Motor', 'TM');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (32, 'Thermo Fisher', 'TMO');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (33, 'Eli Lily', 'LLY');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (34, 'PayPal Holdings', 'PYPL');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (35, 'Oracle Corporation', 'ORCL');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (36, 'Coca-Cola', 'KO');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (37, 'Cisco System', 'CSCO');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (38, 'Costco', 'COST');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (39, 'Pepsico', 'PEP');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (40, 'Chevron Cor', 'CVX');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (41, 'Verizon Communications Inc', 'VZ');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (42, 'Danaher Cor', 'DHR');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (43, 'Merck @ Company Inc', 'MRK');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (44, 'Shopify Inc', 'SHOP');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (45, 'AbbVie Inc', 'ABBV');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (46, 'Intel Corporation', 'INTC');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (47, 'Wells Fargo', 'WFC');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (48, 'McDonald''s Corporation', 'MCD');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (49, 'Sea Limited American', 'SE');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (50, 'United Stated Parcel Service Inc', 'UPS');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (51, 'Morgan Stanley', 'MS');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (52, 'AT&T Inc', 'T');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (53, 'Honeywell International Inc', 'HON');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (54, 'Citigroup Inc', 'C');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (55, 'Snowflake Inc', 'SNOW');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (56, 'CVS Health Cor', 'CVS');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (57, 'Starbucks Corporation', 'SBUX');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (58, 'Square Inc', 'SQ');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (59, 'Anthem Inc', 'ANTM');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (60, 'Blackstone Inc', 'BX');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (61, 'Deere Company', 'DE');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (62, 'Snap Inc', 'SNAP');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (63, 'Coinbase Global', 'COIN');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (64, 'International Business Machines Cor', 'IBM');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (65, 'PNC Financial Services Group', 'PNC');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (66, 'Altria Group', 'MO');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (67, 'Ford Motor Company', 'F');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (68, 'Zoom Video Com', 'ZM');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (69, 'Cigna Cor', 'CI');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (70, 'Lucid Group', 'LCID');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (71, 'Fidelity National Information Services', 'FIS');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (72, 'Waste Management', 'WM');
INSERT INTO Stocks (StockID, StockName, Symbol) VALUES (73, 'Capital One Financial Cor', 'COF');

-- Table: Users
CREATE TABLE "Users" (
    "UserID" INTEGER NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY AUTOINCREMENT,
    "LastName" TEXT NULL,
    "Email" TEXT NULL,
    "Password" TEXT NULL
, "FirstName" TEXT NULL);
INSERT INTO Users (UserID, LastName, Email, Password, FirstName) VALUES (1, 'nguyen', 'hieu@gmail.com', 'hieu', 'hieu');
INSERT INTO Users (UserID, LastName, Email, Password, FirstName) VALUES (2, 'test', 'test@gmail.com', 'test', 'test');
INSERT INTO Users (UserID, LastName, Email, Password, FirstName) VALUES (3, 'te', 'te@gmail.com', 'te', 'te');

-- Index: IX_PortfolioStocks_StockID
CREATE INDEX "IX_PortfolioStocks_StockID" ON "PortfolioStocks" ("StockID");

-- Index: IX_PortfolioStocks_UserID
CREATE INDEX "IX_PortfolioStocks_UserID" ON "PortfolioStocks" ("UserID");

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
