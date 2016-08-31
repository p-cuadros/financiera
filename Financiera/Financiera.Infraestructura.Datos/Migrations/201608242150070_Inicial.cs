namespace Financiera.Infraestructura.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CC.CLIENTES",
                c => new
                    {
                        COD_CLIENTE = c.Int(nullable: false, identity: true),
                        NOM_CLIENTE = c.String(nullable: false),
                        TIP_CLIENTE = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.COD_CLIENTE);
            
            CreateTable(
                "CC.CUENTAS_CORRIENTES",
                c => new
                    {
                        NUM_CUENTA = c.Int(nullable: false, identity: true),
                        COD_CUENTA = c.String(nullable: false),
                        COD_CLIENTE = c.Int(nullable: false),
                        SAL_CUENTA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FEC_APERTURA = c.DateTime(nullable: false),
                        IND_ESTADO = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.NUM_CUENTA)
                .ForeignKey("CC.CLIENTES", t => t.COD_CLIENTE, cascadeDelete: true)
                .Index(t => t.COD_CLIENTE);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CC.CUENTAS_CORRIENTES", "COD_CLIENTE", "CC.CLIENTES");
            DropIndex("CC.CUENTAS_CORRIENTES", new[] { "COD_CLIENTE" });
            DropTable("CC.CUENTAS_CORRIENTES");
            DropTable("CC.CLIENTES");
        }
    }
}
