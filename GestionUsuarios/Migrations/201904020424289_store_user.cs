namespace GestionUsuarios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class store_user : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                CREATE PROCEDURE [dbo].[STR_CRUDUSER]
                (
	                @token int,
	                @Id int,
	                @Idemail int,
	                @Idgroup int,
	                @Photo nvarchar(60),
	                @Email nvarchar(80),
	                @Mainemail bit,
	                @Password nvarchar(250),
	                @Curp nvarchar(20),
	                @Rfc nvarchar(20),
	                @Name nvarchar(50),
	                @Lnamep nvarchar(30),
	                @Lnamem nvarchar(30),
	                @Birthdate date,
	                @Status bit,
	                @HighUser int
                )
                AS

	                IF @token = 1
		                BEGIN
			                DECLARE @search_id INT;
			
			                INSERT INTO Tbl_Usuarios
			                (
				                id_grupo,
				                foto_usuario,
				                password_usuario,
				                curp_usuario,
				                rfc_usuario,
				                nombre_usuario,
				                apellidoP_usuario,
				                apellidoM_usuario,
				                nacimientoF_usuario,
				                activo_usuario,
				                altaU_usuario,
				                altaF_usuario
			                )
			                VALUES
			                (
				                @Idgroup,
				                @Photo,
				                @Password,
				                @Curp,
				                @Rfc,
				                @Name,
				                @Lnamep,
				                @Lnamem,
				                @Birthdate,
				                1,
				                @HighUser,
				                GETDATE()
			                );
			
			                SET @search_id = (SELECT id FROM Tbl_Usuarios WHERE nombre_usuario = @Name AND apellidoP_usuario = @Lnamep AND altaU_usuario = @HighUser);
			
			                INSERT INTO Tbl_Correos
			                (
				                id_usuario,
				                principal_correo,
				                email_correo,
				                descripcion_correo,
				                activo_correo,
				                altaU_correo,
				                altaF_correo
			                )
			                VALUES
			                (
				                @search_id,
				                1,
				                @Email,
				                'correo principal',
				                1,
				                @HighUser,
				                GETDATE()
			                );
		                END

	                IF @token = 2
		                BEGIN
			                UPDATE Tbl_Usuarios
				                SET id_grupo = @Idgroup,
					                foto_usuario = @Photo,
					                curp_usuario = @Curp,
					                rfc_usuario = @Rfc,
					                nombre_usuario = @Name,
					                apellidoP_usuario = @Lnamep,
					                apellidoM_usuario = @Lnamem,
					                nacimientoF_usuario = @Birthdate,
					                activo_usuario = @Status,
					                actualizaU_usuario  = @HighUser,
					                altaF_usuario = GETDATE()
			                WHERE id = @Id;
			
			                UPDATE Tbl_Correos
				                SET id_usuario = @Id,
					                principal_correo = @Mainemail,
					                email_correo = @Email,
					                activo_correo = @Status,
					                actualizaU_correo = @HighUser,
					                actualizaF_correo = GETDATE()
			                WHERE id = @Idemail
		                END
		
	                IF @token = 3
		                BEGIN
			                UPDATE Tbl_Usuarios
				                SET activo_usuario = 0,
					                eliminaU_usuario  = @HighUser,
					                eliminaF_usuario = GETDATE()
			                WHERE id = @Id;
			
			                UPDATE Tbl_Correos
				                SET principal_correo = 0,
					                activo_correo = 0,
					                eliminaU_correo = @HighUser,
					                eliminaF_correo = GETDATE()
			                WHERE id = @Idemail
		                END
            ");
        }
        
        public override void Down()
        {
            Sql(@"DROP PROCEDURE dbo.STR_CRUDUSER");
        }
    }
}
