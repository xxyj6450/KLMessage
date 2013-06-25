SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
begin TRAN
declare @ID varchar(50)
set @id=newID()
 exec sp_AddNewMessage @id,'234234234','dxpt',20,1,0
  
  rollback
  */
ALTER proc [dbo].[sp_AddNewMessage]
	@SessionID varchar(50),
	@Content varchar(max),
	@Usercode varchar(max),
	@RecipientCount int,
	@Nettype int,
	@MessageType int=0,
	@IP varchar(50)='',
	@NetworkIP varchar(50)='',
	@CPUID varchar(50)='',
	@DisckID varchar(50)='',
	@ComputerName varchar(250)='',
	@MAC varchar(200)='',
	@ComputerUserName varchar(200)=''
as
BEGIN
	set NOCOUNT ON
	declare @msg varchar(max) 
	declare @SendPerday_CM bigint  ,
	@SendPerHour_CM bigint  ,
	@SendPerMonth_CM bigint  ,
	@SendPerday_TEL bigint  ,
	@SendPerMonth_TEL bigint  ,
	@SendPerHour_TEL bigint  ,
	@Sendperday_UN bigint  ,
	@SendPerMonth_UN bigint  ,
	@SendperHour_UN bigint  ,
	@InvockPerSecond int  ,
	@BatchSendNumbers int  
	--创建一个临时表,存储计算结果
	create TABLE #Accounts(
		  AccessUsercode varchar(50) primary key, 
		  AccessPassword varchar(50),
		  RegisterUserCode varchar(50),
		  RegisterPassword varchar(50),
		  SendCount int DEFAULT 0,
		  InvockPerSecond int DEFAULT 10,
		  BatchSendNumbers int DEFAULT 100
	)
	create TABLE #Strategy(
		StartID int,
		EndID int,
		Distance int,
		sendperhour int,
		sendperday int,
		 sendpermonth int
		)
	if not exists(
		select 1 from t_User tu with(nolock) where tu.UserCode=@Usercode 
		and @RecipientCount<=case when today=convert(varchar(10),getdate(),10) then limitperday-isnull(sendToday,0) else LimitPerday end
	)
	BEGIN
		select @msg='非常抱歉,您今天不能发出这么多短信了,给您三条路:'+char(10)+'1.少发点,省着点'+char(10)+ '2.联系管理员,多发点粮食'+char(10)+ '3:明天再来!'
		raiserror(@msg,16,1)
		return
	END
	if exists(select 1 from t_User tu with(nolock) where tu.UserCode=@Usercode and isnull(Totallimit,0)>0 and (isnull(totalsend,0)+@RecipientCount)>isnull(totallimit,0))
		BEGIN
			raiserror('非常抱歉,您的余额已经不足以继续发送这么多短信,请联系管理员及时充值.',16,1)
			return
		END
	update T_Message
		set RecipientCount=isnull(RecipientCount,0)+@RecipientCount
	where sessionid=@SessionID
	--记录
	if @@ROWCOUNT=0
	insert into T_Message(SessionID,Usercode,RecipientCount,Content,IP,ComputerName,MAC,ComputerUserName,networkip,cpuid,disckid,MessageType)
	select @SessionID,@Usercode,@RecipientCount,@Content,@ip,@ComputerName,@MAC,@ComputerUserName,@NetworkIP,@CPUID,@DisckID,@MessageType
	--返回需要的帐号
	if isnull(@MessageType,0)=0
		BEGIN
			--先将需要的账号计算出来,存储到临时表,这期间必须先用事务锁住数据
			set TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
			select @BatchSendNumbers=isnull(tal.BatchSendNumbers,1000),@InvockPerSecond=isnull(tal.InvockPerSecond,100),
			@SendPerday_CM=tal.SendPerday_CM,@SendPerHour_CM=tal.SendPerHour_CM,@SendPerMonth_CM=tal.SendPerMonth_CM,
			@SendPerday_TEL=tal.SendPerday_TEL,@SendPerMonth_TEL=tal.SendPerMonth_TEL,@SendPerHour_TEL=tal.SendPerHour_TEL,
			@Sendperday_UN=tal.Sendperday_UN,@SendPerMonth_UN=tal.SendPerMonth_UN,@SendperHour_UN=tal.SendperHour_UN
			from T_AccountLimit tal
			
			begin tran
				 
				;with cte as(
				--只取出第一条方案,方案的优先级别是,尽可能耗尽每一个号码资源,并尽可能多地耗尽资源
				select     min(a.id) as StartID,min(b.id) as EndID,min(b.id-a.id) as Distance,
				--min( dbo.fn_min(n.sendperhour,dbo.fn_min(n.sendperday,n.sendpermonth))) minSendCount,
				--min(dbo.fn_min(@Count,dbo.fn_min(n.sendperhour,dbo.fn_min(n.sendperday,n.sendpermonth)))) as SendCount,
				min(n.sendperhour) as sendperhour,min(n.sendperday) as sendperday,min(n.sendpermonth) as sendpermonth
				from T_AccountInfo a inner join  T_AccountInfo b on a.id<=b.id
				cross apply fn_AggregateAccount(a.id,b.id,@Nettype)  n
				where n.sendperday-@RecipientCount>=0
				and n.sendpermonth-@RecipientCount>=0
				and n.sendPerhour-@RecipientCount>=0
						and a.IdleState='空闲'
						and a.AccountStatus='已验证'
						and b.IdleState='空闲'
						and b.AccountStatus='已验证'
				 group by  a.id,b.id--n.sendperhour,n.sendperday,n.sendpermonth
				--order by n.sendperhour,n.sendperday,n.sendpermonth,Distance desc						--先按sendperhour,sendperday,sendpermonth升序排序,尽可能地耗尽号码资源,再按Distance(距离),尽可能大面积地消耗号码资源
				)
				--将前100条方案存储
				insert into #Strategy(StartID,EndID,Distance,sendperhour,sendperday,sendpermonth)
				select top 100 startid,endid, Distance,sendperhour,sendperday, sendpermonth 
					from cte n
				--取出最佳方案
				; with cte2 as (
					select top 1 startid,endid, Distance,sendperhour,sendperday, sendpermonth 
					from #Strategy n
					order by dbo.fn_min(dbo.fn_min(n.sendperhour,n.sendperday),n.sendpermonth),Distance desc						--先按sendperhour,sendperday,sendpermonth升序排序,尽可能地耗尽号码资源,再按Distance(距离),尽可能大面积地消耗号码资源
				)
				Insert into #Accounts
				select a.AccountID as AccessUsercode,a.Password as AccessPassword,a.ParentAccountID as  RegisterUserCode,a.parentaccountPassword as RegisterPassword,
						case when @nettype=0 then dbo.fn_min(@SendPerHour_TEL -a.SendThisHour_TEL, dbo.fn_min(@SendPerMonth_TEL-a.SendThisMonth_TEL,@SendPerDay_TEL-a.SendToday_TEL))
								when @Nettype=1 then dbo.fn_min(@SendPerHour_CM -a.SendThisHour_CM, dbo.fn_min(@SendPerMonth_CM -a.SendThisMonth_CM,@SendPerday_CM -a.SendToday_CM))
								when @Nettype=2 then dbo.fn_min(@SendPerHour_UN-a.SendThisHour_UN, dbo.fn_min(@SendPerMonth_UN -a.SendThisMonth_UN,@Sendperday_UN -a.SendToday_UN))
						end as SendCount,
								@InvockPerSecond as InvockPerSecond,@BatchSendNumbers as BatchSendNumbers
				from T_AccountInfo a inner join cte2 b on a.id between b.StartID and b.EndID
				where  isnull(a.IdleState,'空闲') in('空闲','')
								and a.AccountStatus='已验证' 
				if @@ROWCOUNT=0
					BEGIN
						if @@trancount>0 rollback
						raiserror('没有可用的资源用于短信发送,请联系系统管理员.',16,1)
						return
					END
				--再先占用号码
				update a
					set a.IdleState='占用',a.OccupyedTime=getdate(),OccupyedUsercode=@usercode,OccupyedSessionID=@SessionID
				from T_AccountInfo a inner join #Accounts b on a.AccountID=b.AccessUsercode
			commit
			--再将号码发送至客户端
			Select *-- a.AccessUsercode as AccessUsercode,a.Password as AccessPassword,a.ParentAccountID as  RegisterUserCode,a.parentaccountPassword as RegisterPassword,100 as SendCount 
			from #Accounts
		END
 
	else if @MessageType=1
		BEGIN
			select  b.AccountID as AccessUsercode,b.Password as AccessPassword,a.AccountID as RegisterUserCode,a.Password as RegisterPassword,1 as SendCount,tu.Tel
			from T_AccountInfo a cross join T_AccountInfo b
			left join t_User tu on tu.UserCode=@Usercode
			where a.AccountType='注册账号'
			and b.AccountType='访问账号'
			and b.AccountStatus='未验证'
			/*
			 update a
			set AccountStatus = '已验证',
			parentAccountID=d.AccountID,
			ParentAccountPassword = d.Password
		from T_AccountInfo a with(nolock) inner join T_MessageSendLog b with(nolock) on a.AccountID=b.AccessUsercode --and a.ParentAccountID=b.RegisterUsercode
		inner join T_NotifyStatus c with(nolock) on b.MessageID=c.MessageID and c.res=1
		inner join T_AccountInfo d on b.RegisterUsercode=d.AccountID
		 where a.AccountType='注册账户'
		 and a.AccountStatus='未验证'
		and d.AccountID>a.AccountID
		and b.SendDate>=dateadd(day,-1,getdate())
		
		 select * from T_AccountInfo tai
		select * from T_MessageSendLog
		*/
		END
END
 

