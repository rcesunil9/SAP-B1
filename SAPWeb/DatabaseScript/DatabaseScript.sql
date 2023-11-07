USE [New_test]
GO
/****** Object:  Table [dbo].[U_INV1]    Script Date: 11/7/2023 10:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[U_INV1](
	[InvoiceDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NULL,
	[ItemCode] [nvarchar](50) NULL,
	[Dscription] [nvarchar](200) NULL,
	[Quantity] [numeric](19, 6) NULL,
	[DiscPrcnt] [numeric](19, 6) NULL,
	[WhsCode] [nvarchar](8) NULL,
	[TaxCode] [nvarchar](8) NULL,
	[UnitPrice] [numeric](19, 6) NULL,
 CONSTRAINT [PK_U_INV1] PRIMARY KEY CLUSTERED 
(
	[InvoiceDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[U_OINV]    Script Date: 11/7/2023 10:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[U_OINV](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[DocEntry] [int] NOT NULL,
	[DocNum] [int] NOT NULL,
	[DocStatus] [char](1) NULL,
	[ObjType] [nvarchar](20) NULL,
	[DocDate] [datetime] NULL,
	[DocDueDate] [datetime] NULL,
	[TaxDate] [datetime] NULL,
	[CardCode] [nvarchar](15) NULL,
	[CardName] [nvarchar](100) NULL,
	[DocCur] [nvarchar](3) NULL,
	[DocTotal] [numeric](19, 6) NULL,
	[SlpCode] [int] NULL,
	[CntctCode] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[Series] [int] NULL,
	[UserSign] [smallint] NULL,
	[UserSign2] [smallint] NULL,
	[PayToCode] [nvarchar](50) NULL,
	[ShipToCode] [nvarchar](50) NULL,
	[Comments] [nvarchar](254) NULL,
	[RoundDif] [numeric](19, 6) NULL,
	[Rounding] [char](4) NULL,
	[U_Territory] [nvarchar](100) NULL,
	[U_VerCode] [nvarchar](60) NULL,
	[U_FiscalDoc] [nvarchar](60) NULL,
	[U_URAPosted] [nvarchar](20) NULL,
	[U_Payment] [nvarchar](20) NULL,
	[ARStatus] [char](1) NULL,
 CONSTRAINT [PK_U_OINV] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[U_OQUT]    Script Date: 11/7/2023 10:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[U_OQUT](
	[QuotaionID] [int] IDENTITY(1,1) NOT NULL,
	[DocEntry] [int] NOT NULL,
	[DocNum] [int] NOT NULL,
	[DocStatus] [char](1) NULL,
	[ObjType] [nvarchar](20) NULL,
	[DocDate] [datetime] NULL,
	[DocDueDate] [datetime] NULL,
	[TaxDate] [datetime] NULL,
	[CardCode] [nvarchar](15) NULL,
	[CardName] [nvarchar](100) NULL,
	[DocCur] [nvarchar](3) NULL,
	[DocTotal] [numeric](19, 6) NULL,
	[SlpCode] [int] NULL,
	[CntctCode] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[Series] [int] NULL,
	[UserSign] [smallint] NULL,
	[UserSign2] [smallint] NULL,
	[PayToCode] [nvarchar](50) NULL,
	[ShipToCode] [nvarchar](50) NULL,
	[Comments] [nvarchar](254) NULL,
	[U_Territory] [nvarchar](100) NULL,
	[RoundDif] [numeric](19, 6) NULL,
	[Rounding] [char](4) NULL,
 CONSTRAINT [PK_U_OQUT] PRIMARY KEY CLUSTERED 
(
	[QuotaionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[U_QUT1]    Script Date: 11/7/2023 10:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[U_QUT1](
	[QuotaionDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[QuotaionID] [int] NULL,
	[ItemCode] [nvarchar](50) NULL,
	[Dscription] [nvarchar](200) NULL,
	[Quantity] [numeric](19, 6) NULL,
	[DiscPrcnt] [numeric](19, 6) NULL,
	[WhsCode] [nvarchar](8) NULL,
	[TaxCode] [nvarchar](8) NULL,
	[UnitPrice] [numeric](19, 6) NULL,
 CONSTRAINT [PK_U_QUT1] PRIMARY KEY CLUSTERED 
(
	[QuotaionDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[U_OINV] ADD  CONSTRAINT [DF_U_OINV_DocStatus]  DEFAULT ('O') FOR [DocStatus]
GO
ALTER TABLE [dbo].[U_OINV] ADD  CONSTRAINT [DF_U_OINV_ObjType]  DEFAULT ('13') FOR [ObjType]
GO
ALTER TABLE [dbo].[U_OINV] ADD  CONSTRAINT [DF_U_OINV_SlpCode]  DEFAULT ((-1)) FOR [SlpCode]
GO
ALTER TABLE [dbo].[U_OINV] ADD  CONSTRAINT [DF_U_OINV_DocStatus1]  DEFAULT ('O') FOR [ARStatus]
GO
ALTER TABLE [dbo].[U_OQUT] ADD  CONSTRAINT [DF_U_OQUT_DocStatus]  DEFAULT ('O') FOR [DocStatus]
GO
ALTER TABLE [dbo].[U_OQUT] ADD  CONSTRAINT [DF_U_OQUT_ObjType]  DEFAULT ('23') FOR [ObjType]
GO
ALTER TABLE [dbo].[U_OQUT] ADD  CONSTRAINT [DF_U_OQUT_SlpCode]  DEFAULT ((-1)) FOR [SlpCode]
GO
/****** Object:  StoredProcedure [dbo].[SAP_ARInoviceHeaderList]    Script Date: 11/7/2023 10:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec SAP_ARInoviceHeaderList 'CO99990Kisoro','Kisoro23','1'
CREATE procedure [dbo].[SAP_ARInoviceHeaderList] 
(
	@CODE nvarchar(100)='TEST',
	@seriessq nvarchar(100)='TEST_I',
	@LogiID nvarchar(100)='1'
)
as      
BEGIN
SET NOCOUNT ON;
-- ContactPesrion
SELECT CntctCode as CODE,CONCAT(Name,',',FirstName) as [NAME] from OCPR WHERE CardCode= @CODE
-- Employee
SELECT t1.slpcode as Code,t1.slpname as Name from [@USER] t0 inner join OSLP t1 on t1.slpcode = t0.U_SlpCode where Code = @LogiID
-- ShipToAddress
SELECT [Address],[Street], [Block],[City],[ZipCode], [State], [Country]  FROM CRD1 WHERE AdresType = 'S' and CardCode = @CODE
-- BillToAddress																				   
SELECT [Address],[Street], [Block],[City],[ZipCode], [State], [Country]  FROM CRD1 WHERE AdresType = 'B' and CardCode = @CODE
-- Series
select t1.Series as Series, t0.U_IN_Series as U_SERIES,t1.NextNumber as QuotationNumber from [@USER] t0 inner join NNM1 t1 on t1.SeriesNAme = U_IN_Series where ObjectCode = '13' and U_IN_Series = @seriessq
GROUP BY t1.NextNumber,t1.Series,t0.U_IN_Series
END





--select t1.OnHand  as InStoc, t0.IWeight1 from OITM t0
--inner join OITW t1 on t1.ItemCode = t0.ItemCode
--where t0.ItemCode = 'TEST' and WhsCode = '01'



--select * from [@USER] Where U_Pass = '1234' AND Name='LIRA'
 
GO
/****** Object:  StoredProcedure [dbo].[SAP_ItemMasterList]    Script Date: 11/7/2023 10:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SAP_ItemMasterList] 
(
	@CODE nvarchar(100)='',
	@WhsCode nvarchar(100)=''
)
as      


 Select top 20000 ItemName as [Name],
a.ItemCode as Code,     
	isnull(c.Price, 0)  as  ItemPrice,     
	c.Currency as Currency,
	a.validFor,
	a.SellItem, 
	t1.OnHand as InStock, 
	a.IWeight1 as [Weight] , 
	t1.AvgPrice as ItemCost
	from OITM a      
	left join ITM1 c on a.ItemCode=c.ItemCode and c.PriceList=1  
	left join OITW t1 on t1.ItemCode = a.ItemCode and WhsCode = @WhsCode
where  a.validFor='Y' ----
and a.SellItem='Y'
--and c.Price> 0

and (ItemName like '%'+ @CODE + '%' OR a.ItemCode like '%'+@CODE+'%')
order by a.ItemCode

GO
/****** Object:  StoredProcedure [dbo].[SAP_SalesQuotationHeaderList]    Script Date: 11/7/2023 10:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SAP_SalesQuotationHeaderList] 
(
	@CODE nvarchar(100)='TEST',
	@seriessq nvarchar(100)='TEST_S',
	@LogiID nvarchar(100)='1'
)
as      
BEGIN
SET NOCOUNT ON;
-- ContactPesrion
SELECT CntctCode as CODE,CONCAT(Name,',',FirstName) as [NAME] from OCPR WHERE CardCode= @CODE
---- Employee
--SELECT t1.slpcode as Code,t1.slpname as Name from ocrd t0 inner join OSLP t1 on t1.slpcode = t0.slpcode where CardCode = @CODE

-- Employee
SELECT t1.slpcode as Code,t1.slpname as Name from [@USER] t0 inner join OSLP t1 on t1.slpcode = t0.U_SlpCode where Code = @LogiID
-- ShipToAddress
SELECT [Address],[Street], [Block],[City],[ZipCode], [State], [Country]  FROM CRD1 WHERE AdresType = 'S' and CardCode = @CODE
-- BillToAddress																				   
SELECT [Address],[Street], [Block],[City],[ZipCode], [State], [Country]  FROM CRD1 WHERE AdresType = 'B' and CardCode = @CODE
-- Series
select t1.Series as Series, t0.U_SERIES as U_SERIES,t1.NextNumber as QuotationNumber from [@USER] t0 inner join NNM1 t1 on t1.SeriesNAme = U_SEries where ObjectCode = '23' and U_SERIES = @seriessq

END





GO
/****** Object:  StoredProcedure [dbo].[SAP_U_INV1InsertUpdate]    Script Date: 11/7/2023 10:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SAP_U_INV1InsertUpdate]
(
	@InvoiceDetailsID int=0,
	@InvoiceID int=0,
	@ItemCode nvarchar(50),
	@Dscription nvarchar(200),
	@Quantity numeric(19, 6),
	@DiscPrcnt numeric(19, 6),
	@WhsCode nvarchar(50),
	@TaxCode nvarchar(254),
	@UnitPrice numeric(19, 6),
	@RETURNID int OUT
)

AS
BEGIN
	
	

	IF NOT EXISTS (SELECT * FROM U_INV1 WHERE InvoiceDetailsID = @InvoiceDetailsID)
	BEGIN
		INSERT INTO U_INV1(
			InvoiceID,
			
			ItemCode  ,
			Dscription,
			Quantity  ,
			DiscPrcnt ,
			WhsCode	  ,
			TaxCode,

			UnitPrice
		)
		VALUES
		(
			(CASE WHEN ISNULL(@InvoiceID, 0) = 0 THEN null ELSE @InvoiceID END),
			(CASE WHEN ISNULL(@ItemCode, '') = '' THEN null ELSE @ItemCode END),
			(CASE WHEN ISNULL(@Dscription, '') = '' THEN null ELSE @Dscription END),
			(CASE WHEN ISNULL(@Quantity, 0) = 0 THEN null ELSE @Quantity END),
			(CASE WHEN ISNULL(@DiscPrcnt, 0) = 0 THEN null ELSE @DiscPrcnt END),
			(CASE WHEN ISNULL(@WhsCode, '') = '' THEN null ELSE @WhsCode END),
			(CASE WHEN ISNULL(@TaxCode, '') = '' THEN null ELSE @TaxCode END),
			(CASE WHEN ISNULL(@UnitPrice, 0) = 0 THEN null ELSE @UnitPrice END)
			
		)
		SET @RETURNID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE U_INV1 SET
			InvoiceID = @InvoiceID,
			ItemCode = (CASE WHEN ISNULL(@ItemCode, '') = '' THEN ItemCode ELSE @ItemCode END),
			Dscription = 	(CASE WHEN ISNULL(@Dscription, '') = '' THEN Dscription ELSE @Dscription END),
			Quantity = (CASE WHEN ISNULL(@Quantity, 0) = 0 THEN Quantity ELSE @Quantity END),
			DiscPrcnt = (CASE WHEN ISNULL(@DiscPrcnt, 0) = 0 THEN DiscPrcnt ELSE @DiscPrcnt END),
			WhsCode = (CASE WHEN ISNULL(@WhsCode, '') = '' THEN WhsCode ELSE @WhsCode END),
			TaxCode = (CASE WHEN ISNULL(@TaxCode, '') = '' THEN TaxCode ELSE @TaxCode END),
			UnitPrice = (CASE WHEN ISNULL(@UnitPrice, 0) = 0 THEN UnitPrice ELSE @UnitPrice END)
			WHERE InvoiceDetailsID = @InvoiceDetailsID
		SET @RETURNID = @InvoiceDetailsID
	END


	RETURN @RETURNID
END
GO
/****** Object:  StoredProcedure [dbo].[SAP_U_OINVInsertUpdate]    Script Date: 11/7/2023 10:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SAP_U_OINVInsertUpdate]
(
	@InvoiceID int=0,
	@DocEntry int=0,
	@DocNum int=0,
	@DocStatus char(1)='D',
	@DocDate datetime=null,
	@DocDueDate datetime=null,
	@TaxDate datetime=null,
	@CardCode nvarchar(15)='',
	@CardName nvarchar(100)='',
	@DocCur nvarchar(3)='',
	@SlpCode int=0,
	@CntctCode int=0,
	@Series int=0,
	@UserSign smallint=0,
	@PayToCode nvarchar(50)='',
	@ShipToCode nvarchar(50)='',
	@Comments nvarchar(254)='',
	@U_Territory nvarchar(254)='',
	@U_VerCode nvarchar(254)='',
	@U_FiscalDoc nvarchar(254)='',
	@U_URAPosted nvarchar(254)='',
	@U_Payment nvarchar(254)='',
	@RoundDif numeric(19, 6)=0,
	@DocTotal numeric(19, 6)=0,
	@ARStatus char(1)='D',
	@Rounding char(4)='tNo',
	@RETURNID int OUT
)

AS
BEGIN
	
	

	IF NOT EXISTS (SELECT * FROM U_OINV WHERE InvoiceID = @InvoiceID)
	BEGIN
		INSERT INTO U_OINV(
			DocEntry,
			DocNum,
			DocStatus,
			ARStatus,
			ObjType,
			DocDate,
			DocDueDate,
			TaxDate,
			CardCode,
			CardName,
			DocCur,
			SlpCode,
			CntctCode,
			Series,
			UserSign,
			PayToCode,
			ShipToCode,
			Comments,
			U_Territory,
			CreateDate,
			RoundDif,
			DocTotal,
			Rounding,
			U_VerCode,
			U_FiscalDoc,
			U_URAPosted,
			U_Payment
		)
		VALUES
		(
			(CASE WHEN ISNULL(@DocEntry, 0) = 0 THEN 0 ELSE @DocEntry END),
			(CASE WHEN ISNULL(@DocNum, 0) = 0 THEN 0 ELSE @DocNum END),
			(CASE WHEN ISNULL(@DocStatus, '') = '' THEN 'O' ELSE @DocStatus END),
			(CASE WHEN ISNULL(@ARStatus, '') = '' THEN 'O' ELSE @ARStatus END),
			'23',
			(CASE WHEN ISNULL(@DocDate, '') = '' THEN null ELSE @DocDate END),
			(CASE WHEN ISNULL(@DocDueDate, '') = '' THEN null ELSE @DocDueDate END),
			(CASE WHEN ISNULL(@TaxDate, '') = '' THEN null ELSE @TaxDate END),
			(CASE WHEN ISNULL(@CardCode, '') = '' THEN null ELSE @CardCode END),
			(CASE WHEN ISNULL(@CardName, '') = '' THEN null ELSE @CardName END),
			(CASE WHEN ISNULL(@DocCur, '') = '' THEN null ELSE @DocCur END),
			(CASE WHEN ISNULL(@SlpCode, 0) = 0 THEN null ELSE @SlpCode END),
			(CASE WHEN ISNULL(@CntctCode, 0) = 0 THEN null ELSE @CntctCode END),
			(CASE WHEN ISNULL(@Series, 0) = 0 THEN null ELSE @Series END),
			(CASE WHEN ISNULL(@UserSign, 0) = 0 THEN null ELSE @UserSign END),
			(CASE WHEN ISNULL(@PayToCode, '') = '' THEN null ELSE @PayToCode END),
			(CASE WHEN ISNULL(@ShipToCode, '') = '' THEN null ELSE @ShipToCode END),
			(CASE WHEN ISNULL(@Comments, '') = '' THEN null ELSE @Comments END),
			(CASE WHEN ISNULL(@U_Territory, '') = '' THEN null ELSE @U_Territory END),
			GETDATE(),
			(CASE WHEN ISNULL(@RoundDif, 0) = 0 THEN 0 ELSE @RoundDif END),
			(CASE WHEN ISNULL(@DocTotal, 0) = 0 THEN 0 ELSE @DocTotal END),
			(CASE WHEN ISNULL(@Rounding, '') = '' THEN null ELSE @Rounding END),
			(CASE WHEN ISNULL(@U_VerCode, '') = '' THEN null ELSE @U_VerCode END),
			(CASE WHEN ISNULL(@U_FiscalDoc, '') = '' THEN null ELSE @U_FiscalDoc END),
			(CASE WHEN ISNULL(@U_URAPosted, '') = '' THEN null ELSE @U_URAPosted END),
			(CASE WHEN ISNULL(@U_Payment, '') = '' THEN null ELSE @U_Payment END)
		)
		SET @RETURNID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE U_OINV SET
			DocEntry=(CASE WHEN ISNULL(@DocEntry, 0) = 0 THEN DocEntry ELSE @DocEntry END),
			DocNum=(CASE WHEN ISNULL(@DocNum, 0) = 0 THEN DocNum ELSE @DocNum END),
			DocStatus=(CASE WHEN ISNULL(@DocStatus, '') = '' THEN DocStatus ELSE @DocStatus END),
			ARStatus=(CASE WHEN ISNULL(@ARStatus, '') = '' THEN ARStatus ELSE @ARStatus END),
			DocDate=(CASE WHEN ISNULL(@DocDate, '') = '' THEN DocDate ELSE @DocDate END),
			DocDueDate=(CASE WHEN ISNULL(@DocDueDate, '') = '' THEN DocDueDate ELSE @DocDueDate END),
			TaxDate=(CASE WHEN ISNULL(@TaxDate, '') = '' THEN TaxDate ELSE @TaxDate END),
			CardCode=(CASE WHEN ISNULL(@CardCode, '') = '' THEN CardCode ELSE @CardCode END),
			CardName=(CASE WHEN ISNULL(@CardName, '') = '' THEN CardName ELSE @CardName END),
			DocCur=(CASE WHEN ISNULL(@DocCur, '') = '' THEN DocCur ELSE @DocCur END),
			SlpCode=(CASE WHEN ISNULL(@SlpCode, 0) = 0 THEN SlpCode ELSE @SlpCode END),
			CntctCode=(CASE WHEN ISNULL(@CntctCode, 0) = 0 THEN CntctCode ELSE @CntctCode END),
			Series=(CASE WHEN ISNULL(@Series, 0) = 0 THEN Series ELSE @Series END),
			PayToCode=(CASE WHEN ISNULL(@PayToCode, '') = '' THEN PayToCode ELSE @PayToCode END),
			ShipToCode=	(CASE WHEN ISNULL(@ShipToCode, '') = '' THEN ShipToCode ELSE @ShipToCode END),
			Comments=(CASE WHEN ISNULL(@Comments, '') = '' THEN Comments ELSE @Comments END),
			U_Territory=(CASE WHEN ISNULL(@U_Territory, '') = '' THEN U_Territory ELSE @U_Territory END),
			UpdateDate = GETDATE(),
			UserSign2 = (CASE WHEN ISNULL(@UserSign, 0) = 0 THEN null ELSE @UserSign END),
			RoundDif = (CASE WHEN ISNULL(@RoundDif, 0) = 0 THEN RoundDif ELSE @RoundDif END),
			DocTotal = (CASE WHEN ISNULL(@DocTotal, 0) = 0 THEN DocTotal ELSE @DocTotal END),
			Rounding = (CASE WHEN ISNULL(@Rounding, '') = '' THEN Rounding ELSE @Rounding END),
			U_VerCode=(CASE WHEN ISNULL(@U_VerCode, '') = '' THEN U_VerCode ELSE @U_VerCode END),
			U_FiscalDoc=(CASE WHEN ISNULL(@U_FiscalDoc, '') = '' THEN U_FiscalDoc ELSE @U_FiscalDoc END),
			U_URAPosted=(CASE WHEN ISNULL(@U_URAPosted, '') = '' THEN U_URAPosted ELSE @U_URAPosted END),
			U_Payment=(CASE WHEN ISNULL(@U_Payment, '') = '' THEN U_Payment ELSE @U_Payment END)
			WHERE InvoiceID = @InvoiceID
		SET @RETURNID = @InvoiceID
	END


	RETURN @RETURNID
END
GO
/****** Object:  StoredProcedure [dbo].[SAP_U_OINVURAPOSTED]    Script Date: 11/7/2023 10:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SAP_U_OINVURAPOSTED]
(
	@DocEntry int=0,
	@U_VerCode nvarchar(254)='',
	@U_FiscalDoc nvarchar(254)='',
	@U_URAPosted nvarchar(254)='',
	@RETURNID int OUT
)

AS
BEGIN
	
	

	IF EXISTS (SELECT * FROM U_OINV WHERE DocEntry = @DocEntry)
	BEGIN
		UPDATE U_OINV SET
			U_VerCode=(CASE WHEN ISNULL(@U_VerCode, '') = '' THEN U_VerCode ELSE @U_VerCode END),
			U_FiscalDoc=(CASE WHEN ISNULL(@U_FiscalDoc, '') = '' THEN U_FiscalDoc ELSE @U_FiscalDoc END),
			U_URAPosted=(CASE WHEN ISNULL(@U_URAPosted, '') = '' THEN U_URAPosted ELSE @U_URAPosted END)
			WHERE DocEntry = @DocEntry
		SET @RETURNID = @DocEntry
	END
	ELSE
	BEGIN
		
		SET @RETURNID = 0
	END

	RETURN @RETURNID
END
GO
/****** Object:  StoredProcedure [dbo].[SAP_U_OQUTInsertUpdate]    Script Date: 11/7/2023 10:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SAP_U_OQUTInsertUpdate]
(
	@QuotaionID int=0,
	@DocEntry int=0,
	@DocNum int=0,
	@DocStatus char(1)='O',
	@DocDate datetime=null,
	@DocDueDate datetime=null,
	@TaxDate datetime=null,
	@CardCode nvarchar(15)='',
	@CardName nvarchar(100)='',
	@DocCur nvarchar(3)='',
	@SlpCode int=0,
	@CntctCode int=0,
	@Series int=0,
	@UserSign smallint=0,
	@PayToCode nvarchar(50)='',
	@ShipToCode nvarchar(50)='',
	@Comments nvarchar(254)='',
	@U_Territory nvarchar(254)='',
	@RoundDif numeric(19, 6)=0,
	@DocTotal numeric(19, 6)=0,
	@Rounding char(4)='tNo',
	@RETURNID int OUT
)

AS
BEGIN
	
	

	IF NOT EXISTS (SELECT * FROM U_OQUT WHERE QuotaionID = @QuotaionID)
	BEGIN
		INSERT INTO U_OQUT(
			DocEntry,
			DocNum,
			DocStatus,
			ObjType,
			DocDate,
			DocDueDate,
			TaxDate,
			CardCode,
			CardName,
			DocCur,
			SlpCode,
			CntctCode,
			Series,
			UserSign,
			PayToCode,
			ShipToCode,
			Comments,
			U_Territory,
			CreateDate,
			RoundDif,
			DocTotal,
			Rounding
		)
		VALUES
		(
			(CASE WHEN ISNULL(@DocEntry, 0) = 0 THEN 0 ELSE @DocEntry END),
			(CASE WHEN ISNULL(@DocNum, 0) = 0 THEN 0 ELSE @DocNum END),
			(CASE WHEN ISNULL(@DocStatus, '') = '' THEN 'O' ELSE @DocStatus END),
			'23',
			(CASE WHEN ISNULL(@DocDate, '') = '' THEN null ELSE @DocDate END),
			(CASE WHEN ISNULL(@DocDueDate, '') = '' THEN null ELSE @DocDueDate END),
			(CASE WHEN ISNULL(@TaxDate, '') = '' THEN null ELSE @TaxDate END),
			(CASE WHEN ISNULL(@CardCode, '') = '' THEN null ELSE @CardCode END),
			(CASE WHEN ISNULL(@CardName, '') = '' THEN null ELSE @CardName END),
			(CASE WHEN ISNULL(@DocCur, '') = '' THEN null ELSE @DocCur END),
			(CASE WHEN ISNULL(@SlpCode, 0) = 0 THEN null ELSE @SlpCode END),
			(CASE WHEN ISNULL(@CntctCode, 0) = 0 THEN null ELSE @CntctCode END),
			(CASE WHEN ISNULL(@Series, 0) = 0 THEN null ELSE @Series END),
			(CASE WHEN ISNULL(@UserSign, 0) = 0 THEN null ELSE @UserSign END),
			(CASE WHEN ISNULL(@PayToCode, '') = '' THEN null ELSE @PayToCode END),
			(CASE WHEN ISNULL(@ShipToCode, '') = '' THEN null ELSE @ShipToCode END),
			(CASE WHEN ISNULL(@Comments, '') = '' THEN null ELSE @Comments END),
			(CASE WHEN ISNULL(@U_Territory, '') = '' THEN null ELSE @U_Territory END),
			GETDATE(),
			(CASE WHEN ISNULL(@RoundDif, 0) = 0 THEN 0 ELSE @RoundDif END),
			(CASE WHEN ISNULL(@DocTotal, 0) = 0 THEN 0 ELSE @DocTotal END),
			(CASE WHEN ISNULL(@Rounding, '') = '' THEN null ELSE @Rounding END)
		)
		SET @RETURNID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE U_OQUT SET
			DocEntry=(CASE WHEN ISNULL(@DocEntry, 0) = 0 THEN DocEntry ELSE @DocEntry END),
			DocNum=(CASE WHEN ISNULL(@DocNum, 0) = 0 THEN DocNum ELSE @DocNum END),
			DocStatus=(CASE WHEN ISNULL(@DocStatus, '') = '' THEN DocStatus ELSE @DocStatus END),
			DocDate=(CASE WHEN ISNULL(@DocDate, '') = '' THEN DocDate ELSE @DocDate END),
			DocDueDate=(CASE WHEN ISNULL(@DocDueDate, '') = '' THEN DocDueDate ELSE @DocDueDate END),
			TaxDate=(CASE WHEN ISNULL(@TaxDate, '') = '' THEN TaxDate ELSE @TaxDate END),
			CardCode=(CASE WHEN ISNULL(@CardCode, '') = '' THEN CardCode ELSE @CardCode END),
			CardName=(CASE WHEN ISNULL(@CardName, '') = '' THEN CardName ELSE @CardName END),
			DocCur=(CASE WHEN ISNULL(@DocCur, '') = '' THEN DocCur ELSE @DocCur END),
			SlpCode=(CASE WHEN ISNULL(@SlpCode, 0) = 0 THEN SlpCode ELSE @SlpCode END),
			CntctCode=(CASE WHEN ISNULL(@CntctCode, 0) = 0 THEN CntctCode ELSE @CntctCode END),
			Series=(CASE WHEN ISNULL(@Series, 0) = 0 THEN Series ELSE @Series END),
			PayToCode=(CASE WHEN ISNULL(@PayToCode, '') = '' THEN PayToCode ELSE @PayToCode END),
			ShipToCode=	(CASE WHEN ISNULL(@ShipToCode, '') = '' THEN ShipToCode ELSE @ShipToCode END),
			Comments=(CASE WHEN ISNULL(@Comments, '') = '' THEN Comments ELSE @Comments END),
			U_Territory=(CASE WHEN ISNULL(@U_Territory, '') = '' THEN U_Territory ELSE @U_Territory END),
			UpdateDate = GETDATE(),
			UserSign2 = (CASE WHEN ISNULL(@UserSign, 0) = 0 THEN null ELSE @UserSign END),
			RoundDif = (CASE WHEN ISNULL(@RoundDif, 0) = 0 THEN RoundDif ELSE @RoundDif END),
			DocTotal =(CASE WHEN ISNULL(@DocTotal, 0) = 0 THEN DocTotal ELSE @DocTotal END),
			Rounding = (CASE WHEN ISNULL(@Rounding, '') = '' THEN Rounding ELSE @Rounding END)
			WHERE QuotaionID = @QuotaionID
		SET @RETURNID = @QuotaionID
	END


	RETURN @RETURNID
END
GO
/****** Object:  StoredProcedure [dbo].[SAP_U_QUT1InsertUpdate]    Script Date: 11/7/2023 10:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SAP_U_QUT1InsertUpdate]
(
	@QuotaionDetailsID int=0,
	@QuotaionID int=0,
	@ItemCode nvarchar(50),
	@Dscription nvarchar(200),
	@Quantity numeric(19, 6),
	@DiscPrcnt numeric(19, 6),
	@WhsCode nvarchar(50),
	@TaxCode nvarchar(254),
	@UnitPrice numeric(19, 6),
	@RETURNID int OUT
)

AS
BEGIN
	
	

	IF NOT EXISTS (SELECT * FROM U_QUT1 WHERE QuotaionDetailsID = @QuotaionDetailsID)
	BEGIN
		INSERT INTO U_QUT1(
			QuotaionID,
			
			ItemCode  ,
			Dscription,
			Quantity  ,
			DiscPrcnt ,
			WhsCode	  ,
			TaxCode,

			UnitPrice
		)
		VALUES
		(
			(CASE WHEN ISNULL(@QuotaionID, 0) = 0 THEN null ELSE @QuotaionID END),
			(CASE WHEN ISNULL(@ItemCode, '') = '' THEN null ELSE @ItemCode END),
			(CASE WHEN ISNULL(@Dscription, '') = '' THEN null ELSE @Dscription END),
			(CASE WHEN ISNULL(@Quantity, 0) = 0 THEN null ELSE @Quantity END),
			(CASE WHEN ISNULL(@DiscPrcnt, 0) = 0 THEN null ELSE @DiscPrcnt END),
			(CASE WHEN ISNULL(@WhsCode, '') = '' THEN null ELSE @WhsCode END),
			(CASE WHEN ISNULL(@TaxCode, '') = '' THEN null ELSE @TaxCode END),
			(CASE WHEN ISNULL(@UnitPrice, 0) = 0 THEN null ELSE @UnitPrice END)
			
		)
		SET @RETURNID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE U_QUT1 SET
			QuotaionID = @QuotaionID,
			ItemCode = (CASE WHEN ISNULL(@ItemCode, '') = '' THEN ItemCode ELSE @ItemCode END),
			Dscription = 	(CASE WHEN ISNULL(@Dscription, '') = '' THEN Dscription ELSE @Dscription END),
			Quantity = (CASE WHEN ISNULL(@Quantity, 0) = 0 THEN Quantity ELSE @Quantity END),
			DiscPrcnt = (CASE WHEN ISNULL(@DiscPrcnt, 0) = 0 THEN DiscPrcnt ELSE @DiscPrcnt END),
			WhsCode = (CASE WHEN ISNULL(@WhsCode, '') = '' THEN WhsCode ELSE @WhsCode END),
			TaxCode = (CASE WHEN ISNULL(@TaxCode, '') = '' THEN TaxCode ELSE @TaxCode END),
			UnitPrice = (CASE WHEN ISNULL(@UnitPrice, 0) = 0 THEN UnitPrice ELSE @UnitPrice END)
			WHERE QuotaionDetailsID = @QuotaionDetailsID
		SET @RETURNID = @QuotaionDetailsID
	END


	RETURN @RETURNID
END
GO
