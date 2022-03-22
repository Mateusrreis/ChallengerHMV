using Challenger.Models.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Challenger.Repository
{
    public partial class HMVContext : DbContext
    {
        public HMVContext()
        {
        }

        public HMVContext(DbContextOptions<HMVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgendaConsulta> AgendaConsulta { get; set; }
        public virtual DbSet<AgendaExame> AgendaExame { get; set; }
        public virtual DbSet<Atendimento> Atendimento { get; set; }
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Convenio> Convenio { get; set; }
        public virtual DbSet<Especialidade> Especialidade { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Exame> Exame { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<PerfilxUsuario> PerfilxUsuario { get; set; }
        public virtual DbSet<Prescricao> Prescricao { get; set; }
        public virtual DbSet<TermosCondicaoUso> TermosCondicaoUso { get; set; }
        public virtual DbSet<TipoExame> TipoExame { get; set; }
        public virtual DbSet<TipoPrescricao> TipoPrescricao { get; set; }
        public virtual DbSet<Triagem> Triagem { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(@$"Server={Environment.GetEnvironmentVariable("Server")};Database={Environment.GetEnvironmentVariable("Database")};Port=3306;User={Environment.GetEnvironmentVariable("UserDatabaseChallenger")};Password={Environment.GetEnvironmentVariable("Password")}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendaConsulta>(entity =>
            {
                entity.HasKey(e => e.IdAgendaConsulta)
                    .HasName("PRIMARY");


                entity.Property(e => e.IdAgendaConsulta)
                    .HasColumnName("idAgendaConsulta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dtCadastro")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DtConsulta)
                    .HasColumnName("dtConsulta")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.HrConsulta)
                    .HasColumnName("hrConsulta")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'Null'");

                entity.Property(e => e.IdMedico)
                    .HasColumnName("idMedico")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IntMinsDuracaoConsulta)
                    .HasColumnName("intMinsDuracaoConsulta")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.idMedicoNavigation)
                    .WithMany(p => p.AgendaConsulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("idMedico");
            });

            modelBuilder.Entity<AgendaExame>(entity =>
            {
                entity.HasKey(e => e.IdAgendaExame)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdTipoExame)
                    .HasName("idExame_idx");

                entity.Property(e => e.IdAgendaExame)
                    .HasColumnName("idAgendaExame")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dtCadastro")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DtExame)
                    .HasColumnName("dtExame")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.HrExame)
                    .HasColumnName("hrExame")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdMedico)
                    .HasColumnName("idMedico")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdTipoExame)
                    .HasColumnName("idTipoExame")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IntMinsDuracaoExame)
                    .HasColumnName("intMinsDuracaoExame")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.AgendaExame)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("idPaciente");

                entity.HasOne(d => d.IdTipoExameNavigation)
                    .WithMany(p => p.AgendaExame)
                    .HasForeignKey(d => d.IdTipoExame)
                    .HasConstraintName("idTipoExame");
            });

            modelBuilder.Entity<Atendimento>(entity =>
            {
                entity.HasKey(e => e.IdAtendimento)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdAgendaConsulta)
                    .HasName("idAgendaConsulta_idx");

                entity.HasIndex(e => e.IdConvenio)
                    .HasName("idConvenio_idx");

                entity.Property(e => e.IdAtendimento)
                    .HasColumnName("idAtendimento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodCartaoConvenio)
                    .HasColumnName("codCartaoConvenio")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DtAtendimento)
                    .HasColumnName("dtAtendimento")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FlgParticular)
                    .HasColumnName("flgParticular")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdAgendaConsulta)
                    .HasColumnName("idAgendaConsulta")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdConsulta)
                    .HasColumnName("idConsulta")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdConvenio)
                    .HasColumnName("idConvenio")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StrConvenioCategoria)
                    .HasColumnName("strConvenioCategoria")
                    .HasMaxLength(120)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdAgendaConsultaNavigation)
                    .WithMany(p => p.Atendimento)
                    .HasForeignKey(d => d.IdAgendaConsulta)
                    .HasConstraintName("idAgendaConsulta");

                entity.HasOne(d => d.IdConvenioNavigation)
                    .WithMany(p => p.Atendimento)
                    .HasForeignKey(d => d.IdConvenio)
                    .HasConstraintName("idConvenio");
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdAtendimento)
                    .HasName("idAtendimento_idx");

                entity.HasIndex(e => e.IdPrescricao)
                    .HasName("idPrescricao_idx");

                entity.Property(e => e.IdConsulta)
                    .HasColumnName("idConsulta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DtConsulta)
                    .HasColumnName("dtConsulta")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FlgTeleconsulta)
                    .HasColumnName("flgTeleconsulta")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdAtendimento)
                    .HasColumnName("idAtendimento")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdMedico)
                    .HasColumnName("idMedico")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdPrescricao)
                    .HasColumnName("idPrescricao")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StrPlataformaTeleconsulta)
                    .HasColumnName("strPlataformaTeleconsulta")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StrRelatorioMedico)
                    .HasColumnName("strRelatorioMedico")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdAtendimentoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdAtendimento)
                    .HasConstraintName("idAtendimento");

                entity.HasOne(d => d.IdPrescricaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPrescricao)
                    .HasConstraintName("idPrescricao");
            });

            modelBuilder.Entity<Convenio>(entity =>
            {
                entity.HasKey(e => e.IdConvenio)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdConvenio)
                    .HasColumnName("idConvenio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StrConvenio)
                    .HasColumnName("strConvenio")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdEspecialidade)
                    .HasColumnName("idEspecialidade")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StrEspecialidade)
                    .HasColumnName("strEspecialidade")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StrEstado)
                    .HasColumnName("strEstado")
                    .HasMaxLength(120)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Exame>(entity =>
            {
                entity.HasKey(e => e.IdExame)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdExame)
                    .HasColumnName("idExame")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DtExame)
                    .HasColumnName("dtExame")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdAgendaExame)
                    .HasColumnName("idAgendaExame")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UrlAnexo)
                    .HasColumnName("urlAnexo")
                    .HasMaxLength(300)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdExameNavigation)
                    .WithOne(p => p.Exame)
                    .HasForeignKey<Exame>(d => d.IdExame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idAgendaExame");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdEspecialidade)
                    .HasName("idEspecialidade_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("idUsuario_idx");

                entity.Property(e => e.IdMedico)
                    .HasColumnName("idMedico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FltCrm)
                    .HasColumnName("fltCRM")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdEspecialidade)
                    .HasColumnName("idEspecialidade")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.UsuarioMap)
                   .WithMany(p => p.Medico)
                   .HasForeignKey(d => d.IdUsuario)
                   .HasConstraintName("IdUsuario");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdEstado)
                    .HasName("idEstado_idx");

                entity.Property(e => e.IdMunicipio)
                    .HasColumnName("idMunicipio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StrMunicipio)
                    .HasColumnName("strMunicipio")
                    .HasMaxLength(120)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdPerfil)
                    .HasColumnName("idPerfil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StrPerfil)
                    .HasColumnName("strPerfil")
                    .HasMaxLength(120)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<PerfilxUsuario>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.IdPerfil)
                    .HasName("idPerfil_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("idUsuario_idx");

                entity.Property(e => e.FlgAceiteTermoCondicaoUso)
                    .HasColumnName("flgAceiteTermoCondicaoUso")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdPerfil)
                    .HasColumnName("idPerfil")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Prescricao>(entity =>
            {
                entity.HasKey(e => e.IdPrescricao)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdTipoPrescricao)
                    .HasName("idTipoPrescricao_idx");

                entity.Property(e => e.IdPrescricao)
                    .HasColumnName("idPrescricao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FlgRetorno)
                    .HasColumnName("flgRetorno")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdTipoPrescricao)
                    .HasColumnName("idTipoPrescricao")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IntDiasRetorno)
                    .HasColumnName("intDiasRetorno")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StrObservacao)
                    .HasColumnName("strObservacao")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UrlAtestado)
                    .HasColumnName("urlAtestado")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UrlGuiaExame)
                    .HasColumnName("urlGuiaExame")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UrlReceituario)
                    .HasColumnName("urlReceituario")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdTipoPrescricaoNavigation)
                    .WithMany(p => p.Prescricao)
                    .HasForeignKey(d => d.IdTipoPrescricao)
                    .HasConstraintName("idTipoPrescricao");
            });

            modelBuilder.Entity<TermosCondicaoUso>(entity =>
            {
                entity.HasKey(e => e.IdTermosCondicaoUso)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdPerfil)
                    .HasName("idPerfil_idx");

                entity.Property(e => e.IdTermosCondicaoUso)
                    .HasColumnName("idTermosCondicaoUso")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DtFimVigencia)
                    .HasColumnName("dtFimVigencia")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DtInicioVigencia)
                    .HasColumnName("dtInicioVigencia")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdPerfil)
                    .HasColumnName("idPerfil")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StrTermosCondicaoUso)
                    .HasColumnName("strTermosCondicaoUso")
                    .HasMaxLength(1500)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TipoExame>(entity =>
            {
                entity.HasKey(e => e.IdTipoExame)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdTipoExame)
                    .HasColumnName("idTipoExame")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StrDescricao)
                    .HasColumnName("strDescricao")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StrPreparoExame)
                    .HasColumnName("strPreparoExame")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TipoPrescricao>(entity =>
            {
                entity.HasKey(e => e.IdTipoPrescricao)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdTipoPrescricao)
                    .HasColumnName("idTipoPrescricao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StrTipoPrescricao)
                    .HasColumnName("strTipoPrescricao")
                    .HasMaxLength(120)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Triagem>(entity =>
            {
                entity.HasKey(e => e.IdTriagem)
                    .HasName("PRIMARY");

                entity.HasComment("		");

                entity.HasIndex(e => e.IdConsulta)
                    .HasName("idConsulta_idx");

                entity.Property(e => e.IdTriagem)
                    .HasColumnName("idTriagem")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DecSaturacao)
                    .HasColumnName("decSaturacao")
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DecTemperatura)
                    .HasColumnName("decTemperatura")
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DtTriagem)
                    .HasColumnName("dtTriagem")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdConsulta)
                    .HasColumnName("idConsulta")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdEnfermeiro)
                    .HasColumnName("idEnfermeiro")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdPaciente)
                    .HasColumnName("idPaciente")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IntClassificacao)
                    .HasColumnName("intClassificacao")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IntDor)
                    .HasColumnName("intDor")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IntPressaoArterialMax)
                    .HasColumnName("intPressaoArterialMax")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IntPressaoArterialMin)
                    .HasColumnName("intPressaoArterialMin")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StrSintomas)
                    .HasColumnName("strSintomas")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.FltCpf)
                    .HasName("codCPF_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdEnderecoMunicipio)
                    .HasName("idEnderecoMunicipio_idx");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FlgMedico)
                    .HasColumnName("flgMedico")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FlgPaciente)
                    .HasColumnName("flgPaciente")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FltCelular)
                    .HasColumnName("fltCelular")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FltCpf).HasColumnName("fltCPF");

                entity.Property(e => e.FltEnderecoCep)
                    .HasColumnName("fltEnderecoCEP")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdEnderecoMunicipio)
                    .HasColumnName("idEnderecoMunicipio")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IntEnderecoNum)
                    .HasColumnName("intEnderecoNum")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StrEmail)
                    .HasColumnName("strEmail")
                    .HasMaxLength(120)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StrEndereco)
                    .HasColumnName("strEndereco")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StrEnderecoBairro)
                    .HasColumnName("strEnderecoBairro")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StrEnderecoCompleto)
                    .HasColumnName("strEnderecoCompleto")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StrUsuario)
                    .IsRequired()
                    .HasColumnName("strUsuario")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdEnderecoMunicipioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdEnderecoMunicipio)
                    .HasConstraintName("idEnderecoMunicipio");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
