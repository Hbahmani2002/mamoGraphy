﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkList
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServisIstek", Namespace="http://schemas.datacontract.org/2004/07/HastaneWorkList.Services")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WorkList.MamografiIsListesiIstek))]
    public partial class ServisIstek : object
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MamografiIsListesiIstek", Namespace="http://schemas.datacontract.org/2004/07/HastaneWorkList.Services")]
    public partial class MamografiIsListesiIstek : WorkList.ServisIstek
    {
        
        private string BaslangicTarihField;
        
        private string BitisTarihField;
        
        private string IstemciAeTitleField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string BaslangicTarih
        {
            get
            {
                return this.BaslangicTarihField;
            }
            set
            {
                this.BaslangicTarihField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string BitisTarih
        {
            get
            {
                return this.BitisTarihField;
            }
            set
            {
                this.BitisTarihField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string IstemciAeTitle
        {
            get
            {
                return this.IstemciAeTitleField;
            }
            set
            {
                this.IstemciAeTitleField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServisSonuc", Namespace="http://schemas.datacontract.org/2004/07/HastaneWorkList.Services")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WorkList.MamografiIsListesiSonuc))]
    public partial class ServisSonuc : object
    {
        
        private string MesajField;
        
        private WorkList.ServisHatasi ServisHatasiField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mesaj
        {
            get
            {
                return this.MesajField;
            }
            set
            {
                this.MesajField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WorkList.ServisHatasi ServisHatasi
        {
            get
            {
                return this.ServisHatasiField;
            }
            set
            {
                this.ServisHatasiField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServisHatasi", Namespace="http://schemas.datacontract.org/2004/07/HastaneWorkList.Services")]
    public partial class ServisHatasi : object
    {
        
        private string AciklamaField;
        
        private string KoduField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Aciklama
        {
            get
            {
                return this.AciklamaField;
            }
            set
            {
                this.AciklamaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Kodu
        {
            get
            {
                return this.KoduField;
            }
            set
            {
                this.KoduField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MamografiIsListesiSonuc", Namespace="http://schemas.datacontract.org/2004/07/HastaneWorkList.Services")]
    public partial class MamografiIsListesiSonuc : WorkList.ServisSonuc
    {
        
        private WorkList.WorklistItem[] IsListesiField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WorkList.WorklistItem[] IsListesi
        {
            get
            {
                return this.IsListesiField;
            }
            set
            {
                this.IsListesiField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WorklistItem", Namespace="http://schemas.datacontract.org/2004/07/HastaneWorkList.Services")]
    public partial class WorklistItem : object
    {
        
        private string AccessionNumberField;
        
        private System.DateTime DateOfBirthField;
        
        private System.DateTime ExamDateAndTimeField;
        
        private string ExamDescriptionField;
        
        private string ExamRoomField;
        
        private string ForenameField;
        
        private string HospitalNameField;
        
        private string ModalityField;
        
        private string PatientIDField;
        
        private string PerformingPhysicianField;
        
        private string ProcedureIDField;
        
        private string ProcedureStepIDField;
        
        private string ReferringPhysicianField;
        
        private string ScheduledAETField;
        
        private string SexField;
        
        private string StudyUIDField;
        
        private string SurnameField;
        
        private string TitleField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AccessionNumber
        {
            get
            {
                return this.AccessionNumberField;
            }
            set
            {
                this.AccessionNumberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateOfBirth
        {
            get
            {
                return this.DateOfBirthField;
            }
            set
            {
                this.DateOfBirthField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ExamDateAndTime
        {
            get
            {
                return this.ExamDateAndTimeField;
            }
            set
            {
                this.ExamDateAndTimeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ExamDescription
        {
            get
            {
                return this.ExamDescriptionField;
            }
            set
            {
                this.ExamDescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ExamRoom
        {
            get
            {
                return this.ExamRoomField;
            }
            set
            {
                this.ExamRoomField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Forename
        {
            get
            {
                return this.ForenameField;
            }
            set
            {
                this.ForenameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string HospitalName
        {
            get
            {
                return this.HospitalNameField;
            }
            set
            {
                this.HospitalNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Modality
        {
            get
            {
                return this.ModalityField;
            }
            set
            {
                this.ModalityField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PatientID
        {
            get
            {
                return this.PatientIDField;
            }
            set
            {
                this.PatientIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PerformingPhysician
        {
            get
            {
                return this.PerformingPhysicianField;
            }
            set
            {
                this.PerformingPhysicianField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProcedureID
        {
            get
            {
                return this.ProcedureIDField;
            }
            set
            {
                this.ProcedureIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProcedureStepID
        {
            get
            {
                return this.ProcedureStepIDField;
            }
            set
            {
                this.ProcedureStepIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ReferringPhysician
        {
            get
            {
                return this.ReferringPhysicianField;
            }
            set
            {
                this.ReferringPhysicianField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ScheduledAET
        {
            get
            {
                return this.ScheduledAETField;
            }
            set
            {
                this.ScheduledAETField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sex
        {
            get
            {
                return this.SexField;
            }
            set
            {
                this.SexField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StudyUID
        {
            get
            {
                return this.StudyUIDField;
            }
            set
            {
                this.StudyUIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Surname
        {
            get
            {
                return this.SurnameField;
            }
            set
            {
                this.SurnameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title
        {
            get
            {
                return this.TitleField;
            }
            set
            {
                this.TitleField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WorkList.IHastaneWorkListService")]
    public interface IHastaneWorkListService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHastaneWorkListService/MamografiIsListesi", ReplyAction="http://tempuri.org/IHastaneWorkListService/MamografiIsListesiResponse")]
        System.Threading.Tasks.Task<WorkList.MamografiIsListesiSonuc> MamografiIsListesiAsync(string username, string password, WorkList.MamografiIsListesiIstek istek);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IHastaneWorkListServiceChannel : WorkList.IHastaneWorkListService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class HastaneWorkListServiceClient : System.ServiceModel.ClientBase<WorkList.IHastaneWorkListService>, WorkList.IHastaneWorkListService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public HastaneWorkListServiceClient() : 
                base(HastaneWorkListServiceClient.GetDefaultBinding(), HastaneWorkListServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.WSHttpBinding_IHastaneWorkListService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public HastaneWorkListServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(HastaneWorkListServiceClient.GetBindingForEndpoint(endpointConfiguration), HastaneWorkListServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public HastaneWorkListServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(HastaneWorkListServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public HastaneWorkListServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(HastaneWorkListServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public HastaneWorkListServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<WorkList.MamografiIsListesiSonuc> MamografiIsListesiAsync(string username, string password, WorkList.MamografiIsListesiIstek istek)
        {
            return base.Channel.MamografiIsListesiAsync(username, password, istek);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WSHttpBinding_IHastaneWorkListService))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WSHttpBinding_IHastaneWorkListService))
            {
                return new System.ServiceModel.EndpointAddress("https://mmtarama.saglik.gov.tr/HastaneWorklist/hastaneworklist.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return HastaneWorkListServiceClient.GetBindingForEndpoint(EndpointConfiguration.WSHttpBinding_IHastaneWorkListService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return HastaneWorkListServiceClient.GetEndpointAddress(EndpointConfiguration.WSHttpBinding_IHastaneWorkListService);
        }
        
        public enum EndpointConfiguration
        {
            
            WSHttpBinding_IHastaneWorkListService,
        }
    }
}
