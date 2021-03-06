SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [sp_FinishedSendMessage] 'admin','','07623436330','B60A233B-3861-4B6C-9790-81BBB2D989E3',94,1,2,0
ALTER proc [dbo].[sp_FinishedSendMessage]
	@Usercode varchar(50),
	@RegisterUsercode varchar(50),
	@AccessUsercode varchar(50),
	@SessionID varchar(50),
	@MessageID INT,
	@RecipientsCount int,
	@Nettype int=0,
	@Status int=0
as
	BEGIN
		set NOCOUNT on
		--若MessageID不为0,则说明指定的消息已经发送完毕,若MessageID为0,则认为是整个消息会话已经发送完毕
		if  @MessageID<>0
			BEGIN
				 
				update T_MessageSendLog
					set Status = @Status,
					successedCount=case when @Status=0 then isnull(@RecipientsCount,0)+@RecipientsCount else isnull(successedCount,0) end
				where MessageID=@MessageID and SessionID=@SessionID
				if @@ROWCOUNT=0 return
				--更新用户信息
				if @Status=0
					BEGIN
						--更新用户统计信息
						update a
							set a.SendToday=case when convert(varchar(10),getdate(),120)=a.today then isnull( a.SendToday,0)+@RecipientsCount else @RecipientsCount end,
							  a.SendThisMonth=case when convert(varchar(7),getdate(),120)=a.thismonth then isnull( a.SendThisMonth,0)+@RecipientsCount else @RecipientsCount end,
							TotalSend=isnull(TotalSend,0)+@RecipientsCount,
							today=convert(varchar(10),getdate(),120),
							thismonth=  convert(varchar(7),getdate(),120)
						from t_User a with(nolock) 
						where a.UserCode=@Usercode
						--更新账户统计信息
						update tu
							set tu.theDay=convert(varchar(10),getdate(),120),
							tu.SendToday_CM= case when @Nettype=1 then
																								case when  isnull(tu.theDay,convert(varchar(10),getdate(),120))=convert(varchar(10),getdate(),120)   then isnull(tu.SendToday_CM,0)+@RecipientsCount 
																									else isnull(@RecipientsCount,0) 
																								end
																else isnull(SendToday_CM,0)
															end,
							tu.SendToday_TEL= case when @Nettype=0 then
																								case when  isnull(tu.theDay,convert(varchar(10),getdate(),120))=convert(varchar(10),getdate(),120)   then isnull(tu.SendToday_TEL,0)+@RecipientsCount 
																									else isnull(@RecipientsCount,0) 
																								end
																else isnull(SendToday_TEL,0)
															end,
							tu.SendToday_UN= case when @Nettype=2 then
																								case when  isnull(tu.theDay,convert(varchar(10),getdate(),120))=convert(varchar(10),getdate(),120)   then isnull(tu.SendToday_UN,0)+@RecipientsCount 
																									else isnull(@RecipientsCount,0) 
																								end
																else isnull(SendToday_UN,0)
															end,
							tu.theMonth=convert(varchar(7),getdate(),120),
							tu.SendThisMonth_CM= case when @Nettype=1 then
																								case when  isnull(tu.theMonth,convert(varchar(7),getdate(),120))=convert(varchar(7),getdate(),120)   then isnull(tu.SendThisMonth_CM,0)+@RecipientsCount 
																									else isnull(@RecipientsCount,0) 
																								end
																else isnull(SendThisMonth_CM,0)
															end,
							tu.SendThisMonth_TEL= case when @Nettype=0 then
																								case when  isnull(tu.theMonth,convert(varchar(7),getdate(),120))=convert(varchar(7),getdate(),120)   then isnull(tu.SendThisMonth_TEL,0)+@RecipientsCount 
																									else isnull(@RecipientsCount,0) 
																								end
																else isnull(SendThisMonth_TEL,0)
															end,
							tu.SendThisMonth_UN= case when @Nettype=2 then
																								case when  isnull(tu.theMonth,convert(varchar(7),getdate(),120))=convert(varchar(7),getdate(),120)   then isnull(tu.SendThisMonth_UN,0)+@RecipientsCount 
																									else isnull(@RecipientsCount,0) 
																								end
																else isnull(SendThisMonth_UN,0)
															end,
							tu.theHour=datepart(hour,getdate()),
							tu.SendThisHour_CM= case when @Nettype=1 then
																								case when  isnull(tu.theHour,datepart(hour,getdate()))=datepart(hour,getdate())   then isnull(tu.SendThisHour_CM,0)+@RecipientsCount 
																									else isnull(@RecipientsCount,0) 
																								end
																else isnull(SendThisHour_CM,0)
															end,
							tu.SendThisHour_TEL= case when @Nettype=0 then
																								case when   isnull(tu.theHour,datepart(hour,getdate()))=datepart(hour,getdate())   then isnull(tu.SendThisHour_TEL,0)+@RecipientsCount 
																									else isnull(@RecipientsCount,0) 
																								end
																else isnull(SendThisHour_TEL,0)
															end,
							tu.SendThisHour_UN= case when @Nettype=2 then
																								case when  isnull(tu.theHour,datepart(hour,getdate()))=datepart(hour,getdate())  then isnull(tu.SendThisHour_UN,0)+@RecipientsCount 
																									else isnull(@RecipientsCount,0) 
																								end
																else isnull(SendThisHour_UN,0)
															end,
							tu.totalSend_CM= case when @Nettype=1 then isnull(tu.totalSend_CM,0)+isnull(@RecipientsCount,0) else isnull(tu.totalSend_CM,0) end,
							tu.totalSend_TEL= case when @Nettype=0 then isnull(tu.totalSend_TEL,0)+isnull(@RecipientsCount,0) else isnull(tu.totalSend_TEL,0) end,
							tu.totalSend_UN= case when @Nettype=2 then isnull(tu.totalSend_UN,0)+isnull(@RecipientsCount,0) else isnull(tu.totalSend_UN,0) end
 
						from T_AccountInfo  tu
						where tu.AccountID=@AccessUsercode
					END
			END
			else
			BEGIN
					--更新会话状态
					update T_Message	
						set status=@Status,FinishedDate=getdate()
					where SessionID=@SessionID
					--释放号码
					update a
						set a.IdleState='空闲'
					from t_accountinfo a,T_MessageSendLog b
					where b.SessionID=@SessionID
					and a.AccountID=b.AccessUsercode
				END
		
	END
 