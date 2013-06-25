/*

select * from t_UserLoginLog tull
select * from T_Version tv
exec sp_checkLogin 'dxpt','5582','B97C786F-3823-49C4-B9DC-CB854516C91E','','','','','',''
*/

alter proc sp_CheckLogin
	@Usercode varchar(50),
	@Password varchar(50),
	@VersionID varchar(50),
	@IP varchar(20),
	@MAC varchar(50),
	@CPUID varchar(50),
	@DISKID varchar(50),
	@ComputerName varchar(50),
	@ComputerUserName varchar(50)
as
BEGIN
	set NOCOUNT ON
	declare @RowCount int
	if not EXISTS (		select 1 from t_Version where versionid=@VersionID and inuse=1)
	BEGIN
		insert into t_UserLoginLog(Usercode,Version,IP,MAC,CPUID,DISKID,ComputerName,ComputerUserName,LoginState)
			select @Usercode,@VersionID,@IP,@MAC,@CPUID,@DISKID,@ComputerName,@ComputerUserName,-2
		raiserror('��ʹ�õ�ϵͳ�汾�Ѿ�����,���������°汾.',16,1)
		return
	END
	select top 1 * From t_User tu where tu.UserCode=@Usercode and convert(varbinary,tu.Password)=convert(varbinary,@Password)
	select @RowCount=  @@ROWCOUNT
	if @RowCount=0
		BEGIN
			insert into t_UserLoginLog(Usercode,Version,IP,MAC,CPUID,DISKID,ComputerName,ComputerUserName,LoginState)
			select @Usercode,@VersionID,@IP,@MAC,@CPUID,@DISKID,@ComputerName,@ComputerUserName,-1
			raiserror('�û��������벻��ȷ.',16,1)
			return
		END
	else if @RowCount>1
		BEGIN
			insert into t_UserLoginLog(Usercode,Version,IP,MAC,CPUID,DISKID,ComputerName,ComputerUserName,LoginState)
			select @Usercode,@VersionID,@IP,@MAC,@CPUID,@DISKID,@ComputerName,@ComputerUserName,-99
			raiserror('��ϲ��ע��ɹ�,��ļ������Ϣ�Ѿ����Ǽ�,�����Ժ����ϵ��.',16,1)
			return
		END
	insert into t_UserLoginLog(Usercode,Version,IP,MAC,CPUID,DISKID,ComputerName,ComputerUserName,LoginState)
	select @Usercode,@VersionID,@IP,@MAC,@CPUID,@DISKID,@ComputerName,@ComputerUserName,1
END

 