SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER function [dbo].[fn_AggregateAccount](
	@StartID int,
	@EndID int,
	@Nettype int)
returns @table table(
	[SendPerday ] [bigint]  ,
	[SendPerHour ] [bigint]  ,
	[SendPerMonth ] [bigint]  
 
)
as
BEGIN
	declare @SendPerday_CM bigint  ,
	@SendPerHour_CM bigint  ,
	@SendPerMonth_CM bigint  ,
	@SendPerday_TEL bigint  ,
	@SendPerMonth_TEL bigint  ,
	@SendPerHour_TEL bigint  ,
	@Sendperday_UN bigint  ,
	@SendPerMonth_UN bigint  ,
	@SendperHour_UN bigint  
	select  
			@SendPerday_CM=tal.SendPerday_CM,@SendPerHour_CM=tal.SendPerHour_CM,@SendPerMonth_CM=tal.SendPerMonth_CM,
			@SendPerday_TEL=tal.SendPerday_TEL,@SendPerMonth_TEL=tal.SendPerMonth_TEL,@SendPerHour_TEL=tal.SendPerHour_TEL,
			@Sendperday_UN=tal.Sendperday_UN,@SendPerMonth_UN=tal.SendPerMonth_UN,@SendperHour_UN=tal.SendperHour_UN
			from T_AccountLimit tal with(nolock)
	if @Nettype=0
	BEGIN
		insert into @table
		select   sum(@Sendperday_TEL-isnull(tai.SendToday_TEL,0)) as SendToday_TEL,
		sum(@SendperHour_TEL-isnull(tai.SendThisHour_TEL,0)) as SendThisHour_TEL,
									sum(@SendPerMonth_TEL-isnull(tai.SendThisMonth_TEL,0)) as SendThisMonth_TEL
		from T_AccountInfo tai 
		where tai.Id between @StartID and @EndID
		and tai.IdleState='空闲'
		and tai.AccountStatus='已验证'
	END
 	if @Nettype=1
	BEGIN
		insert into @table
		select   sum(@Sendperday_CM-isnull(tai.SendToday_CM,0)) as SendToday_CM,
		sum(@SendperHour_CM-isnull(tai.SendThisHour_CM,0)) as SendThisHour_CM,
									sum(@SendPerMonth_CM-isnull(tai.SendThisMonth_CM,0)) as SendThisMonth_CM
		from T_AccountInfo tai 
		where tai.Id between @StartID and @EndID
		and tai.IdleState='空闲'
		and tai.AccountStatus='已验证'
	END
	if @Nettype=2
	BEGIN
		insert into @table
		select   sum(@Sendperday_UN-isnull(tai.SendToday_UN,0)) as SendToday_UN,
		sum(@SendperHour_UN-isnull(tai.SendThisHour_UN,0)) as SendThisHour_UN,
									sum(@SendPerMonth_UN-isnull(tai.SendThisMonth_UN,0)) as SendThisMonth_UN
									
		from T_AccountInfo tai 
		where tai.Id between @StartID and @EndID
		and tai.IdleState='空闲'
		and tai.AccountStatus='已验证'
	END
	return
END

 