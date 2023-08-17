/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Webhooks
 *
 * The Webhooks API enables applications to listen to APS events and receive notifications when they occur. When an event is triggered, the Webhooks service sends a notification to a callback URL you have defined.  You can customize the types of events and resources for which you receive notifications. For example, you can set up a webhook to send notifications when files are modified or deleted in a specified hub or project.  Below is quick summary of this workflow:  1. Identify the data for which you want to receive notifications. 2. Use the Webhooks API to create one or more hooks. 3. The Webhooks service will notify the webhook when there is a change in the data. 
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Autodesk.Webhooks.Model
{
    /// <summary>
    /// Defines Events
    /// </summary>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Events
    {
        
        /// <summary>
        /// Enum ExtractionFinished for value: extraction.finished
        /// </summary>
        [EnumMember(Value = "extraction.finished")]
        ExtractionFinished,
        
        /// <summary>
        /// Enum ExtractionUpdated for value: extraction.updated
        /// </summary>
        [EnumMember(Value = "extraction.updated")]
        ExtractionUpdated,
        
        /// <summary>
        /// Enum ModelSync for value: model.sync
        /// </summary>
        [EnumMember(Value = "model.sync")]
        ModelSync,
        
        /// <summary>
        /// Enum ModelPublish for value: model.publish
        /// </summary>
        [EnumMember(Value = "model.publish")]
        ModelPublish,
        
        /// <summary>
        /// Enum DmVersionAdded for value: dm.version.added
        /// </summary>
        [EnumMember(Value = "dm.version.added")]
        DmVersionAdded,
        
        /// <summary>
        /// Enum DmVersionModified for value: dm.version.modified
        /// </summary>
        [EnumMember(Value = "dm.version.modified")]
        DmVersionModified,
        
        /// <summary>
        /// Enum DmVersionDeleted for value: dm.version.deleted
        /// </summary>
        [EnumMember(Value = "dm.version.deleted")]
        DmVersionDeleted,
        
        /// <summary>
        /// Enum DmVersionMoved for value: dm.version.moved
        /// </summary>
        [EnumMember(Value = "dm.version.moved")]
        DmVersionMoved,
        
        /// <summary>
        /// Enum DmVersionMovedOut for value: dm.version.moved.out
        /// </summary>
        [EnumMember(Value = "dm.version.moved.out")]
        DmVersionMovedOut,
        
        /// <summary>
        /// Enum DmVersionCopied for value: dm.version.copied
        /// </summary>
        [EnumMember(Value = "dm.version.copied")]
        DmVersionCopied,
        
        /// <summary>
        /// Enum DmVersionCopiedOut for value: dm.version.copied.out
        /// </summary>
        [EnumMember(Value = "dm.version.copied.out")]
        DmVersionCopiedOut,
        
        /// <summary>
        /// Enum DmLineageReserved for value: dm.lineage.reserved
        /// </summary>
        [EnumMember(Value = "dm.lineage.reserved")]
        DmLineageReserved,
        
        /// <summary>
        /// Enum DmLineageUnreserved for value: dm.lineage.unreserved
        /// </summary>
        [EnumMember(Value = "dm.lineage.unreserved")]
        DmLineageUnreserved,
        
        /// <summary>
        /// Enum DmLineageUpdated for value: dm.lineage.updated
        /// </summary>
        [EnumMember(Value = "dm.lineage.updated")]
        DmLineageUpdated,
        
        /// <summary>
        /// Enum DmFolderAdded for value: dm.folder.added
        /// </summary>
        [EnumMember(Value = "dm.folder.added")]
        DmFolderAdded,
        
        /// <summary>
        /// Enum DmFolderModified for value: dm.folder.modified
        /// </summary>
        [EnumMember(Value = "dm.folder.modified")]
        DmFolderModified,
        
        /// <summary>
        /// Enum DmFolderDeleted for value: dm.folder.deleted
        /// </summary>
        [EnumMember(Value = "dm.folder.deleted")]
        DmFolderDeleted,
        
        /// <summary>
        /// Enum DmFolderPurged for value: dm.folder.purged
        /// </summary>
        [EnumMember(Value = "dm.folder.purged")]
        DmFolderPurged,
        
        /// <summary>
        /// Enum DmFolderMoved for value: dm.folder.moved
        /// </summary>
        [EnumMember(Value = "dm.folder.moved")]
        DmFolderMoved,
        
        /// <summary>
        /// Enum DmFolderMovedOut for value: dm.folder.moved.out
        /// </summary>
        [EnumMember(Value = "dm.folder.moved.out")]
        DmFolderMovedOut,
        
        /// <summary>
        /// Enum DmFolderCopied for value: dm.folder.copied
        /// </summary>
        [EnumMember(Value = "dm.folder.copied")]
        DmFolderCopied,
        
        /// <summary>
        /// Enum DmFolderCopiedOut for value: dm.folder.copied.out
        /// </summary>
        [EnumMember(Value = "dm.folder.copied.out")]
        DmFolderCopiedOut,
        
        /// <summary>
        /// Enum DmOperationStarted for value: dm.operation.started
        /// </summary>
        [EnumMember(Value = "dm.operation.started")]
        DmOperationStarted,
        
        /// <summary>
        /// Enum DmOperationCompleted for value: dm.operation.completed
        /// </summary>
        [EnumMember(Value = "dm.operation.completed")]
        DmOperationCompleted,
        
        /// <summary>
        /// Enum ItemClone for value: item.clone
        /// </summary>
        [EnumMember(Value = "item.clone")]
        ItemClone,
        
        /// <summary>
        /// Enum ItemCreate for value: item.create
        /// </summary>
        [EnumMember(Value = "item.create")]
        ItemCreate,
        
        /// <summary>
        /// Enum ItemLock for value: item.lock
        /// </summary>
        [EnumMember(Value = "item.lock")]
        ItemLock,
        
        /// <summary>
        /// Enum ItemRelease for value: item.release
        /// </summary>
        [EnumMember(Value = "item.release")]
        ItemRelease,
        
        /// <summary>
        /// Enum ItemUnlock for value: item.unlock
        /// </summary>
        [EnumMember(Value = "item.unlock")]
        ItemUnlock,
        
        /// <summary>
        /// Enum ItemUpdate for value: item.update
        /// </summary>
        [EnumMember(Value = "item.update")]
        ItemUpdate,
        
        /// <summary>
        /// Enum WorkflowTransition for value: workflow.transition
        /// </summary>
        [EnumMember(Value = "workflow.transition")]
        WorkflowTransition,
        
        /// <summary>
        /// Enum BudgetCreated10 for value: budget.created-1.0
        /// </summary>
        [EnumMember(Value = "budget.created-1.0")]
        BudgetCreated10,
        
        /// <summary>
        /// Enum BudgetUpdated10 for value: budget.updated-1.0
        /// </summary>
        [EnumMember(Value = "budget.updated-1.0")]
        BudgetUpdated10,
        
        /// <summary>
        /// Enum BudgetDeleted10 for value: budget.deleted-1.0
        /// </summary>
        [EnumMember(Value = "budget.deleted-1.0")]
        BudgetDeleted10,
        
        /// <summary>
        /// Enum BudgetPaymentCreated10 for value: budgetPayment.created-1.0
        /// </summary>
        [EnumMember(Value = "budgetPayment.created-1.0")]
        BudgetPaymentCreated10,
        
        /// <summary>
        /// Enum BudgetPaymentUpdated10 for value: budgetPayment.updated-1.0
        /// </summary>
        [EnumMember(Value = "budgetPayment.updated-1.0")]
        BudgetPaymentUpdated10,
        
        /// <summary>
        /// Enum BudgetPaymentDeleted10 for value: budgetPayment.deleted-1.0
        /// </summary>
        [EnumMember(Value = "budgetPayment.deleted-1.0")]
        BudgetPaymentDeleted10,
        
        /// <summary>
        /// Enum ContractCreated10 for value: contract.created-1.0
        /// </summary>
        [EnumMember(Value = "contract.created-1.0")]
        ContractCreated10,
        
        /// <summary>
        /// Enum ContractUpdated10 for value: contract.updated-1.0
        /// </summary>
        [EnumMember(Value = "contract.updated-1.0")]
        ContractUpdated10,
        
        /// <summary>
        /// Enum ContractDeleted10 for value: contract.deleted-1.0
        /// </summary>
        [EnumMember(Value = "contract.deleted-1.0")]
        ContractDeleted10,
        
        /// <summary>
        /// Enum CorCreated10 for value: cor.created-1.0
        /// </summary>
        [EnumMember(Value = "cor.created-1.0")]
        CorCreated10,
        
        /// <summary>
        /// Enum CorUpdated10 for value: cor.updated-1.0
        /// </summary>
        [EnumMember(Value = "cor.updated-1.0")]
        CorUpdated10,
        
        /// <summary>
        /// Enum CorDeleted10 for value: cor.deleted-1.0
        /// </summary>
        [EnumMember(Value = "cor.deleted-1.0")]
        CorDeleted10,
        
        /// <summary>
        /// Enum CostPaymentCreated10 for value: costPayment.created-1.0
        /// </summary>
        [EnumMember(Value = "costPayment.created-1.0")]
        CostPaymentCreated10,
        
        /// <summary>
        /// Enum CostPaymentUpdated10 for value: costPayment.updated-1.0
        /// </summary>
        [EnumMember(Value = "costPayment.updated-1.0")]
        CostPaymentUpdated10,
        
        /// <summary>
        /// Enum CostPaymentDeleted10 for value: costPayment.deleted-1.0
        /// </summary>
        [EnumMember(Value = "costPayment.deleted-1.0")]
        CostPaymentDeleted10,
        
        /// <summary>
        /// Enum ExpenseCreated10 for value: expense.created-1.0
        /// </summary>
        [EnumMember(Value = "expense.created-1.0")]
        ExpenseCreated10,
        
        /// <summary>
        /// Enum ExpenseUpdated10 for value: expense.updated-1.0
        /// </summary>
        [EnumMember(Value = "expense.updated-1.0")]
        ExpenseUpdated10,
        
        /// <summary>
        /// Enum ExpenseDeleted10 for value: expense.deleted-1.0
        /// </summary>
        [EnumMember(Value = "expense.deleted-1.0")]
        ExpenseDeleted10,
        
        /// <summary>
        /// Enum ExpenseItemCreated10 for value: expenseItem.created-1.0
        /// </summary>
        [EnumMember(Value = "expenseItem.created-1.0")]
        ExpenseItemCreated10,
        
        /// <summary>
        /// Enum ExpenseItemUpdated10 for value: expenseItem.updated-1.0
        /// </summary>
        [EnumMember(Value = "expenseItem.updated-1.0")]
        ExpenseItemUpdated10,
        
        /// <summary>
        /// Enum ExpenseItemDeleted10 for value: expenseItem.deleted-1.0
        /// </summary>
        [EnumMember(Value = "expenseItem.deleted-1.0")]
        ExpenseItemDeleted10,
        
        /// <summary>
        /// Enum MainContractCreated10 for value: mainContract.created-1.0
        /// </summary>
        [EnumMember(Value = "mainContract.created-1.0")]
        MainContractCreated10,
        
        /// <summary>
        /// Enum MainContractUpdated10 for value: mainContract.updated-1.0
        /// </summary>
        [EnumMember(Value = "mainContract.updated-1.0")]
        MainContractUpdated10,
        
        /// <summary>
        /// Enum MainContractDeleted10 for value: mainContract.deleted-1.0
        /// </summary>
        [EnumMember(Value = "mainContract.deleted-1.0")]
        MainContractDeleted10,
        
        /// <summary>
        /// Enum MainContractItemCreated10 for value: mainContractItem.created-1.0
        /// </summary>
        [EnumMember(Value = "mainContractItem.created-1.0")]
        MainContractItemCreated10,
        
        /// <summary>
        /// Enum MainContractItemUpdated10 for value: mainContractItem.updated-1.0
        /// </summary>
        [EnumMember(Value = "mainContractItem.updated-1.0")]
        MainContractItemUpdated10,
        
        /// <summary>
        /// Enum MainContractItemDeleted10 for value: mainContractItem.deleted-1.0
        /// </summary>
        [EnumMember(Value = "mainContractItem.deleted-1.0")]
        MainContractItemDeleted10,
        
        /// <summary>
        /// Enum OcoCreated10 for value: oco.created-1.0
        /// </summary>
        [EnumMember(Value = "oco.created-1.0")]
        OcoCreated10,
        
        /// <summary>
        /// Enum OcoUpdated10 for value: oco.updated-1.0
        /// </summary>
        [EnumMember(Value = "oco.updated-1.0")]
        OcoUpdated10,
        
        /// <summary>
        /// Enum OcoDeleted10 for value: oco.deleted-1.0
        /// </summary>
        [EnumMember(Value = "oco.deleted-1.0")]
        OcoDeleted10,
        
        /// <summary>
        /// Enum PcoCreated10 for value: pco.created-1.0
        /// </summary>
        [EnumMember(Value = "pco.created-1.0")]
        PcoCreated10,
        
        /// <summary>
        /// Enum PcoUpdated10 for value: pco.updated-1.0
        /// </summary>
        [EnumMember(Value = "pco.updated-1.0")]
        PcoUpdated10,
        
        /// <summary>
        /// Enum PcoDeleted10 for value: pco.deleted-1.0
        /// </summary>
        [EnumMember(Value = "pco.deleted-1.0")]
        PcoDeleted10,
        
        /// <summary>
        /// Enum ProjectInitialized10 for value: project.initialized-1.0
        /// </summary>
        [EnumMember(Value = "project.initialized-1.0")]
        ProjectInitialized10,
        
        /// <summary>
        /// Enum RfqCreated10 for value: rfq.created-1.0
        /// </summary>
        [EnumMember(Value = "rfq.created-1.0")]
        RfqCreated10,
        
        /// <summary>
        /// Enum RfqUpdated10 for value: rfq.updated-1.0
        /// </summary>
        [EnumMember(Value = "rfq.updated-1.0")]
        RfqUpdated10,
        
        /// <summary>
        /// Enum RfqDeleted10 for value: rfq.deleted-1.0
        /// </summary>
        [EnumMember(Value = "rfq.deleted-1.0")]
        RfqDeleted10,
        
        /// <summary>
        /// Enum ScheduleOfValueCreated10 for value: scheduleOfValue.created-1.0
        /// </summary>
        [EnumMember(Value = "scheduleOfValue.created-1.0")]
        ScheduleOfValueCreated10,
        
        /// <summary>
        /// Enum ScheduleOfValueUpdated10 for value: scheduleOfValue.updated-1.0
        /// </summary>
        [EnumMember(Value = "scheduleOfValue.updated-1.0")]
        ScheduleOfValueUpdated10,
        
        /// <summary>
        /// Enum ScheduleOfValueDeleted10 for value: scheduleOfValue.deleted-1.0
        /// </summary>
        [EnumMember(Value = "scheduleOfValue.deleted-1.0")]
        ScheduleOfValueDeleted10,
        
        /// <summary>
        /// Enum ScoCreated10 for value: sco.created-1.0
        /// </summary>
        [EnumMember(Value = "sco.created-1.0")]
        ScoCreated10,
        
        /// <summary>
        /// Enum ScoUpdated10 for value: sco.updated-1.0
        /// </summary>
        [EnumMember(Value = "sco.updated-1.0")]
        ScoUpdated10,
        
        /// <summary>
        /// Enum ScoDeleted10 for value: sco.deleted-1.0
        /// </summary>
        [EnumMember(Value = "sco.deleted-1.0")]
        ScoDeleted10
    }

}
