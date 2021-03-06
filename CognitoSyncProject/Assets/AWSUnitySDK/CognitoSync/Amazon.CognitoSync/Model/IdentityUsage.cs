/*
 * Copyright 2014-2014 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *
 *
 * Licensed under the AWS Mobile SDK for Unity Developer Preview License Agreement (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located in the "license" file accompanying this file.
 * See the License for the specific language governing permissions and limitations under the License.
 *
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.CognitoSync.Model
{
    /// <summary>
    /// Usage information for the identity.
    /// </summary>
    public partial class IdentityUsage
    {
        private int? _datasetCount;
        private long? _dataStorage;
        private string _identityId;
        private string _identityPoolId;
        private DateTime? _lastModifiedDate;


        /// <summary>
        /// Gets and sets the property DatasetCount. Number of datasets for the identity.
        /// </summary>
        public int DatasetCount
        {
            get { return this._datasetCount.GetValueOrDefault(); }
            set { this._datasetCount = value; }
        }

        // Check to see if DatasetCount property is set
        internal bool IsSetDatasetCount()
        {
            return this._datasetCount.HasValue; 
        }


        /// <summary>
        /// Gets and sets the property DataStorage. Total data storage for this identity.
        /// </summary>
        public long DataStorage
        {
            get { return this._dataStorage.GetValueOrDefault(); }
            set { this._dataStorage = value; }
        }

        // Check to see if DataStorage property is set
        internal bool IsSetDataStorage()
        {
            return this._dataStorage.HasValue; 
        }


        /// <summary>
        /// Gets and sets the property IdentityId. A name-spaced GUID (for example, us-east-1:23EC4050-6AEA-7089-A2DD-08002EXAMPLE)
        /// created by Amazon Cognito. GUID generation is unique within a region.
        /// </summary>
        public string IdentityId
        {
            get { return this._identityId; }
            set { this._identityId = value; }
        }

        // Check to see if IdentityId property is set
        internal bool IsSetIdentityId()
        {
            return this._identityId != null;
        }


        /// <summary>
        /// Gets and sets the property IdentityPoolId. A name-spaced GUID (for example, us-east-1:23EC4050-6AEA-7089-A2DD-08002EXAMPLE)
        /// created by Amazon Cognito. GUID generation is unique within a region.
        /// </summary>
        public string IdentityPoolId
        {
            get { return this._identityPoolId; }
            set { this._identityPoolId = value; }
        }

        // Check to see if IdentityPoolId property is set
        internal bool IsSetIdentityPoolId()
        {
            return this._identityPoolId != null;
        }


        /// <summary>
        /// Gets and sets the property LastModifiedDate. Date on which the identity was last modified.
        /// </summary>
        public DateTime LastModifiedDate
        {
            get { return this._lastModifiedDate.GetValueOrDefault(); }
            set { this._lastModifiedDate = value; }
        }

        // Check to see if LastModifiedDate property is set
        internal bool IsSetLastModifiedDate()
        {
            return this._lastModifiedDate.HasValue; 
        }

    }
}