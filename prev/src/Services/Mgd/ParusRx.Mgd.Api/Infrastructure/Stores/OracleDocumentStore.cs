// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Stores;

/// <summary>
/// An implementation of <see cref="IDocumentStore"/> for Oracle Database.
/// </summary>
public class OracleDocumentStore : IDocumentStore
{
    private readonly IMessageService _messageService;
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="OracleDocumentStore"/> class.
    /// </summary>
    /// <param name="connection">The connection on database.</param>
    /// <param name="messageService">The message service.</param>
    /// <param name="logger">The logger to use.</param>
    public OracleDocumentStore(IConnection connection,
        IMessageService messageService,
        ILogger<OracleDocumentStore> logger)
    {
        Connection = connection;
        _messageService = messageService;
        _logger = logger;
    }

    /// <summary>
    /// Gets the current connection.
    /// </summary>
    public IConnection Connection { get; }

    /// <inheritdoc/>
    public async Task UploadDocumentAsync(long companyId, long juridicalPersonId, Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        using var connection = (OracleConnection)Connection.ConnectionFactory.CreateConnection();
        await connection.OpenAsync();

        using var transaction = connection.BeginTransaction();
        try
        {
            var xmlDocument = _messageService.GetXmlDocument(message);
            var description = _messageService.GetDescription(message);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var content = await xmlDocument.GetBytesAsync(Encoding.GetEncoding("windows-1251"));

            var cmd = new OracleCommand
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "parus.pkg_belmgd.upload"
            };

            var paramCompany = cmd.CreateParameter();
            paramCompany.OracleDbType = OracleDbType.Int64;
            paramCompany.Direction = ParameterDirection.Input;
            paramCompany.ParameterName = "ncompany";
            paramCompany.Value = companyId;
            cmd.Parameters.Add(paramCompany);

            var paramJurPers = cmd.CreateParameter();
            paramJurPers.OracleDbType = OracleDbType.Int64;
            paramJurPers.Direction = ParameterDirection.Input;
            paramJurPers.ParameterName = "njurpers";
            paramJurPers.Value = juridicalPersonId;
            cmd.Parameters.Add(paramJurPers);

            var paramDescr = cmd.CreateParameter();
            paramDescr.OracleDbType = OracleDbType.Varchar2;
            paramDescr.Direction = ParameterDirection.Input;
            paramDescr.ParameterName = "sdescription";
            paramDescr.Value = description;
            cmd.Parameters.Add(paramDescr);

            var paramOrgTaxCode = cmd.CreateParameter();
            paramOrgTaxCode.OracleDbType = OracleDbType.Varchar2;
            paramOrgTaxCode.Direction = ParameterDirection.Input;
            paramOrgTaxCode.ParameterName = "sorg_taxcode";
            paramOrgTaxCode.Value = message.Taxcode;
            cmd.Parameters.Add(paramOrgTaxCode);

            var paramCode = cmd.CreateParameter();
            paramCode.OracleDbType = OracleDbType.Varchar2;
            paramCode.Direction = ParameterDirection.Input;
            paramCode.ParameterName = "sorg_code_fk";
            paramCode.Value = message.Code;
            cmd.Parameters.Add(paramCode);

            var paramKpp = cmd.CreateParameter();
            paramKpp.OracleDbType = OracleDbType.Varchar2;
            paramKpp.Direction = ParameterDirection.Input;
            paramKpp.ParameterName = "sorg_kpp";
            paramKpp.Value = message.Kpp;
            cmd.Parameters.Add(paramKpp);

            var paramDocumentId = cmd.CreateParameter();
            paramDocumentId.OracleDbType = OracleDbType.Varchar2;
            paramDocumentId.Direction = ParameterDirection.Input;
            paramDocumentId.ParameterName = "sdocument_id";
            paramDocumentId.Value = message.DocumentId;
            cmd.Parameters.Add(paramDocumentId);

            var paramClass = cmd.CreateParameter();
            paramClass.OracleDbType = OracleDbType.Varchar2;
            paramClass.Direction = ParameterDirection.Input;
            paramClass.ParameterName = "sclass";
            paramClass.Value = message.Class;
            cmd.Parameters.Add(paramClass);

            var paramStatus = cmd.CreateParameter();
            paramStatus.OracleDbType = OracleDbType.Varchar2;
            paramStatus.Direction = ParameterDirection.Input;
            paramStatus.ParameterName = "sstatus";
            paramStatus.Value = message.Status;
            cmd.Parameters.Add(paramStatus);

            var paramRecordTimeStamp = cmd.CreateParameter();
            paramRecordTimeStamp.OracleDbType = OracleDbType.Date;
            paramRecordTimeStamp.Direction = ParameterDirection.Input;
            paramRecordTimeStamp.ParameterName = "drecordtimestamp";
            paramRecordTimeStamp.Value = message.RecordTimeStamp;
            cmd.Parameters.Add(paramRecordTimeStamp);

            var paramContent = cmd.CreateParameter();
            paramContent.OracleDbType = OracleDbType.Blob;
            paramContent.Direction = ParameterDirection.Input;
            paramContent.ParameterName = "bcontent";
            paramContent.Value = content;
            cmd.Parameters.Add(paramContent);

            var paramRn = cmd.CreateParameter();
            paramRn.OracleDbType = OracleDbType.Int64;
            paramRn.Direction = ParameterDirection.Output;
            paramRn.ParameterName = "nrn";
            cmd.Parameters.Add(paramRn);

            cmd.ExecuteNonQuery();

            if (long.TryParse(paramRn.Value.ToString(), out var recordId))
            {
                var xmlDocumentFormat = xmlDocument.GetXmlDocumentFormat();
                if (xmlDocumentFormat == XmlDocumentFormat.Attachments)
                {
                    var attachedFiles = await xmlDocument.GetAttachedFilesAsync(Encoding.UTF8);
                    foreach (var file in attachedFiles)
                    {
                        var cmdAttach = new OracleCommand
                        {
                            Connection = connection,
                            CommandType = CommandType.StoredProcedure,
                            CommandText = "parus.pkg_belmgd.upload_attachment"
                        };

                        var paramAttachCompany = cmdAttach.CreateParameter();
                        paramAttachCompany.OracleDbType = OracleDbType.Int64;
                        paramAttachCompany.Direction = ParameterDirection.Input;
                        paramAttachCompany.ParameterName = "ncompany";
                        paramAttachCompany.Value = companyId;
                        cmdAttach.Parameters.Add(paramAttachCompany);

                        var paramAttachRn = cmdAttach.CreateParameter();
                        paramAttachRn.OracleDbType = OracleDbType.Int64;
                        paramAttachRn.Direction = ParameterDirection.Input;
                        paramAttachRn.ParameterName = "nrn";
                        paramAttachRn.Value = recordId;
                        cmdAttach.Parameters.Add(paramAttachRn);

                        var paramAttachFileName = cmdAttach.CreateParameter();
                        paramAttachFileName.OracleDbType = OracleDbType.Varchar2;
                        paramAttachFileName.Direction = ParameterDirection.Input;
                        paramAttachFileName.ParameterName = "sattach_filename";
                        paramAttachFileName.Value = file.FileName;
                        cmdAttach.Parameters.Add(paramAttachFileName);

                        var paramAttachFile = cmdAttach.CreateParameter();
                        paramAttachFile.OracleDbType = OracleDbType.Blob;
                        paramAttachFile.Direction = ParameterDirection.Input;
                        paramAttachFile.ParameterName = "battach_content";
                        paramAttachFile.Value = file.Content;
                        cmdAttach.Parameters.Add(paramAttachFile);

                        cmdAttach.ExecuteNonQuery();
                    }
                }
                else if (xmlDocumentFormat == XmlDocumentFormat.AttachmentsAsEArchive)
                {
                    var attaches = await xmlDocument.GetAttachesAsync(Encoding.UTF8);
                    foreach (var attach in attaches)
                    {
                        var cmdCard = new OracleCommand
                        {
                            Connection = connection,
                            CommandType = CommandType.StoredProcedure,
                            CommandText = "parus.pkg_belmgd.upload_card_to_bftea"
                        };

                        var paramCardCompany = cmdCard.CreateParameter();
                        paramCardCompany.OracleDbType = OracleDbType.Int64;
                        paramCardCompany.Direction = ParameterDirection.Input;
                        paramCardCompany.ParameterName = "ncompany";
                        paramCardCompany.Value = companyId;
                        cmdCard.Parameters.Add(paramCardCompany);

                        var paramCardJurPers = cmdCard.CreateParameter();
                        paramCardJurPers.OracleDbType = OracleDbType.Int64;
                        paramCardJurPers.Direction = ParameterDirection.Input;
                        paramCardJurPers.ParameterName = "njur_pers";
                        paramCardJurPers.Value = juridicalPersonId;
                        cmdCard.Parameters.Add(paramCardJurPers);

                        var paramCardDocTypesCode = cmdCard.CreateParameter();
                        paramCardDocTypesCode.OracleDbType = OracleDbType.Varchar2;
                        paramCardDocTypesCode.Direction = ParameterDirection.Input;
                        paramCardDocTypesCode.ParameterName = "sbfteadoctypes_code";
                        paramCardDocTypesCode.Value = attach.DocTypeCode;
                        cmdCard.Parameters.Add(paramCardDocTypesCode);

                        var paramCardExtId = cmdCard.CreateParameter();
                        paramCardExtId.OracleDbType = OracleDbType.Varchar2;
                        paramCardExtId.Direction = ParameterDirection.Input;
                        paramCardExtId.ParameterName = "sext_id";
                        paramCardExtId.Value = message.DocumentId;
                        cmdCard.Parameters.Add(paramCardExtId);

                        var paramCardSysCode = cmdCard.CreateParameter();
                        paramCardSysCode.OracleDbType = OracleDbType.Varchar2;
                        paramCardSysCode.Direction = ParameterDirection.Input;
                        paramCardSysCode.ParameterName = "ssys_code";
                        paramCardSysCode.Value = attach.SystemCode;
                        cmdCard.Parameters.Add(paramCardSysCode);

                        var paramCardRn = cmdCard.CreateParameter();
                        paramCardRn.OracleDbType = OracleDbType.Int64;
                        paramCardRn.Direction = ParameterDirection.Output;
                        paramCardRn.ParameterName = "nrn";
                        cmdCard.Parameters.Add(paramCardRn);

                        cmdCard.ExecuteNonQuery();


                        if (long.TryParse(paramCardRn.Value.ToString(), out var cardId))
                        {
                            var cmdAttach = new OracleCommand
                            {
                                Connection = connection,
                                CommandType = CommandType.StoredProcedure,
                                CommandText = "parus.pkg_belmgd.upload_attachment_to_bftea"
                            };

                            var paramAttachCompany = cmdAttach.CreateParameter();
                            paramAttachCompany.OracleDbType = OracleDbType.Int64;
                            paramAttachCompany.Direction = ParameterDirection.Input;
                            paramAttachCompany.ParameterName = "ncompany";
                            paramAttachCompany.Value = companyId;
                            cmdAttach.Parameters.Add(paramAttachCompany);

                            var paramAttachBelbftea = cmdAttach.CreateParameter();
                            paramAttachBelbftea.OracleDbType = OracleDbType.Int64;
                            paramAttachBelbftea.Direction = ParameterDirection.Input;
                            paramAttachBelbftea.ParameterName = "nbelbftea";
                            paramAttachBelbftea.Value = cardId;
                            cmdAttach.Parameters.Add(paramAttachBelbftea);

                            var paramAttachFileUUID = cmdAttach.CreateParameter();
                            paramAttachFileUUID.OracleDbType = OracleDbType.Varchar2;
                            paramAttachFileUUID.Direction = ParameterDirection.Input;
                            paramAttachFileUUID.ParameterName = "sfile_uuid";
                            paramAttachFileUUID.Value = attach.FileUUID;
                            cmdAttach.Parameters.Add(paramAttachFileUUID);

                            var paramAttachName = cmdAttach.CreateParameter();
                            paramAttachName.OracleDbType = OracleDbType.Varchar2;
                            paramAttachName.Direction = ParameterDirection.Input;
                            paramAttachName.ParameterName = "sattach_name";
                            paramAttachName.Value = attach.AttachName;
                            cmdAttach.Parameters.Add(paramAttachName);

                            var paramAttachExtId = cmdAttach.CreateParameter();
                            paramAttachExtId.OracleDbType = OracleDbType.Varchar2;
                            paramAttachExtId.Direction = ParameterDirection.Input;
                            paramAttachExtId.ParameterName = "sext_id";
                            paramAttachExtId.Value = attach.ExtId;
                            cmdAttach.Parameters.Add(paramAttachExtId);

                            var paramAttachRn = cmdAttach.CreateParameter();
                            paramAttachRn.OracleDbType = OracleDbType.Int64;
                            paramAttachRn.Direction = ParameterDirection.Output;
                            paramAttachRn.ParameterName = "nrn";
                            cmdAttach.Parameters.Add(paramAttachRn);

                            cmdAttach.ExecuteNonQuery();
                        }
                    }
                }

                transaction.Commit();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to upload the document.");

            throw;
        }
    }
}
