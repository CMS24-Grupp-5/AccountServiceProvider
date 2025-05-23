// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/account.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Presentation {
  public static partial class AccountGrpcService
  {
    static readonly string __ServiceName = "account.AccountGrpcService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.CreateAccountRequest> __Marshaller_account_CreateAccountRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.CreateAccountRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.CreateAccountReply> __Marshaller_account_CreateAccountReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.CreateAccountReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.ValidateCredentialsRequest> __Marshaller_account_ValidateCredentialsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.ValidateCredentialsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.ValidateCredentialsReply> __Marshaller_account_ValidateCredentialsReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.ValidateCredentialsReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.GetAccountsRequest> __Marshaller_account_GetAccountsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.GetAccountsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.GetAccountsReply> __Marshaller_account_GetAccountsReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.GetAccountsReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.GetAccountByIdRequest> __Marshaller_account_GetAccountByIdRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.GetAccountByIdRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.GetAccountByIdReply> __Marshaller_account_GetAccountByIdReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.GetAccountByIdReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.UpdatePhoneNumberRequest> __Marshaller_account_UpdatePhoneNumberRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.UpdatePhoneNumberRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.UpdatePhoneNumberReply> __Marshaller_account_UpdatePhoneNumberReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.UpdatePhoneNumberReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.DeleteAccountRequest> __Marshaller_account_DeleteAccountRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.DeleteAccountRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.DeleteAccountReply> __Marshaller_account_DeleteAccountReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.DeleteAccountReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.ConfirmAccountRequest> __Marshaller_account_ConfirmAccountRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.ConfirmAccountRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.ConfirmAccountReply> __Marshaller_account_ConfirmAccountReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.ConfirmAccountReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.UpdateEmailRequest> __Marshaller_account_UpdateEmailRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.UpdateEmailRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.UpdateEmailReply> __Marshaller_account_UpdateEmailReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.UpdateEmailReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.ConfirmEmailChangeRequest> __Marshaller_account_ConfirmEmailChangeRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.ConfirmEmailChangeRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.ConfirmEmailChangeReply> __Marshaller_account_ConfirmEmailChangeReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.ConfirmEmailChangeReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.ResetPasswordRequest> __Marshaller_account_ResetPasswordRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.ResetPasswordRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.ResetPasswordReply> __Marshaller_account_ResetPasswordReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.ResetPasswordReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.GenerateTokenRequest> __Marshaller_account_GenerateTokenRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.GenerateTokenRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Presentation.GenerateTokenReply> __Marshaller_account_GenerateTokenReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Presentation.GenerateTokenReply.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Presentation.CreateAccountRequest, global::Presentation.CreateAccountReply> __Method_CreateAccount = new grpc::Method<global::Presentation.CreateAccountRequest, global::Presentation.CreateAccountReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateAccount",
        __Marshaller_account_CreateAccountRequest,
        __Marshaller_account_CreateAccountReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Presentation.ValidateCredentialsRequest, global::Presentation.ValidateCredentialsReply> __Method_ValidateCredentials = new grpc::Method<global::Presentation.ValidateCredentialsRequest, global::Presentation.ValidateCredentialsReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ValidateCredentials",
        __Marshaller_account_ValidateCredentialsRequest,
        __Marshaller_account_ValidateCredentialsReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Presentation.GetAccountsRequest, global::Presentation.GetAccountsReply> __Method_GetAccounts = new grpc::Method<global::Presentation.GetAccountsRequest, global::Presentation.GetAccountsReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAccounts",
        __Marshaller_account_GetAccountsRequest,
        __Marshaller_account_GetAccountsReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Presentation.GetAccountByIdRequest, global::Presentation.GetAccountByIdReply> __Method_GetAccountById = new grpc::Method<global::Presentation.GetAccountByIdRequest, global::Presentation.GetAccountByIdReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAccountById",
        __Marshaller_account_GetAccountByIdRequest,
        __Marshaller_account_GetAccountByIdReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Presentation.UpdatePhoneNumberRequest, global::Presentation.UpdatePhoneNumberReply> __Method_UpdatePhoneNumber = new grpc::Method<global::Presentation.UpdatePhoneNumberRequest, global::Presentation.UpdatePhoneNumberReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdatePhoneNumber",
        __Marshaller_account_UpdatePhoneNumberRequest,
        __Marshaller_account_UpdatePhoneNumberReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Presentation.DeleteAccountRequest, global::Presentation.DeleteAccountReply> __Method_DeleteAccount = new grpc::Method<global::Presentation.DeleteAccountRequest, global::Presentation.DeleteAccountReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteAccount",
        __Marshaller_account_DeleteAccountRequest,
        __Marshaller_account_DeleteAccountReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Presentation.ConfirmAccountRequest, global::Presentation.ConfirmAccountReply> __Method_ConfirmAccount = new grpc::Method<global::Presentation.ConfirmAccountRequest, global::Presentation.ConfirmAccountReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ConfirmAccount",
        __Marshaller_account_ConfirmAccountRequest,
        __Marshaller_account_ConfirmAccountReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Presentation.UpdateEmailRequest, global::Presentation.UpdateEmailReply> __Method_UpdateEmail = new grpc::Method<global::Presentation.UpdateEmailRequest, global::Presentation.UpdateEmailReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateEmail",
        __Marshaller_account_UpdateEmailRequest,
        __Marshaller_account_UpdateEmailReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Presentation.ConfirmEmailChangeRequest, global::Presentation.ConfirmEmailChangeReply> __Method_ConfirmEmailChange = new grpc::Method<global::Presentation.ConfirmEmailChangeRequest, global::Presentation.ConfirmEmailChangeReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ConfirmEmailChange",
        __Marshaller_account_ConfirmEmailChangeRequest,
        __Marshaller_account_ConfirmEmailChangeReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Presentation.ResetPasswordRequest, global::Presentation.ResetPasswordReply> __Method_ResetPassword = new grpc::Method<global::Presentation.ResetPasswordRequest, global::Presentation.ResetPasswordReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ResetPassword",
        __Marshaller_account_ResetPasswordRequest,
        __Marshaller_account_ResetPasswordReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Presentation.GenerateTokenRequest, global::Presentation.GenerateTokenReply> __Method_GenerateEmailConfirmationToken = new grpc::Method<global::Presentation.GenerateTokenRequest, global::Presentation.GenerateTokenReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GenerateEmailConfirmationToken",
        __Marshaller_account_GenerateTokenRequest,
        __Marshaller_account_GenerateTokenReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Presentation.GenerateTokenRequest, global::Presentation.GenerateTokenReply> __Method_GeneratePasswordResetToken = new grpc::Method<global::Presentation.GenerateTokenRequest, global::Presentation.GenerateTokenReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GeneratePasswordResetToken",
        __Marshaller_account_GenerateTokenRequest,
        __Marshaller_account_GenerateTokenReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Presentation.AccountReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of AccountGrpcService</summary>
    [grpc::BindServiceMethod(typeof(AccountGrpcService), "BindService")]
    public abstract partial class AccountGrpcServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Presentation.CreateAccountReply> CreateAccount(global::Presentation.CreateAccountRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Presentation.ValidateCredentialsReply> ValidateCredentials(global::Presentation.ValidateCredentialsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Presentation.GetAccountsReply> GetAccounts(global::Presentation.GetAccountsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Presentation.GetAccountByIdReply> GetAccountById(global::Presentation.GetAccountByIdRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Presentation.UpdatePhoneNumberReply> UpdatePhoneNumber(global::Presentation.UpdatePhoneNumberRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Presentation.DeleteAccountReply> DeleteAccount(global::Presentation.DeleteAccountRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Presentation.ConfirmAccountReply> ConfirmAccount(global::Presentation.ConfirmAccountRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Presentation.UpdateEmailReply> UpdateEmail(global::Presentation.UpdateEmailRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Presentation.ConfirmEmailChangeReply> ConfirmEmailChange(global::Presentation.ConfirmEmailChangeRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Presentation.ResetPasswordReply> ResetPassword(global::Presentation.ResetPasswordRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Presentation.GenerateTokenReply> GenerateEmailConfirmationToken(global::Presentation.GenerateTokenRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Presentation.GenerateTokenReply> GeneratePasswordResetToken(global::Presentation.GenerateTokenRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(AccountGrpcServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_CreateAccount, serviceImpl.CreateAccount)
          .AddMethod(__Method_ValidateCredentials, serviceImpl.ValidateCredentials)
          .AddMethod(__Method_GetAccounts, serviceImpl.GetAccounts)
          .AddMethod(__Method_GetAccountById, serviceImpl.GetAccountById)
          .AddMethod(__Method_UpdatePhoneNumber, serviceImpl.UpdatePhoneNumber)
          .AddMethod(__Method_DeleteAccount, serviceImpl.DeleteAccount)
          .AddMethod(__Method_ConfirmAccount, serviceImpl.ConfirmAccount)
          .AddMethod(__Method_UpdateEmail, serviceImpl.UpdateEmail)
          .AddMethod(__Method_ConfirmEmailChange, serviceImpl.ConfirmEmailChange)
          .AddMethod(__Method_ResetPassword, serviceImpl.ResetPassword)
          .AddMethod(__Method_GenerateEmailConfirmationToken, serviceImpl.GenerateEmailConfirmationToken)
          .AddMethod(__Method_GeneratePasswordResetToken, serviceImpl.GeneratePasswordResetToken).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, AccountGrpcServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_CreateAccount, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Presentation.CreateAccountRequest, global::Presentation.CreateAccountReply>(serviceImpl.CreateAccount));
      serviceBinder.AddMethod(__Method_ValidateCredentials, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Presentation.ValidateCredentialsRequest, global::Presentation.ValidateCredentialsReply>(serviceImpl.ValidateCredentials));
      serviceBinder.AddMethod(__Method_GetAccounts, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Presentation.GetAccountsRequest, global::Presentation.GetAccountsReply>(serviceImpl.GetAccounts));
      serviceBinder.AddMethod(__Method_GetAccountById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Presentation.GetAccountByIdRequest, global::Presentation.GetAccountByIdReply>(serviceImpl.GetAccountById));
      serviceBinder.AddMethod(__Method_UpdatePhoneNumber, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Presentation.UpdatePhoneNumberRequest, global::Presentation.UpdatePhoneNumberReply>(serviceImpl.UpdatePhoneNumber));
      serviceBinder.AddMethod(__Method_DeleteAccount, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Presentation.DeleteAccountRequest, global::Presentation.DeleteAccountReply>(serviceImpl.DeleteAccount));
      serviceBinder.AddMethod(__Method_ConfirmAccount, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Presentation.ConfirmAccountRequest, global::Presentation.ConfirmAccountReply>(serviceImpl.ConfirmAccount));
      serviceBinder.AddMethod(__Method_UpdateEmail, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Presentation.UpdateEmailRequest, global::Presentation.UpdateEmailReply>(serviceImpl.UpdateEmail));
      serviceBinder.AddMethod(__Method_ConfirmEmailChange, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Presentation.ConfirmEmailChangeRequest, global::Presentation.ConfirmEmailChangeReply>(serviceImpl.ConfirmEmailChange));
      serviceBinder.AddMethod(__Method_ResetPassword, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Presentation.ResetPasswordRequest, global::Presentation.ResetPasswordReply>(serviceImpl.ResetPassword));
      serviceBinder.AddMethod(__Method_GenerateEmailConfirmationToken, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Presentation.GenerateTokenRequest, global::Presentation.GenerateTokenReply>(serviceImpl.GenerateEmailConfirmationToken));
      serviceBinder.AddMethod(__Method_GeneratePasswordResetToken, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Presentation.GenerateTokenRequest, global::Presentation.GenerateTokenReply>(serviceImpl.GeneratePasswordResetToken));
    }

  }
}
#endregion
