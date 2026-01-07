CREATE DATABASE QuanLyThuHocPhi;
GO
USE QuanLyThuHocPhi;
GO

CREATE TABLE HEDT (
    MAHE   CHAR(5) PRIMARY KEY,
    TENHE  NVARCHAR(50),
    HPCB   INT
);

CREATE TABLE DSLOP (
    MALO   CHAR(10) PRIMARY KEY,
    TENLOP NVARCHAR(50),
    MAHE   CHAR(5) NOT NULL,
    FOREIGN KEY (MAHE) REFERENCES HEDT(MAHE)
);

CREATE TABLE DSSV (
    MASV      CHAR(10) PRIMARY KEY,
    HOTEN     NVARCHAR(50),
    NGAYSINH  DATE,
    MALO      CHAR(10) NOT NULL,
    DIENUIT   NVARCHAR(20),
    FOREIGN KEY (MALO) REFERENCES DSLOP(MALO)
);

CREATE TABLE HOCPHI (
    MAHP  CHAR(10) PRIMARY KEY,
    KYHP  NVARCHAR(50)
);

CREATE TABLE THUHP (
    MASV     CHAR(10) NOT NULL,
    MAHP     CHAR(10) NOT NULL,
    NGAYQD   DATE,
    NGAYTHU  DATE,
    SOTIEN   INT,
    PRIMARY KEY (MASV, MAHP),
    FOREIGN KEY (MASV) REFERENCES DSSV(MASV),
    FOREIGN KEY (MAHP) REFERENCES HOCPHI(MAHP)
);
INSERT INTO HEDT (MAHE, TENHE, HPCB)
VALUES
('CD', N'CAO ĐẲNG', 1800000),
('DH', N'ĐẠI HỌC', 2000000),
('TC', N'TRUNG CẤP', 1500000);
INSERT INTO DSLOP (MALO, TENLOP, MAHE)
VALUES
('08CD01', N'CD KẾ TOÁN DN 1', 'CD'),
('08CD02', N'CD KẾ TOÁN DN 2', 'CD'),
('08DH01', N'ĐH KẾ TOÁN 1', 'DH'),
('08TC01', N'TC KẾ TOÁN 1', 'TC'),
('08TC02', N'TC KẾ TOÁN 2', 'TC');
INSERT INTO DSSV (MASV, HOTEN, NGAYSINH, MALO, DIENUIT)
VALUES
('S0001', N'NGUYỄN THANH NHN', '1990-07-01', '08CD01', N'KHÔNG'),
('S0002', N'NGUYỄN THỊ THANH', '1991-05-25', '08CD02', N'CÓ'),
('S0003', N'TRAN NGUYEN', '1993-04-12', '08TC02', N'KHÔNG'),
('S0004', N'LÊ THANH PHI', '1991-12-04', '08TC01', N'CÓ'),
('S0005', N'LAI TRAN TIEN', '1992-02-06', '08TC02', N'CÓ'),
('S0006', N'LÊ QUỐC DUNG', '1991-06-13', '08DH01', N'KHÔNG'),
('S0007', N'TRAN THI LAI', '1993-07-04', '08DH01', N'CÓ');
INSERT INTO HOCPHI (MAHP, KYHP)
VALUES
('HK1', N'HỌC KỲ 1'),
('HK2', N'HỌC KỲ 2'),
('HK4', N'HỌC KỲ 4'),
('HK5', N'HỌC KỲ 5'),
('HK6', N'HỌC KỲ 6'),
('HK7', N'HỌC KỲ 7'),
('HK8', N'HỌC KỲ 8'),
('HK3', N'HỌC KỲ 3');
INSERT INTO THUHP (MASV, MAHP, NGAYQD, NGAYTHU, SOTIEN)
VALUES
('S0001', 'HK1', '2008-01-31', '2008-01-01', 900000),
('S0001', 'HK2', '2008-05-31', '2008-05-11', 900000),

('S0002', 'HK1', '2008-01-31', '2008-01-25', 900000),
('S0002', 'HK2', '2008-05-31', '2008-05-23', 800000),

('S0003', 'HK1', '2008-01-15', '2008-01-31', 750000),
('S0003', 'HK2', '2008-05-15', '2008-05-30', 750000),

('S0004', 'HK1', '2008-01-31', '2008-01-05', 750000),
('S0004', 'HK2', '2008-05-31', '2008-05-17', 800000),

('S0005', 'HK1', '2008-01-10', '2008-02-10', 700000),
('S0005', 'HK2', '2008-05-10', '2008-07-26', 900000);



GO
CREATE OR ALTER PROCEDURE P_THUHP_SINHVIEN
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        sv.MASV,
        sv.HOTEN,
        sv.NGAYSINH,
        sv.DIENUIT,

        lop.MALO,
        lop.TENLOP,

        he.MAHE,
        he.TENHE,
        he.HPCB,

        hp.MAHP,
        hp.KYHP,

        th.NGAYQD,
        th.NGAYTHU,
        th.SOTIEN
    FROM DSSV sv
    JOIN DSLOP lop ON sv.MALO = lop.MALO
    JOIN HEDT he    ON lop.MAHE = he.MAHE

    -- LEFT JOIN để SV chưa thu học phí vẫn hiện ra
    LEFT JOIN THUHP th  ON sv.MASV = th.MASV
    LEFT JOIN HOCPHI hp ON th.MAHP = hp.MAHP

    ORDER BY sv.MASV, hp.MAHP;
END
GO

-- Giống dòng exec trong ảnh
EXEC P_THUHP_SINHVIEN;
SELECT MAHP, KYHP FROM HOCPHI ORDER BY MAHP



CREATE OR ALTER PROCEDURE P_BC_SV_CONNO_HOCPHI
    @MAHP CHAR(10)  -- ví dụ: HK1, HK2...
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        lop.MALO,
        lop.TENLOP,

        sv.MASV,
        sv.HOTEN,

        he.HPCB,                                  -- mức quy định

        DaDong = ISNULL(SUM(th.SOTIEN), 0),       -- số tiền đã đóng
        ConNo  = he.HPCB - ISNULL(SUM(th.SOTIEN), 0)  -- số tiền còn nợ
    FROM DSSV sv
    JOIN DSLOP lop ON sv.MALO = lop.MALO
    JOIN HEDT he   ON lop.MAHE = he.MAHE

    LEFT JOIN THUHP th
        ON th.MASV = sv.MASV
       AND th.MAHP = @MAHP

    GROUP BY
        lop.MALO, lop.TENLOP,
        sv.MASV, sv.HOTEN,
        he.HPCB

    HAVING (he.HPCB - ISNULL(SUM(th.SOTIEN), 0)) > 0   -- chỉ lấy SV còn nợ

    ORDER BY lop.MALO, sv.MASV;
END
GO
EXEC P_BC_SV_CONNO_HOCPHI 'HK2';
SELECT MAHP, KYHP FROM HOCPHI ORDER BY MAHP;


CREATE OR ALTER PROCEDURE P_BC_DOANHTHU_THEO_HE_LOP
    @MAHP CHAR(10) = NULL   -- NULL = tất cả học kỳ
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        he.MAHE,
        he.TENHE,

        lop.MALO,
        lop.TENLOP,

        -- ✅ số sinh viên đã đóng (đếm SV có phát sinh thu)
        SoSV_DaDong = COUNT(DISTINCT th.MASV),

        -- ✅ tổng tiền thu được
        TongTienThu = ISNULL(SUM(th.SOTIEN), 0)
    FROM HEDT he
    JOIN DSLOP lop ON lop.MAHE = he.MAHE
    JOIN DSSV sv   ON sv.MALO = lop.MALO

    -- chỉ những khoản đã thu mới tính doanh thu
    LEFT JOIN THUHP th
        ON th.MASV = sv.MASV
       AND (@MAHP IS NULL OR th.MAHP = @MAHP)

    GROUP BY
        he.MAHE, he.TENHE,
        lop.MALO, lop.TENLOP

    ORDER BY he.MAHE, lop.MALO;
END
GO
EXEC P_BC_DOANHTHU_THEO_HE_LOP 'HK1';
EXEC P_BC_DOANHTHU_THEO_HE_LOP;   -- tất cả học kỳ

IF OBJECT_ID('dbo.USERS','U') IS NULL
BEGIN
    CREATE TABLE dbo.[USERS]
    (
        USERNAME NVARCHAR(50) PRIMARY KEY,
        [PASSWORD] NVARCHAR(50) NOT NULL,
        FULLNAME NVARCHAR(100) NULL,
        ROLE NVARCHAR(20) NULL
    );
END
GO