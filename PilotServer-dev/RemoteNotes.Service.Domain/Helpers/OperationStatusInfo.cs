﻿namespace RemoteNotes.Service.Domain.Helpers
{
    public class OperationStatusInfo
    {
        public OperationStatusInfo()
        {
        }

        public OperationStatusInfo(OperationStatus operationStatus)
        {
            OperationStatus = operationStatus;
        }

        public OperationStatusInfo(OperationStatus operationStatus, object attachedObject) : this(operationStatus)
        {
            AttachedObject = attachedObject;
        }

        public OperationStatusInfo(OperationStatus operationStatus, string attachedInfo) : this(operationStatus)
        {
            AttachedInfo = attachedInfo;
        }

        public string AttachedInfo { get; set; } = string.Empty;
        public object AttachedObject { get; set; }

        public OperationStatus OperationStatus { get; set; }
    }

    public enum OperationStatus
    {
        Done = 0x1,
        Cancelled = 0x2
    }
}