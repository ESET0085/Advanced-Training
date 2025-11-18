USE AmiProject;
GO

-- =====================================================
-- 🔄 OPTION 1: UNCOMMENT TO CLEAR ALL DATA AND START FRESH
-- =====================================================
/*
DELETE FROM ami.Billing;
DELETE FROM ami.MeterReading;
DELETE FROM ami.Meter;
DELETE FROM ami.Consumer;
DELETE FROM ami.TariffSlab;
DELETE FROM ami.Tariff;
DELETE FROM ami.OrgUnit;
DELETE FROM ami.[User];

-- Reset identity seeds
DBCC CHECKIDENT ('ami.OrgUnit', RESEED, 0);
DBCC CHECKIDENT ('ami.Tariff', RESEED, 0);
DBCC CHECKIDENT ('ami.TariffSlab', RESEED, 0);
DBCC CHECKIDENT ('ami.Consumer', RESEED, 0);
DBCC CHECKIDENT ('ami.MeterReading', RESEED, 0);
DBCC CHECKIDENT ('ami.Billing', RESEED, 0);
DBCC CHECKIDENT ('ami.User', RESEED, 0);
GO
*/

-- =====================================================
-- 🔒 OPTION 2: CHECK IF DATA EXISTS - SKIP IF ALREADY SEEDED
-- =====================================================
IF NOT EXISTS (SELECT 1 FROM ami.OrgUnit)
BEGIN
    PRINT '🌱 Seeding database...';

    -----------------------------------------------------
    -- 1️⃣ OrgUnit
    -----------------------------------------------------
    INSERT INTO ami.OrgUnit (Type, Name, ParentId)
    VALUES 
    ('Zone', 'Zone A', NULL),
    ('Substation', 'Substation A1', 1),
    ('Feeder', 'Feeder A1-1', 2),
    ('DTR', 'DTR A1-1-1', 3),
    ('Zone', 'Zone B', NULL),
    ('Substation', 'Substation B1', 5),
    ('Feeder', 'Feeder B1-1', 6),
    ('DTR', 'DTR B1-1-1', 7);
    
    PRINT '✅ OrgUnit seeded';

    -----------------------------------------------------
    -- 2️⃣ Tariff
    -----------------------------------------------------
    INSERT INTO ami.Tariff (Name, EffectiveFrom, EffectiveTo, BaseRate, TaxRate)
    VALUES 
    ('Domestic Tariff', '2024-01-01', NULL, 5.0000, 0.05),
    ('Commercial Tariff', '2024-01-01', NULL, 7.5000, 0.10);
    
    PRINT '✅ Tariff seeded';

    -----------------------------------------------------
    -- 3️⃣ TariffSlab
    -----------------------------------------------------
    INSERT INTO ami.TariffSlab (TariffId, FromKwh, ToKwh, RatePerKwh)
    VALUES
    (1, 0, 100, 4.50),
    (1, 101, 300, 5.00),
    (1, 301, 1000, 6.50),
    (2, 0, 200, 7.00),
    (2, 201, 500, 8.50),
    (2, 501, 2000, 9.50);
    
    PRINT '✅ TariffSlab seeded';

    -----------------------------------------------------
    -- 4️⃣ Consumer
    -----------------------------------------------------
    INSERT INTO ami.Consumer 
    (Name, Address, Phone, Email, OrgUnitId, TariffId, Latitude, Longitude, Status, CreatedBy)
    VALUES
    ('Ravi Kumar', '123 Green Street', '9876543210', 'ravi@example.com', 4, 1, 17.3850, 78.4867, 'Active', 'admin'),
    ('Anita Sharma', '45 Lake View', '9876543211', 'anita@example.com', 8, 2, 17.4401, 78.4952, 'Active', 'admin'),
    ('Vijay Rao', '22 Beach Road', '9876543212', 'vijay@example.com', 4, 1, 17.4300, 78.5000, 'Active', 'admin');
    
    PRINT '✅ Consumer seeded';

    -----------------------------------------------------
    -- 5️⃣ Meter
    -----------------------------------------------------
    INSERT INTO ami.Meter 
    (MeterSerialNo, IpAddress, ICCID, IMSI, Manufacturer, Firmware, Category, InstallTsUtc, Status, ConsumerId)
    VALUES
    ('MTR001', '192.168.1.10', 'ICCID001', 'IMSI001', 'SecureMeters', 'v1.0', 'Smart', SYSUTCDATETIME(), 'Active', 1),
    ('MTR002', '192.168.1.11', 'ICCID002', 'IMSI002', 'L&T', 'v1.2', 'Smart', SYSUTCDATETIME(), 'Active', 2),
    ('MTR003', '192.168.1.12', 'ICCID003', 'IMSI003', 'Genus', 'v1.1', 'Smart', SYSUTCDATETIME(), 'Active', 3);
    
    PRINT '✅ Meter seeded';

    -----------------------------------------------------
    -- 6️⃣ MeterReading
    -----------------------------------------------------
    INSERT INTO ami.MeterReading (MeterSerialNo, ReadingTsUtc, Kwh, Voltage, [Current], PowerFactor)
    VALUES
    ('MTR001', DATEADD(DAY, -10, SYSUTCDATETIME()), 154.50, 230.1, 10.2, 0.95),
    ('MTR001', DATEADD(DAY, -5, SYSUTCDATETIME()), 160.30, 231.0, 10.3, 0.96),
    ('MTR002', DATEADD(DAY, -10, SYSUTCDATETIME()), 210.10, 228.5, 9.8, 0.94),
    ('MTR002', DATEADD(DAY, -5, SYSUTCDATETIME()), 220.50, 229.9, 10.1, 0.95),
    ('MTR003', DATEADD(DAY, -10, SYSUTCDATETIME()), 115.00, 232.3, 8.5, 0.97),
    ('MTR003', DATEADD(DAY, -5, SYSUTCDATETIME()), 120.00, 231.8, 8.7, 0.96);
    
    PRINT '✅ MeterReading seeded';

    -----------------------------------------------------
    -- 7️⃣ Billing
    -----------------------------------------------------
    INSERT INTO ami.Billing 
    (ConsumerId, BillingPeriodStart, BillingPeriodEnd, TotalKwh, AmountBeforeTax, TaxAmount, TotalAmount, Status)
    VALUES
    (1, '2024-09-01', '2024-09-30', 160.3, 801.50, 40.08, 841.58, 'Paid'),
    (2, '2024-09-01', '2024-09-30', 220.5, 1653.75, 165.38, 1819.13, 'Pending'),
    (3, '2024-09-01', '2024-09-30', 120.0, 600.00, 30.00, 630.00, 'Paid');
    
    PRINT '✅ Billing seeded';

    -----------------------------------------------------
    -- 8️⃣ User
    -----------------------------------------------------
    INSERT INTO ami.[User] (UserName, Email, Password, Role, Status)
    VALUES
    ('admin', 'admin@example.com', 'Admin@123', 'Admin', 'Active'),
    ('user1', 'user1@example.com', 'User@123', 'User', 'Active'),
    ('user2', 'user2@example.com', 'User@456', 'User', 'Active');
    
    PRINT '✅ User seeded';

    PRINT '🎉 Seed data inserted successfully!';
END
ELSE
BEGIN
    PRINT '⚠️ Data already exists. Skipping seed.';
END
GO