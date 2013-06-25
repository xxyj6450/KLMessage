/*
begin TRAN
 
declare @ID varchar(50)
set @id=newID()
 exec sp_AddNewMessageEx @id,'234234234','dxpt',53000,1,0
 
 rollback
 */
alter proc sp_AddNewMessage
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
	set NOCOUNT on
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
	@BatchSendNumbers int  ,
	@DistributionMode varchar(20),
	@MergeLimit bit,
	@LimitPerday int,
	@TotalSend bigint,
	@TotalLimit bigint,
	@SendThisHour_CM int,
	@SendToday_CM int,
	@SendThisMonth_CM bigint,
	@SendThisHour_TEL int,
	@SendToday_TEL int,
	@SendThisMonth_TEL bigint,
	@SendThisHour_UN int,
	@SendToday_UN int,
	@SendThisMonth_UN bigint,
	@ID int,
	@AccessAccount varchar(50),
	@AccessAccountPassword varchar(50),
	@ParentAccount varchar(50),
	@ParentPassword varchar(50),
	@TotalCount bigint,@SendCount int
	--创建一个临时表,存储计算结果
	create TABLE #Accounts(
		ID int,
		  AccessUsercode varchar(50) primary key, 
		  AccessPassword varchar(50),
		  RegisterUserCode varchar(50),
		  RegisterPassword varchar(50),
		  SendCount int DEFAULT 0,
		  InvockPerSecond int DEFAULT 10,
		  BatchSendNumbers int DEFAULT 100
	)
	select @DistributionMode=isnull(DistributionMode,'节省资源'),
	@LimitPerday=case when tu.today=convert(varchar(10),getdate(),120) then limitperday-isnull(sendToday,0) else isnull(LimitPerday,0) end,
	@TotalLimit=isnull(tu.TotalLimit,0),@TotalSend=isnull(tu.TotalSend,0)
	from t_User tu with(nolock)
	where tu.UserCode=@Usercode
	if @@ROWCOUNT=0
		BEGIN
			raiserror('用户信息不存在,无法申请短信资源.',16,1)
			return
		END
	if @TotalLimit>0 and @TotalSend+@RecipientCount>@TotalLimit
		BEGIN
			select @msg='非常抱歉,您的余额为' +convert(varchar(20),@totalLimit-@totalSend) +'已经不足以继续发送这么多短信,请联系管理员及时充值.'
			raiserror(@msg,16,1)
			return
		END
	if @RecipientCount>@LimitPerday
	BEGIN
		select @msg='非常抱歉,您今天还剩余'+convert(varchar(20),@LimitPerday)+'条短信,已经不能发出这么多短信了,给您三条路:'+char(10)+'1.少发点,省着点'+char(10)+ '2.联系管理员,多发点粮食'+char(10)+ '3:明天再来!'
		raiserror(@msg,16,1)
		return
	END
	
	update T_Message
		set RecipientCount=isnull(RecipientCount,0)+@RecipientCount
	where sessionid=@SessionID
	--记录
	if @@ROWCOUNT=0
	insert into T_Message(SessionID,Usercode,RecipientCount,Content,IP,ComputerName,MAC,ComputerUserName,networkip,cpuid,disckid,MessageType)
	select @SessionID,@Usercode,@RecipientCount,@Content,@ip,@ComputerName,@MAC,@ComputerUserName,@NetworkIP,@CPUID,@DisckID,@MessageType
	set TRANSACTION ISOLATION LEVEL READ COMMITTED
	begin tran
	if isnull(@MessageType,0) in(0,2)
		BEGIN
			select @BatchSendNumbers=isnull(tal.BatchSendNumbers,1000),@InvockPerSecond=isnull(tal.InvockPerSecond,100),
				@SendPerday_CM=tal.SendPerday_CM,@SendPerHour_CM=tal.SendPerHour_CM,@SendPerMonth_CM=tal.SendPerMonth_CM,
				@SendPerday_TEL=tal.SendPerday_TEL,@SendPerMonth_TEL=tal.SendPerMonth_TEL,@SendPerHour_TEL=tal.SendPerHour_TEL,
				@Sendperday_UN=tal.Sendperday_UN,@SendPerMonth_UN=tal.SendPerMonth_UN,@SendperHour_UN=tal.SendperHour_UN,@MergeLimit=isnull(tal.MergeLimit,0)
			from T_AccountLimit tal
			if @Nettype=0
				BEGIN
					if @DistributionMode='节省资源'
						BEGIN
							declare abc CURSOR READ_ONLY fast_forward FOR
							select tai.id, tai.AccountID,tai.Password,tai.ParentAccountID,tai.ParentAccountPassword,
							tai.SendToday_CM,tai.SendThisHour_CM,tai.SendThisMonth_CM,
							tai.SendToday_TEL,tai.SendThisMonth_TEL,tai.SendThisHour_TEL,
							tai.SendToday_UN,tai.SendThisMonth_UN,tai.SendThisHour_UN 
							from T_AccountInfo tai with(readpast)
							where tai.AccountStatus='已验证'
							and tai.IdleState='空闲'
							and tai.SendThisHour_TEL		<=@SendPerHour_TEL	
							and tai.SendToday_TEL<=@SendPerday_TEL
							and tai.sendthismonth_tel<=@SendPerMonth_TEL
							--order by tai.SendThisMonth_TEL desc,tai.SendToday_TEL desc,tai.SendThisHour_TEL desc
							order by tai.SendThisHour_TEL desc,tai.SendToday_TEL desc, tai.SendThisMonth_TEL desc
						END
					else
						BEGIN
							declare abc CURSOR READ_ONLY fast_forward FOR
							select  tai.id,tai.AccountID,tai.Password,tai.ParentAccountID,tai.ParentAccountPassword,
							tai.SendToday_CM,tai.SendThisHour_CM,tai.SendThisMonth_CM,
							tai.SendToday_TEL,tai.SendThisMonth_TEL,tai.SendThisHour_TEL,
							tai.SendToday_UN,tai.SendThisMonth_UN,tai.SendThisHour_UN 
							from T_AccountInfo tai with(readpast)
							where tai.AccountStatus='已验证'
							and tai.IdleState='空闲'
							and tai.SendThisHour_TEL		<=@SendPerHour_TEL	
							and tai.SendToday_TEL<=@SendPerday_TEL
							and tai.sendthismonth_tel<=@SendPerMonth_TEL
							order by tai.SendThisHour_TEL asc,tai.SendToday_TEL asc,tai.SendThisMonth_TEL asc
						END
		
				END
			if @Nettype=1
				BEGIN
					if @DistributionMode='节省资源' 
						BEGIN
							declare abc CURSOR READ_ONLY fast_forward FOR
							select  tai.id,tai.AccountID,tai.Password,tai.ParentAccountID,tai.ParentAccountPassword,
							tai.SendToday_CM,tai.SendThisHour_CM,tai.SendThisMonth_CM,
							tai.SendToday_TEL,tai.SendThisMonth_TEL,tai.SendThisHour_TEL,
							tai.SendToday_UN,tai.SendThisMonth_UN,tai.SendThisHour_UN 
							from T_AccountInfo tai with(readpast)
							where tai.AccountStatus='已验证'
							and tai.IdleState='空闲'
							and tai.SendThisHour_CM		<=@SendPerHour_CM	
							and tai.SendToday_CM<=@SendPerday_CM
							and tai.sendthismonth_CM<=@SendPerMonth_CM
							--order by tai.SendThisMonth_CM desc,tai.SendToday_CM desc,tai.SendThisHour_CM desc
							order by tai.SendThisHour_CM desc,tai.SendToday_CM desc, tai.SendThisMonth_CM desc
						END
					else
						BEGIN
							declare abc CURSOR READ_ONLY fast_forward FOR
							select  tai.id, tai.AccountID,tai.Password,tai.ParentAccountID,tai.ParentAccountPassword,
							tai.SendToday_CM,tai.SendThisHour_CM,tai.SendThisMonth_CM,
							tai.SendToday_TEL,tai.SendThisMonth_TEL,tai.SendThisHour_TEL,
							tai.SendToday_UN,tai.SendThisMonth_UN,tai.SendThisHour_UN 
							from T_AccountInfo tai with(readpast)
							where tai.AccountStatus='已验证'
							and tai.IdleState='空闲'
							and tai.SendThisHour_CM		<=@SendPerHour_CM	
							and tai.SendToday_CM<=@SendPerday_CM
							and tai.sendthismonth_CM<=@SendPerMonth_CM
							--order by tai.SendThisMonth_CM asc,tai.SendToday_CM asc,tai.SendThisHour_CM asc
							order by tai.SendThisHour_CM asc,tai.SendToday_CM asc,tai.SendThisMonth_CM asc
						END
		
				END
			if @Nettype=2
				BEGIN
					if @DistributionMode='节省资源'
						BEGIN
							declare abc CURSOR READ_ONLY fast_forward FOR
							select  tai.id,tai.AccountID,tai.Password,tai.ParentAccountID,tai.ParentAccountPassword,
							tai.SendToday_CM,tai.SendThisHour_CM,tai.SendThisMonth_CM,
							tai.SendToday_TEL,tai.SendThisMonth_TEL,tai.SendThisHour_TEL,
							tai.SendToday_UN,tai.SendThisMonth_UN,tai.SendThisHour_UN 
							from T_AccountInfo tai with(readpast)
							where tai.AccountStatus='已验证'
							and tai.IdleState='空闲'
							and tai.SendThisHour_UN		<=@SendPerHour_UN	
							and tai.SendToday_UN<=@SendPerday_UN
							and tai.sendthismonth_UN<=@SendPerMonth_UN
							order by tai.SendThisHour_UN desc,tai.SendToday_UN desc,tai.SendThisMonth_UN desc
						END
					else
						BEGIN
							declare abc CURSOR READ_ONLY fast_forward FOR
							select  tai.id,tai.AccountID,tai.Password,tai.ParentAccountID,tai.ParentAccountPassword,
							tai.SendToday_CM,tai.SendThisHour_CM,tai.SendThisMonth_CM,
							tai.SendToday_TEL,tai.SendThisMonth_TEL,tai.SendThisHour_TEL,
							tai.SendToday_UN,tai.SendThisMonth_UN,tai.SendThisHour_UN 
							from T_AccountInfo tai with(readpast)
							where tai.AccountStatus='已验证'
							and tai.IdleState='空闲'
							and tai.SendThisHour_UN		<=@SendPerHour_UN	
							and tai.SendToday_UN<=@SendPerday_UN
							and tai.sendthismonth_UN<=@SendPerMonth_UN
							--order by tai.SendThisMonth_UN asc,tai.SendToday_UN asc,tai.SendThisHour_UN asc
							order by tai.SendThisHour_UN asc,tai.SendToday_UN asc,tai.SendThisMonth_UN asc
						END
		
				END
			select @TotalCount=0
			open abc
			fetch next FROM abc into @id, @AccessAccount,@AccessAccountPassword,@ParentAccount,@ParentPassword,
			@SendToday_CM,@SendThisHour_CM,@SendThisMonth_CM,
			@SendToday_TEL,@SendThisMonth_TEL,@SendThisHour_TEL,
			@SendToday_UN,@SendThisMonth_UN,@SendThisHour_UN
			while @@FETCH_STATUS=0
				BEGIN
					if @TotalCount>=@RecipientCount goto ExitLine
					if @Nettype=0
						BEGIN
							select @SendCount=     dbo.fn_min(@SendPerHour_TEL -@SendThisHour_TEL,dbo.fn_min(@SendPerday_TEL -@SendToday_TEL, @SendPerMonth_TEL -@SendThisMonth_TEL))
						END
		
					if @Nettype=1
						BEGIN
							select @SendCount=     dbo.fn_min(@SendPerHour_CM -@SendThisHour_CM,dbo.fn_min(@SendPerday_CM -@SendToday_CM, @SendPerMonth_CM -@SendThisMonth_CM))
						END
					if @Nettype=2
						BEGIN
							select @SendCount=     dbo.fn_min(@SendPerHour_UN -@SendThisHour_UN,dbo.fn_min(@SendPerday_UN -@SendToday_UN, @SendPerMonth_UN -@SendThisMonth_UN))
						END
					if @SendCount>0
					BEGIN
						set @TotalCount=@TotalCount+@SendCount
						insert into #Accounts(id,AccessUsercode,AccessPassword,RegisterUserCode,RegisterPassword,SendCount)
						select @id, @AccessAccount,@AccessAccountPassword,@ParentAccount,@ParentPassword,@SendCount
					END
						fetch next FROM abc into @id, @AccessAccount,@AccessAccountPassword,@ParentAccount,@ParentPassword,
						@SendToday_CM,@SendThisHour_CM,@SendThisMonth_CM,
					@SendToday_TEL,@SendThisMonth_TEL,@SendThisHour_TEL,
					@SendToday_UN,@SendThisMonth_UN,@SendThisHour_UN
				END
	ExitLine:
			close abc
			deallocate abc
		END
	--Select a.AccessUsercode,a.AccessPassword,a.RegisterUserCode,a.RegisterPassword,a.SendCount,@BatchSendNumbers as BatchSendNumbers,@InvockPerSecond as InvockPerSecond
	 -- From #Accounts a
	if @TotalCount<@RecipientCount
		BEGIN
			--Select a.AccessUsercode,a.AccessPassword,a.RegisterUserCode,a.RegisterPassword,a.SendCount,@BatchSendNumbers as BatchSendNumbers,@InvockPerSecond as InvockPerSecond 	  From #Accounts a
			print @TotalCount
			rollback
			raiserror('账户不足以发送这么多短信',16,1)
			return
		END
	update a
	set a.IdleState='占用',
	a.OccupyedTime=getdate(),
	a.OccupyedUsercode=@Usercode,
	a.OccupyedSessionID=@SessionID
	From T_AccountInfo a  with(readpast) inner join #Accounts b on a.AccountID=b.AccessUsercode
	commit
	Select a.id, a.AccessUsercode,a.AccessPassword,a.RegisterUserCode,a.RegisterPassword,a.SendCount,@BatchSendNumbers as BatchSendNumbers,@InvockPerSecond as InvockPerSecond
	  From #Accounts a
	--order by id
	if @@ROWCOUNT=0
		BEGIN
			raiserror('没有资源供发送短信,请联系系统管理员',16,1)
			return
		END
	 --select sum(sendcount) from #Accounts
end